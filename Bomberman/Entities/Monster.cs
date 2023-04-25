using Bomberman.Level;
using Bomberman.LevelVisualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    /// <summary>
    /// Represents an enemy that runs around and when interacted with, kills the hero.
    /// When a monster is killed, points are added to the score. Not all monsters have to be killed to win the level, but the level can be won by killing all the monsters.
    /// Monster allways takes a right turn if possible, but if it can see the hero, it runs straight toward him.
    /// </summary>
    internal class Monster : MoveableEntity, Explodable
    {
        bool raging { get; set; } = false; // raging if can see hero
        int heroDirection;
        int direction = 0;
        bool lastRotated;

        int speedCounter;

        bool frozen = false;
        int frozenCounter;
        int maxFrozenCounter;

        Explosion? explosion;

        int[,] directions = new int[,] { { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 0 } }; // left, up, right, down

        public override ImageID ImageID
        {
            get
            {
                if (OnFire) return ImageID.ExploMonster;
                if (raging) return ImageID.RagingMonster;
                return ImageID.CalmMonster;
            }
        }

        /// <summary>
        /// Creaters a new instance of the <see cref="Monster"/> class.
        /// </summary>
        /// <param name="level">The level that the monster lives in.</param>
        /// <param name="row">In what row it is.</param>
        /// <param name="collumn">In what column it is.</param>
        public Monster(Level.Level level, int row, int collumn) : base(level, row, collumn) { }

        /// <summary>
        /// If the monster is able to move, updates its coordinates.
        /// Also takes care of setting monster of fire and finishing it.
        /// </summary>
        public override void Update()
        {
            if (OnFire)
            {
                if (explosion is null)
                {
                    explosion = new Explosion(new Empty(), false);
                }
                else
                {
                    explosion.Update();
                    if (explosion.Finished)
                    {
                        Finished = true;
                    }
                }

                return;
            }

            speedCounter++;

            if (frozen)
            {
                frozenCounter++;
                if (frozenCounter == maxFrozenCounter)
                {
                    frozen = false;
                }

                if (speedCounter == 5)
                {
                    speedCounter = 0;
                }
                else return;
            }

            else
            {
                if (speedCounter == 2)
                {
                    speedCounter = 0;
                }
                else return; // only move every fourth tick
            }

            raging = CanSeeHero();
            if (raging)
            {
                MoveSmart();
            }
            else
            {
                MoveDumb();
            }
        }

        /// <summary>
        /// Slows the monster down for the specified amount of time from the <paramref name="time"/>.
        /// </summary>
        /// <param name="time">The amount of time the monster should be slowed down for. </param>
        public void Freeze(int time)
        {
            frozen = true;
            frozenCounter = 0;
            maxFrozenCounter = time;
        }

        /// <summary>
        /// If it is possible, turn right, esle go straight forward, if there is a obstacle in front of the monster, turn left.
        /// </summary>
        private void MoveDumb()
        {
            if (!lastRotated)
            {
                // what is on the right?
                int dirOnTheRight = (direction + 1) % 4;

                int rightx = row + directions[dirOnTheRight, 0];
                int righty = column + directions[dirOnTheRight, 1];

                if (level.AreCoordsInMap(rightx, righty))
                {
                    // if empty, rotate to the right
                    if (CanMoveThere(rightx, righty))
                    {
                        direction = dirOnTheRight;
                        lastRotated = true;

                        MoveDumb();
                        return;
                    }
                    // esle continue in last directinon
                }
            }

            // move in the last direction
            int newx = row + directions[direction, 0];
            int newy = column + directions[direction, 1];

            if (level.AreCoordsInMap(newx, newy) && CanMoveThere(newx, newy))
            {

                row = newx;
                column = newy;
                lastRotated = false;

                return;
            }
            // rotate to the left

            direction = direction - 1;
            if (direction < 0) { direction += 4; }
            lastRotated = true;

        }

        /// <summary>
        /// Allways go in the direction of the hero.
        /// </summary>
        private void MoveSmart()
        {
            int dx = directions[heroDirection, 0];
            int dy = directions[heroDirection, 1];

            // should not be out of normalRange, because hero is there

            if (CanMoveThere(row + dx, column + dy))
            {
                row = row + dx;
                column = column + dy;
            }
        }

        /// <summary>
        /// Determines weather the hero is visible from the position of the monster.
        /// </summary>
        /// <returns><see langword="true"/> if the monster is able to see the hero, <see langword="false"/> otherwise</returns>
        private bool CanSeeHero()
        {
            for (int i = 0; i < 4; i++)
            {
                int dx = directions[i, 0];
                int dy = directions[i, 1];

                int newx = row;
                int newy = column;
                while (true)
                {
                    newx = newx + dx;
                    newy = newy + dy;

                    if (level.AreCoordsInMap(newx, newy))
                    {

                        if (level.map[newx, newy] is Hero)
                        {
                            heroDirection = i;
                            return true;
                        }
                        if (level.map[newx, newy] is Wall or DestroyableWall)
                        {
                            break;
                        }
                    }
                    else break;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines weather the monster is able to move into the position specified by the parameters.
        /// </summary>
        /// <param name="newR">New row coordinate</param>
        /// <param name="newC">New column coordinate</param>
        /// <returns></returns>
        private bool CanMoveThere(int newR, int newC)
        {
            Entity e = level.map[newR, newC];
            Entity eInNewMap = level.newMap[newR, newC];

            if (eInNewMap is Monster) // monsters must move before hero
            {
                return false;

                // cannot move there if another monster is already there
                // monster would disappear
            }

            if (e is Explosion ex && ex.FromDestroyableWall) { return false; }

            if (e is Empty or Explosion or Hero or LandMine)
            {
                return true;
            }

            // all other situations
            return false;
        }

    }
}
