using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.LevelVisualization;

namespace Bomberman.Entities.Items
{
    /// <summary>
    /// Represents a chest that wen discovered and claimed will add a random amount of points to the score.
    /// </summary>
    internal class Chest : Entity, Explodable
    {
        /// <summary>
        /// Represents the value of the chest in score points.
        /// </summary>
        public int Value { get; private init; }

        public Chest() : base()
        {
            Random r = new Random(1234);
            Value = r.Next(1, 5) * 100;
        }
        public override ImageID ImageID { get => ImageID.Chest; }
    }
}
