using Bomberman.Level;
using Bomberman.LevelVisualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    /// <summary>
    /// Represents anything present in a level map.
    /// Is abstract, child classes represent individual entities.
    /// </summary>
    internal abstract class Entity
    {
        /// <summary>
        /// Represents name of a corresponding image displayed in the level graphics.
        /// </summary>
        public abstract ImageID ImageID { get; }
    }

    /// <summary>
    /// Represents any entity that changes with timer ticking.
    /// </summary>
    internal abstract class UpdatableEntity : Entity
    {
        /// <summary>
        /// Represents state of the <see cref="UpdatableEntity"/>.
        /// If the entity is "alive" or "running", is false, else is true
        /// </summary>
        public bool Finished { get; set; }

        public UpdatableEntity() : base()
        {
            Finished = false;
        }

        /// <summary>
        /// Makes changes in entity.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Returns a entity that is left in the position of the <see cref="UpdatableEntity"/> after it is finished.
        /// Defaultly returns <see cref="Empty"/> entity.
        /// </summary>
        /// <returns>Entity that should be left in the position of this entity.</returns>
        public virtual Entity getWhatsLeft()
        {
            return new Empty();
        }
    }

    /// <summary>
    /// Represents a type of <see cref="UpdatableEntity"/> that is able to move and change its coordinates.
    /// </summary>
    internal abstract class MoveableEntity : UpdatableEntity
    {
        protected Level.Level level;

        /// <summary>
        /// Is true if this <see cref="MoveableEntity"/> colided with an explosion or was exploded.
        /// </summary>
        public bool OnFire { get; set; }

        /// <summary>
        /// Creates a new instance of the MovealbeEntity.
        /// </summary>
        /// <param name="level">In which level the entity is.</param>
        /// <param name="row">In which row it is.</param>
        /// <param name="column">In which column it is.</param>
        public MoveableEntity(Level.Level level, int row, int column)
        {
            this.level = level;
            this.row = row;
            this.column = column;
        }

        /// <summary>
        /// Represents the row coordinate of this entity in the level map.
        /// </summary>
        protected int row { get; set; }

        /// <summary>
        /// Represents the column coordinate of this entity in the level map.
        /// </summary>
        protected int column { get; set; }

        /// <summary>
        /// Returns a tuple of ints representing current coordinates of this entity in the level map.
        /// </summary>
        /// <returns>A tuple of integers where the first int represents the row coordinate and the second represents the column coordinate.</returns>
        public virtual (int, int) getCoords()
        {
            return (row, column);
        }
    }
}
