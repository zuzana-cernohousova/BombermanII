using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Game
{
    /// <summary>
    /// Represents the phase of the game. Used to easily change window appearance and control functionality.
    /// </summary>
    internal enum Phase
    {
        home, level, pause, levelWon, levelLost, gameWon, gameLost, about
    }
}
