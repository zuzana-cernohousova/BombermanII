using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.LevelVisualization;

namespace Bomberman.Entities.Items
{
    /// <summary>
    /// Represents the end of the exit from the map. When the hero goes through, he wins.
    /// </summary>
    internal class Exit : Entity
    {
        /// <summary>
        /// Represents the state of the exit. Is <see langword="false"/> when the key wan not yet found, else <see langword="true"/>.
        /// </summary>
        public bool Open { get; set; } = false;

        public override ImageID ImageID
        {
            get
            {
                if (Open) return ImageID.OpenExit;
                else return ImageID.ClosedExit;
            }
        }
    }

    /// <summary>
    /// Represents a key that needs to be discovered and claimed to open the exit.
    /// </summary>
    internal class Key : Entity
    {
        public override ImageID ImageID { get => ImageID.Key; }
    }
}
