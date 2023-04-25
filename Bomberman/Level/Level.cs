using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bomberman.Entities;
using Bomberman.Entities.Items;
using Bomberman.Game;

namespace Bomberman.Level
{
	/// <summary>
	/// Represents game level. Contains a map where all the entites exists, moves them and defines how they interact. Counts the score gained in the level.
	/// </summary>
	internal class Level
	{
		MapFactory mf;

		/// <summary>
		/// Represents state of the level before update
		/// </summary>
		internal Entity[,] map { get; private set; }

		/// <summary>
		/// Represents state of the level after update
		/// </summary>
        internal Entity[,] newMap { get; private set; }

		/// <summary>
		/// Represents the number of rows of the level map.
		/// </summary>
        internal int Rows { get; private set; }
		/// <summary>
		/// Represents the number of columns of the level map.
		/// </summary>
		internal int Columns { get; private set; }

		Hero hero;
		Exit exit;

		/// <summary>
		/// Numer of currently living monsters in the map.
		/// </summary>
		internal int LivingMonsters { get; private set; }
		List<Monster> monsters = new List<Monster>();
		List<Bomb> Bombs = new List<Bomb>();

		bool placeBomb;
		bool placeLandMine;

		/// <summary>
		/// Which key is currently pressed.
		/// </summary>
		internal KeyDown PressedKey { get; private set; } = KeyDown.None;

		/// <summary>
		/// Weather this level was won.
		/// </summary>
		internal bool Won { get; private set; } = false;
        /// <summary>
        /// Weather this level was lost.
        /// </summary>
        internal bool Lost { get; private set; } = false;

        int tickCounter = 0;
        const int scoreForMonster = 300;

		/// <summary>
		/// The current score of this level.
		/// </summary>
		internal int Score { get; private set; }

		/// <summary>
		/// Creates a new instance of the <see cref="Level"/> class.
		/// </summary>
		/// <param name="mf">Where the map for this level will be extracted from.</param>
		internal Level(MapFactory mf)
		{
			this.mf = mf;
		}

		/// <summary>
		/// Resets level by reseting all fields and reinitializing map
		/// </summary>
        internal void Reset()
        {
            this.Won = false;
            this.Lost = false;

            InitializeMap();
        }

		/// <summary>
		/// Creates map and fills all the important information about map contents
		/// </summary>
        internal void InitializeMap()
		{
			mf.SetLevel(this);

			// build map in the start state
			this.map = mf.getMap();

			this.Rows = map.GetLength(0);
			this.Columns = map.GetLength(1);

			this.hero = mf.GetHero();
			this.monsters = mf.GetMonsters();
            this.LivingMonsters = monsters.Count;

			this.exit = mf.GetExit();
            this.Bombs = new();

			Score = SetStartingScore();
		}

		/// <summary>
		/// Updates map and score.
		/// </summary>
        internal void Tick()
		{
			UpdateScore();
			UpdateMap();
		}

		/// <summary>
		/// Every once in a while reduces the <see cref="Level.Score"/>
		/// </summary>
		void UpdateScore()
		{
            tickCounter++;
            if (tickCounter == 5) 
            {
                tickCounter = 0;

                if (Score >= 5)
                {
                    Score -= 10;
                }
                else { Score = 0; }
            }

        }

