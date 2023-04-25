using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.LevelVisualization
{
    /// <summary>
    /// Represents any possible image that can represent entity in the level map.
    /// </summary>
    internal enum ImageID
    {
        Empty, Wall, Hero, CalmMonster, RagingMonster, DestroyableWall, Freezer, Chest, Key, ClosedExit, OpenExit, LandMine, BasicBomb, Explosion, ExploMonster, ExploWall, ExploHero, BombHero, FullMonster, UpBooster, AntiBooster
    }
}
