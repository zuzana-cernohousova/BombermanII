using Bomberman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.LevelVisualization
{
    /// <summary>
    /// Class used to create a string representation of a map.
    /// </summary>
    class MapPrinter
    {
        static string PrintMap(Entity[,] map)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    ImageID id = map[i, j].ImageID;


                    char ch = ' ';

                    switch (id)
                    {
                        case ImageID.Empty:
                            ch = '.';
                            break;
                        case ImageID.Wall:
                            ch = 'W';
                            break;
                        case ImageID.Hero:
                            ch = 'h';

                            break;
                        case ImageID.CalmMonster:
                            ch = 'm';

                            break;
                        case ImageID.RagingMonster:
                            ch = 'M';

                            break;
                        case ImageID.DestroyableWall:
                            ch = 'w';
                            break;
                        case ImageID.Freezer:
                            ch = 's';
                            break;
                        case ImageID.Chest:
                            ch = 'c';
                            break;
                        case ImageID.Key:
                            ch = 'k';
                            break;
                        case ImageID.ClosedExit:
                            ch = 'e';
                            break;
                        case ImageID.OpenExit:
                            ch = 'E';
                            break;
                        case ImageID.LandMine:
                            ch = 'l';
                            break;
                        case ImageID.BasicBomb:
                            ch = 'b';
                            break;
                        case ImageID.Explosion:
                            ch = 'X';
                            break;
                        case ImageID.ExploMonster:
                            ch = 'x';
                            break;
                        case ImageID.ExploWall:
                            ch = 'x';
                            break;

                    }

                    sb.Append(ch);
                }
                sb.Append('\n');

            }
            return sb.ToString();
        }
    }
}