		/// <summary>
		/// Updates map by updating every entity in map.
		/// Nonupdatable entities are copied, updatable updated, hero and monsters are moved, bombs tick and if explode, explosions are placed.
		/// </summary>
		private void UpdateMap()
			// for nonupdatable entities - will copy them into old positions
			// for upradtable entities - will let them update (they do have acces to old map), puts them into new map
		{
			newMap = new Entity[Rows, Columns];

			// place bomb
			if (placeBomb || placeLandMine)
			{
				(int r, int c) = hero.getCoords();

				Bomb b;
				if (placeBomb) b = new BasicBomb(this, r, c);
				else b = new LandMine(this, r, c);

                if (!Bombs.Contains(b))
				{
					hero.SetBomb(b);
					Bombs.Add(b); // will already work, if hero doesnt move, will explode on him
				}

				placeBomb = false;
				placeLandMine = false;
			}

			// make explosions
			if (Bombs.Count > 0)
			{
				ProcessBombs();
			}

			// move monsters
			ProcessMonsters();

			// move hero
			ProcessHero();

			for (int r = 0; r < Rows; r++)
			{
				for(int c = 0; c < Columns; c++)
				{
					if (newMap[r, c] is not null) { continue; }
						// already contains explosions from bomb processing or moved entity
					
					Entity e = map[r, c];

					if (e is Bomb) { continue; } // already processed
					

					if (e is UpdatableEntity u)
					{ 
						if (u is MoveableEntity) { continue; } // all processed

						u.Update();

						if (u.Finished) 
							// bombes already processed
							// here: explosion and upBooster, moveable entities if on fire
						{
							newMap[r, c] = u.getWhatsLeft();
							continue; // process next object
						} 

						else // if cannot move and did not finish, copy to new map
						{
							newMap[r, c] = u;
						}
					}
					 
					else // if cannot be updated, copy to new map
					{
						newMap[r, c] = e;
					}
				}
			}    

			map = newMap;
		}

		/// <summary>
		/// Updates all monsters and copies them into the new map into the new coordinates and empty space in the last coordinates.
		/// Resolves interactions with other entities.
		/// </summary>
		void ProcessMonsters()
		{
			List<Monster> deadMonsters = new List<Monster>();

			foreach (Monster monster in monsters)
			{
				if (monster.Finished) { 
					deadMonsters.Add(monster);

					(int r, int c) = monster.getCoords();
					newMap[r,c] = monster.getWhatsLeft();

                    continue; 
				}

				(int oldR, int oldC) = monster.getCoords();

                monster.Update();
                (int newR, int newC) = monster.getCoords();

                Entity steppedOn = map[newR, newC];

                if (steppedOn is Explosion || newMap[newR,newC] is Explosion )
                {
                    SetMonsterOnFire(monster);
                }
				else if (steppedOn is Hero)
				{
					if (monster.OnFire)
					{
						SetHeroOnFire();
					}
					else
					{
						EatHero();
					}
				}
				else if (steppedOn is LandMine lm)
				{
					lm.Activate();
					// will not be in map, but still is in the list of bombs, will explode in the next tick
				}

				newMap[newR, newC] = monster;

				if (newR != oldR || newC != oldC)
				{
					newMap[oldR, oldC] = monster.getWhatsLeft();
				}
            }

			foreach (Monster deadMonster in deadMonsters) { monsters.Remove(deadMonster); }
		}

		/// <summary>
		/// Updates hero and copies him into his new coordinates.
		/// Resolves his interactions with other entities.
		/// </summary>
		void ProcessHero()
		{
            (int oldR, int oldC) = hero.getCoords();
			hero.Update();

            (int newR, int newC) = hero.getCoords();

            Entity steppedOn = map[newR, newC];


            if (steppedOn is Explosion)
            {
                SetHeroOnFire();
				// sets on fire, moves and sets Won or Lost if needed

				newMap[newR, newC] = hero;
                newMap[oldR, oldC] = hero.getWhatsLeft(); //moved --> left empty space
                return;
            }

            if (steppedOn is Chest chest)
            {
                Score += chest.Value;
            }
            else if (steppedOn is Key)
            {
                exit.Open = true;
            }
            else if (steppedOn is Exit)
            {
                Won = true;
                // if exit is not open, it cannot be stepped on --> so here is open
            }
            else if (steppedOn is LandMine lm)
            {
                lm.Activate();
                // will not be in map, but still is in the list of bombs, will explode in the next tick
            }
            else if (steppedOn is Freezer freezer)
            {
				foreach (Monster m in monsters)
				{
					m.Freeze(freezer.Time);
				}
            }
			else if (steppedOn is Booster)
			{
				if (steppedOn is UpBooster)
				{
					hero.Boost();
				}
				if(steppedOn is AntiBooster)
				{
					hero.AntiBoost();
				}
			}
            else if (steppedOn is Monster m)
            {
				if (m.OnFire)
				{
					SetHeroOnFire();
				}
				else
				{
					EatHero();
                }
            }

            newMap[newR, newC] = hero;

            if (newR != oldR || newC != oldC)
            {
                newMap[oldR, oldC] = hero.getWhatsLeft();
            }
        }

