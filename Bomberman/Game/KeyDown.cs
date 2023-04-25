using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Game
{
    /// <summary>
    /// Represents which of the significant keys is currently being pressed. No key being pressed is represented by the <see cref="KeyDown.None"/> option.
    /// </summary>
    internal enum KeyDown
    {
        Left, Up, Right, Down, B, M, None
    }
}
