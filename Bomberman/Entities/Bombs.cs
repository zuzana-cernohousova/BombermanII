using Bomberman.Level;
using Bomberman.LevelVisualization;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    /// <summary>
    /// Represents any type of bomb.
    /// </summary>
    internal abstract class Bomb : UpdatableEntity, Explodable
    {
        protected Level.Level level;

        /// <summary>
        /// Represents in which row the bomb is placed.
        /// </summary>
        public int Row { get; protected set; }
        /// <summary>
        /// Represents in which column the bomb is placed.
        /// </summary>
        public int Column { get; protected set; }

        int[,] directions = new int[,] { { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 0 } };
        // left, up, right, down


        bool boosted = false;
        bool antiboosted = false;

        int boostedRange = 4;
        int normalRange = 3;
        int antiboostedRange = 2;

        /// <summary>
        /// Creates a new instance of the <see cref="Bomb"/> class.
        /// </summary>
        /// <param name="level">In which level the bomb is.</param>
        /// <param name="row">In which row it is.</param>
        /// <param name="column">In which column it is.</param>
        protected Bomb(Level.Level level, int row, int column):base()
        {
            this.level = level;
            Row = row;
            Column = column;
        }

        /// <summary>
        /// </summary>
        /// <returns>A new <see cref="Explosion"/> entity.</returns>
        public override Entity getWhatsLeft()
        {
            return new Explosion(new Empty(), false);
        }

        /// <summary>
        /// Creates and returns a list of coordinates where explosions should be placed.
        /// </summary>
        /// <returns>A List of tuples of two integers where the
        /// first int represents the row coordinate and the second one the column coordinate.</returns>
        public virtual List<(int, int)> GetExplosionCoords()
        {
            List<(int, int)> res = new();

            res.Add((Row, Column)); // add these coords

            int range = normalRange;

            #region booster
            if (boosted)
            {
                range = boostedRange;
            }
            if (antiboosted)
            {
                range = antiboostedRange;
            }
            #endregion

            for (int i = 0; i < 4; i++)
            {
                int dx = directions[i, 0];
                int dy = directions[i, 1];

                int newx = Row;
                int newy = Column;
                for (int j = 0; j < range; j++)
                {
                    newx = newx + dx;
                    newy = newy + dy;

                    if (level.AreCoordsInMap(newx, newy))
                    {
                        if (level.map[newx, newy] is Explodable)
                        {
                            res.Add((newx, newy));

                            if (level.map[newx, newy] is not Empty)
                            {
                                break; // explosion is stopped by every object
                            }
                        }
                        else break;
                    }
                    else break;
                }
            }

            return res;
        }

        /// <summary>
        /// Causes the bomb to detonate in the next tick.
        /// </summary>
        public abstract void Activate();


        /// <summary>
        /// Determines weather the specified object is equal to this <see cref="Bomb"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Bomb"/></param>
        /// <returns><see langword="true"/> if the <paramref name="obj"/> is a <see cref="Bomb"/> and has the same coordinates. Else <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Bomb b)
            {
                if (b.Row == Row && b.Column == Column) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Expands the range of the bomb explosion.
        /// </summary>
        public void Boost()
        {
            boosted = true;
            antiboosted = false;
        }

        /// <summary>
        /// Reduces the range of the bomb explosion.
        /// </summary>
        public void Antiboost()
        {
            antiboosted = true;
            boosted = false;
        }
    }

    /// <summary>
    /// Represents a type of bomb that is placed in the map,
    /// than ticks and after certain amount of ticks, it explodes.
    /// </summary>
    internal class BasicBomb : Bomb
    {
        int counter = 0;
        readonly int counterMax = 20;

        public BasicBomb(Level.Level level, int row, int column) : base(level, row, column)
        {

        }

        /// <summary>
        /// Increases the ticking counter, if it has reached the maximum, 
        /// </summary>
        public override void Update()
        {
            counter++;
            if (counter == counterMax)
            {
                Finished = true;
            }
        }
        public override ImageID ImageID { get => ImageID.BasicBomb; }

        public override void Activate()
        {
            counter = counterMax - 1;
        }
    }

    /// <summary>
    /// Represents a type of bomb that is placed in the map,
    /// and when a <see cref="MoveableEntity"/> interacts with it, it explodes.
    /// </summary>
    internal class LandMine : Bomb
    {
        public LandMine(Level.Level level, int row, int collumn) : base(level, row, collumn)
        { }

        bool activated;

        public override ImageID ImageID { get => ImageID.LandMine; }

        /// <summary>
        /// If this <see cref="LandMine"/> is activated, detonates it. Else does nothing.
        /// </summary>
        public override void Update()
        {
            // do nothing, wait to be activated
            // destroyed by contact with hero/monster
            if (activated) { Finished = true; }
        }

        public override void Activate()
        {
            activated = true;
        }

        public override List<(int, int)> GetExplosionCoords()
        {
            List<(int, int)> res = new();
            res.Add((Row, Column));
            return res;
        }

    }
}
