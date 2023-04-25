using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.LevelVisualization;

namespace Bomberman.Entities
{
    /// <summary>
    /// Represents a rigid wall in the map.
    /// </summary>
    internal class Wall : Entity
    {
        public override ImageID ImageID { get => ImageID.Wall; }
    }

    /// <summary>
    /// Represents an empty space in the map.
    /// </summary>
    internal class Empty : Entity, Explodable
    {
        public override ImageID ImageID { get => ImageID.Empty; }
    }
}
