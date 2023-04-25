using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.LevelVisualization;

namespace Bomberman.Entities.Items
{

    /// <summary>
    /// Represents an object that when interacted with, slows down the monsters.
    /// </summary>
    internal class Freezer : UpdatableEntity, Explodable
    {
        int counter = 0;
        int counterMax = 300;

        public Freezer() : base()
        {
            Random r = new Random(1234);
            Time = r.Next(1, 4) * 100;
        }

        /// <summary>
        /// Represents the duration of the boost in ticks, is randomly assigned in constructor.
        /// </summary>
        public int Time { get; init; }

        /// <summary>
        /// Updates the timer of visibility in the upBooster.
        /// Freezer is only visible for some time, than it disappears.
        /// </summary>
        public override void Update()
        {
            counter++;
            if (counter == counterMax)
            {
                Finished = true;
            }
        }
        public override ImageID ImageID { get => ImageID.Freezer; }
    }
}
