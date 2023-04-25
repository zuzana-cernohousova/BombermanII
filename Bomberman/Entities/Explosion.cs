using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.LevelVisualization;

namespace Bomberman.Entities
{
    /// <summary>
    /// Represents explosion caused by a bomb.
    /// </summary>
    internal class Explosion : UpdatableEntity
    {
        int counter = 0;
        int counterMax = 10;

        Entity toBeDiscovered;

        /// <summary>
        /// Weather the explosion is an explosion of a destroyable wall and therefore something might be revealed by it.
        /// </summary>
        public bool FromDestroyableWall { get; private set; }

        public Explosion(Entity toBeDiscovered, bool fromDesWall) : base()
        {
            this.toBeDiscovered = toBeDiscovered;
            this.FromDestroyableWall = fromDesWall;
        }
        public override ImageID ImageID
        {
            get
            {
                if (FromDestroyableWall) return ImageID.ExploWall;
                return ImageID.Explosion;
            }
        }

        /// <summary>
        /// Increases the explosion timer, if it has reached the maximum, the explosion is finished.
        /// </summary>
        public override void Update()
        {
            counter++;
            if (counter == counterMax)
            {
                Finished = true;
            }
        }

        /// <summary>
        /// Returns a entity that is left in the position of the <see cref="Explosion"/> after it is finished. 
        /// </summary>
        /// <returns>An entity to be discovered.</returns>
        public override Entity getWhatsLeft()
        {
            return toBeDiscovered;
        }
    }

    /// <summary>
    /// Represents the subset of entities that the explosion is able to set on fire.
    /// </summary>
    internal interface Explodable
    {
        /// <summary>
        /// Retrurns which entity should be left behind after this one explodes.
        /// </summary>
        /// <returns>Entity that should be left behind after this one explodes.</returns>
        public Entity WhatIsLeftAfterExplosion()
        {
            return new Empty();
        }
    }
}
