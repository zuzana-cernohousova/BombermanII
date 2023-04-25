using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Bomberman.LevelVisualization;

namespace Bomberman.Entities.Items
{
    /// <summary>
    /// Represents any entity that modifies the range of a bomb.
    /// </summary>
    internal abstract class Booster : UpdatableEntity
    {
        int counter = 0;
        int counterMax = 300;

        /// <summary>
        /// Updates the timer of visibility of the Booster.
        /// Booster is only visible for some time, than it disappears.
        /// </summary>
        public override void Update()
        {
            counter++;
            if (counter == counterMax)
            {
                Finished = true;
            }
        }
    }
    /// <summary>
    /// Represents an item that when claimed, reduces the range of the bomb.
    /// </summary>
    internal class AntiBooster : Booster
    {
        public override ImageID ImageID => ImageID.AntiBooster;
    }

    /// <summary>
    /// Represents an item that when claimed, increases the range of the bomb.
    /// </summary>
    internal class UpBooster : Booster
    {
        public override ImageID ImageID => ImageID.UpBooster;
    }
}