		/// <summary>
		/// Updates all bombs and copies them into the new map.
		/// If bomb ticking ends, places explosions and resoves explosion interaction with other entities.
		/// </summary>
		void ProcessBombs()
		{
			List<Bomb> finishedBombs = new List<Bomb>();
			
			foreach (Bomb b in Bombs)
			{
				List<(int, int)> explosionCoords;
				
				b.Update();

				if (b.Finished) // bomb is Finished if it exploded
				{
					finishedBombs.Add(b);
					explosionCoords = b.GetExplosionCoords();

					foreach ((int r, int c) in explosionCoords)
					{ 
						Entity e = map[r, c];

						if (e is Monster m)
						{
							SetMonsterOnFire(m);
                            newMap[r, c] = m;

                            continue;
						}

						if (e is Hero h)
						{
                            SetHeroOnFire();
                            newMap[r, c] = h; 

                            continue;
                        }
						// explosion activates other bombs, nothing special happens with the bomb itself, turns into explosion
						if (e is Bomb anotherB && !anotherB.Equals(b))
						{
							anotherB.Activate();
							// will not show as an explosion
							continue;
						}

                        Explosion explosion;

                        if (e is Explodable explodable) // all other things
						{
							if (e is DestroyableWall)
                            {
                                explosion = new Explosion(explodable.WhatIsLeftAfterExplosion(), true);
                            }
							else
							{
								explosion = new Explosion(explodable.WhatIsLeftAfterExplosion(), false);
							}
                        }
						else explosion = null;
							// never happens - only explodable entities are on these coords

						newMap[r, c] = explosion;
					}
				}

				else // if not finished, copy bomb
				{
					if (map[b.Row, b.Column] is not Hero) // if not stil in heros hands
					{
                        newMap[b.Row, b.Column] = b;
                    }
                }
			}

			foreach (Bomb b in finishedBombs)
			{
				Bombs.Remove(b);
			}
		}

		/// <summary>
		/// Passes information about currently pressed key into level.
		/// </summary>
		/// <param name="key">Currently pressed key</param>
		internal void UpdateKeyInfo(KeyDown key)
		{
			this.PressedKey = key;
            PlaceBombs(key);
        }

		/// <summary>
		/// Determines weather any bombs should be placed accroding to the currently pressed key.
		/// </summary>
		/// <param name="key">Currently pressed key</param>
        void PlaceBombs(KeyDown key)
		{
			placeLandMine = false;
			placeBomb = false;

			if (key == KeyDown.B)
			{
				placeBomb = true;
			}
			if (key == KeyDown.M)
			{
				placeLandMine = true;
			}
		}

        /// <summary>
        /// Determines weather the <paramref name="r"/> and <paramref name="c"/> parameters represent valid coordinates in the current level map.
        /// </summary>
        /// <param name="r">Row coordinate</param>
        /// <param name="c">Column coordinate</param>
        /// <returns></returns>
        internal bool AreCoordsInMap(int r, int c)
		{
			if (r < Rows && c < Columns
				&& r > -1 && c > -1)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Sets monster on fire, reduces the number of living monsters and adds to score. If there are no more living monsters, the game was is won.
		/// </summary>
		/// <param name="m">Monster that should be set on fire</param>
		void SetMonsterOnFire(Monster m)
		{
            m.OnFire = true;

            if (m is Monster)
            {
                Score += scoreForMonster;
                LivingMonsters--;
                if (LivingMonsters == 0)
                {
                    Won = true;
                }
            }
        }

		/// <summary>
		/// Sets hero on fire and sets the game to lost state.
		/// </summary>
		/// <param name="h"></param>
		void SetHeroOnFire()
		{
			hero.OnFire = true;
			Lost = true;
		}
        void EatHero()
        {
            hero.Eaten = true;
            Lost = true;
        }

        int SetStartingScore()
		{
			return (map.GetLength(0) * map.GetLength(1) * monsters.Count ) / 5 * 5 + 500;
		}

		// todo remove
		internal void setWon()
		{
			this.Won = true;
		}

		// todo remove
		internal void setLost()
		{
			this.Lost = true;
		}
	}
}
