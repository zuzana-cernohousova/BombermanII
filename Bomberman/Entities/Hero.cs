using Bomberman.Entities.Items;
using Bomberman.Game;
using Bomberman.Level;
using Bomberman.LevelVisualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    /// <summary>
    /// Represents the Bomberman. This entity is controlled by the user.
    /// </summary>
    internal class Hero : MoveableEntity, Explodable
    {
        KeyDown lastTickKey = KeyDown.None;

        int[,] directions = new int[,] { { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 0 } }; // left, up, right, down

        bool hasBomb;
        Bomb? BombToBeLeft;

        bool boosted = false;
        bool antiboosted = false;
        int boostCounter = 0;
        int maxBoostCounter = 200;

        /// <summary>
        /// Weather the hero was eaten by a monster.
        /// </summary>
        public bool Eaten { get; set; } = false;

        Explosion? explosion; // used for timing the explosion even when not necessary, good for expanding

        public override ImageID ImageID
        {
            get
            {
                if (Eaten) return ImageID.FullMonster;
                if (OnFire) return ImageID.ExploHero;
                if (hasBomb) return ImageID.BombHero;
                return ImageID.Hero;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Hero"/> class.
        /// </summary>
        /// <param name="level">The level the hero lives in.</param>
        /// <param name="row">In what row he is.</param>
        /// <param name="column">In what column he is.</param>
        public Hero(Level.Level level, int row, int column) : base(level, row, column)
        {
        }

        /// <summary>
        /// Updates the coordinates according to the pressed key.
        /// </summary>
        public override void Update()
        {
            // move according to arrows pushed, pushed arrows gets from level
            if (Eaten) { return; }
            if (OnFire)
            // if explosion catches him, he will not be able to move in the same tick (bombs go first)
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

            if (boosted || antiboosted)
            {
                boostCounter++;
                if (boostCounter == maxBoostCounter) { UnBoost(); }
            }

            int direction;

            KeyDown kd;
            if (level.PressedKey == KeyDown.None)
            {
                kd = lastTickKey;
            }
            else { kd = level.PressedKey; }

            switch (kd)
            {
                case KeyDown.Left:
                case KeyDown.Up:
                case KeyDown.Right:
                case KeyDown.Down:
                    direction = (int)kd; // number of key correspond to direction indexes
                    break;
                default:
                    return; // no arrow -> do not move
            }

            int newx = row + directions[direction, 0];
            int newy = column + directions[direction, 1];

            if (level.AreCoordsInMap(newx, newy))
            {
                if (CanMoveThere(newx, newy))
                {
                    row = newx;
                    column = newy;
                }
            }

        }


        /// <summary>
        /// Determines weather hero can move in the position specified in parameters.
        /// </summary>
        /// <param name="newR">New row coordinate</param>
        /// <param name="newC">New column coordinate</param>
        /// <returns><see langword="true"/> if it is possible to move to the new position, <see langword="false"/> otherwise.</returns>
        private bool CanMoveThere(int newR, int newC)
        {
            Entity e = level.map[newR, newC];

            if (e is Wall or DestroyableWall or BasicBomb)
            {
                return false;
            }

            if (e is Exit exit && !exit.Open)
            {
                return false;
            }

            if (e is Explosion ex && ex.FromDestroyableWall)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gives the <paramref name="bomb"/> to the hero so that it will be left behind after he moves.
        /// </summary>
        /// <param name="bomb"><see cref="Bomb"/> entity to be left behind</param>
        public void SetBomb(Bomb bomb)
        {
            BombToBeLeft = bomb;

            if (boosted) { bomb.Boost(); }
            if (antiboosted) { bomb.Antiboost(); }

            hasBomb = true;
        }

        public override Entity getWhatsLeft()
        {
            if (hasBomb)
            {
                hasBomb = false;
                return BombToBeLeft;
            }
            return new Empty();
        }

        /// <summary>
        /// Makes it so that all bombs from now until later will have bigger range of explosion.
        /// </summary>
        internal void Boost()
        {
            boosted = true;
            antiboosted = false;
            boostCounter = 0;

            if (hasBomb)
            {
                BombToBeLeft.Boost();
            }
        }


        /// <summary>
        /// Makes it so that all bombs from now until later will have smaller range of explosion.
        /// </summary>
        internal void AntiBoost()
        {
            boosted = false;
            antiboosted = true;
            boostCounter = 0;

            if (hasBomb)
            {
                BombToBeLeft.Antiboost();
            }
        }

        void UnBoost()
        {
            boosted = false;
            antiboosted = false;
            boostCounter = 0;
        }
    }
}
