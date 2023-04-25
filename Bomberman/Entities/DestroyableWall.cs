using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.LevelVisualization;

namespace Bomberman.Entities
{
    /// <summary>
    /// Represents a type of wall that can be destroyed via an explosion.
    /// After the explosion, a new entity (<see cref="Empty"/> or an item) will be discovered.
    /// </summary>
    internal class DestroyableWall : Entity, Explodable
    {
        Entity toBeDiscovered;

        public DestroyableWall(Entity toBeDiscovered)
        {
            this.toBeDiscovered = toBeDiscovered;
        }
        public override ImageID ImageID { get => ImageID.DestroyableWall; }

        /// <summary>
        /// Returns an entity that should be discovered after the destroyable wall exploded.
        /// </summary>
        /// <returns></returns>
        public Entity WhatIsLeftAfterExplosion()
        {
            return toBeDiscovered;
        }
    }
}
