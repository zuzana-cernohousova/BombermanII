using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Bomberman.Entities;

namespace Bomberman.Level
{
    /// <summary>
    /// Creates a template for a level map. The entities are represented by special characters as follows:
    /// <see cref="Empty"/> - '.', <see cref="Wall"/> - 'w', <see cref="Hero"/> - 'h', <see cref="Monster"/> - 'm', <see cref="Entities.DestroyableWall"/> - 'd', <see cref="Entities.Items.UpBooster"/> - 's', <see cref="Entities.Items.AntiBooster"/> - 'a', <see cref="Entities.Items.Freezer"/> - 'f', <see cref="Entities.Items.Chest"/> - 'c', <see cref="Entities.Items.Key"/> - 'k', <see cref="Entities.Items.Exit"/> - 'e'
    /// </summary>
    internal class RandomMapGenerator
    {
        static Random r;

        const int wallProb = 5;
        const int desWallProb = 4;
        const int itemsProb = 2;

        const char empty = '.';
        const char wall = 'w';
        const char hero = 'h';
        const char monster = 'm';
        const char desWall = 'd';
        const char upBooster = 's';
        const char antibooster = 'a';
        const char freezer = 'f';
        const char chest = 'c';
        const char key = 'k';
        const char exit = 'e';



        /// <summary>
        /// Builds and returns a random valid map of set dimensions if the dimensions are greater than 11, else the dimenstion will be 11x11.
        /// If any dimension is even, 1 is subtracted.
        /// Map will contain the specified number of monsters.        
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        /// <param name="monstersNum">Number of monsters, that should be present in the map. If the number is too high, will be replaced with more reasonable value according to the map dimensions.</param>
        /// <returns>A two dimensional array of characters representing a level map.</returns>
        public static char[,] GetMap(int seed, int rows, int columns, int monstersNum)
        {
            r = new Random(seed);
            return BuildMap(rows, columns, monstersNum);
        }

        /// <summary>
        /// Builds a random valid map of set dimensions if the dimensions are greater than 11, else the dimenstion will be 11x11.
        /// If any dimension is even, 1 is subtracted.
        /// Map will contain the specified number of monsters.
        /// The map is stored in the map field.
        /// On coordinates where both coordinates are odd there is always a wall (rigid or destroyable).
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        /// <param name="monstersNum">Number of monsters, that should be present in the map. If the number is too high, will be replaced with more reasonable value according to the map dimensions</param>
        static char[,] BuildMap(int rows, int columns, int monstersNum)
        {

            // make number of rows and number of columns odd numbers
            #region fix numbers of rows and columns
            if (rows < 11) { rows = 11; }
            if (columns < 11) { columns = 11; }

            if (rows % 2 == 0) { rows--; }
            if (columns % 2 == 0) { columns--; }

            if (rows > 17) { rows = 17; }
            if (columns > 29) { columns = 29; }
            #endregion

            char[,] map = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    // add mandatory rigid walls
                    if (row == 0 || row == rows - 1 || col == 0 || col == columns - 1 || row % 2 == 0 && col % 2 == 0)
                    {
                        map[row, col] = wall;
                        continue;
                    }

                    // add some wall
                    if (r.Next(10) < wallProb)
                    {
                        // add destroyable wall or objects hidden under destroyable walls with certain probability
                        if (r.Next(10) < desWallProb)
                        {
                            map[row, col] = desWall;
                            continue;
                        }
                        if (r.Next(10) < itemsProb)
                        {
                            map[row, col] = chest;
                            continue;
                        }
                        if (r.Next(10) < itemsProb / 2)
                        {
                            map[row, col] = upBooster;
                            continue;
                        }
                        if (r.Next(10) < itemsProb / 2)
                        {
                            map[row, col] = antibooster;
                            continue;
                        }
                        if (r.Next(10) < itemsProb)
                        {
                            map[row, col] = freezer;
                            continue;
                        }
                    }

                    map[row, col] = empty;
                }
            }


            // add hero
            (int heroRow, int heroCol) = getNotAllwaysWallCoords(rows, columns);
            map[heroRow, heroCol] = hero;
            MakeRoomForHero(map, heroRow, heroCol);


            // add monsters
            (int, int)[] monstersCoords = getMonstersCoords(rows, columns, monstersNum, (heroRow, heroCol));

            foreach ((int mrow, int mcol) in monstersCoords)
            {
                map[mrow, mcol] = monster;
            }

            // add key
            (int keyRow, int keyCol) = getNotAllwaysWallCoords(rows, columns);
            while (keyRow == heroRow && keyCol == heroCol)
            {
                (keyRow, keyCol) = getNotAllwaysWallCoords(rows, columns);
            }
            map[keyRow, keyCol] = key;

            // add exit
            (int exitRow, int exitCol) = getNotAllwaysWallCoords(rows, columns);
            while (exitRow == heroRow && exitCol == heroCol || exitRow == keyRow && exitCol == keyCol)
            {
                (exitRow, exitCol) = getNotAllwaysWallCoords(rows, columns);
            }
            map[exitRow, exitCol] = exit;

            return map;
        }

        /// <summary>
        /// Changes the <paramref name="map"/> to make sure hero on the given coordinates will be able to move and excape the first bomb firing.
        /// </summary>
        /// <param name="map">The map to be changed, so that the hero could survive first bomb firing.</param>
        /// <param name="row">Row of the hero</param>
        /// <param name="col">Column of the hero</param>
        static private void MakeRoomForHero(char[,] map, int row, int col)
        {
            // hero on even, even
            if (row % 2 == 1 && col % 2 == 1)
            {
                if (row == 1) // at the top of the map
                {
                    if (col == 1) // at the leftmost side of the map
                    {
                        map[row + 1, col] = empty;
                        map[row, col + 1] = empty;
                        return;
                    }
                    // not at the leftmost side of the map --> to the left --> not index out of normalRange (can go left)
                    map[row + 1, col] = empty;
                    map[row, col - 1] = empty;
                    return;
                }

                if (col == 1) // at the leftmost side of the map
                {
                    map[row - 1, col] = empty;
                    map[row, col + 1] = empty;
                    return;
                }

                map[row - 1, col] = empty;
                map[row, col - 1] = empty;
                return;
            }

            // row odd -> walls on left and right (or one of the sides if on the edge)
            if (row % 2 == 0)
            {
                // even -> can go up 
                // only check if col ok

                if (col == 1)
                {
                    map[row - 1, col] = empty;
                    map[row - 1, col + 1] = empty;
                    return;
                }
                map[row - 1, col] = empty;
                map[row - 1, col - 1] = empty;
                return;
            }

            // col odd (same as row odd)
            if (row == 1)
            {
                map[row, col - 1] = empty;
                map[row + 1, col - 1] = empty;
                return;
            }
            map[row, col - 1] = empty;
            map[row - 1, col - 1] = empty;

            // cannot be both odd, always wall
        }

        /// <summary>
        /// Returns <paramref name="N"/> different tuples of valid coordinates for placing monsters. Will place monsters only far enough from hero.
        /// </summary>
        /// <param name="rows">Number of rows in the map</param>
        /// <param name="columns">Number of columns in the map</param>
        /// <param name="N">Number of monsters that should be placed. If the number is too high, will be replaced with more reasonable value according to the map dimensions.</param>
        /// <param name="heroCoords">Represents the coordinates of previously placed hero</param>
        /// <returns>One dimensional array of tuples of two integers where the first int represents the row coordinate and the second the column coordinate.</returns>
        static (int, int)[] getMonstersCoords(int rows, int columns, int N, (int row, int col) heroCoords)
        {
            if (N > rows * columns / 4 + (rows + columns - 1))
            {
                N = (rows * columns / 4 + (rows + columns - 1)) / 4;
            }

            (int, int)[] res = new (int, int)[N];
            for (int i = 0; i < N; i++)
            {
                (int row, int col) newCoords = getNotAllwaysWallCoords(rows, columns);

                while (res.Contains(newCoords))
                {
                    newCoords = getNotAllwaysWallCoords(rows, columns);
                }
                while (Math.Abs(newCoords.row - heroCoords.row) < 3 || Math.Abs(newCoords.col - heroCoords.col) < 3)
                {
                    newCoords = getNotAllwaysWallCoords(rows, columns);
                }

                res[i] = newCoords;
            }
            return res;
        }

        /// <summary>
        /// Returns coordinates of a random place where there should not always be a wall.
        /// </summary>
        /// <param name="rows">Number of rows in map</param>
        /// <param name="columns">Number of columns in map</param>
        /// <returns>A tuple of two integers, where the first one represents the row coordinate and the second the column coordinate.</returns>
        static (int, int) getNotAllwaysWallCoords(int rows, int columns)
        {
            int row = r.Next(rows);
            int column = r.Next(columns);


            while (row == 0 || row == rows - 1 || column == 0 || column == columns - 1 || row % 2 == 0 && column % 2 == 0) // if both coords are odd get new ones
            {
                if (r.Next(2) == 1)
                {
                    row = r.Next(rows);
                }
                else
                {
                    column = r.Next(columns);
                }
            }

            return (row, column);
        }

        /// <summary>
        /// Creates a string from the two dimensional character array stored in the <paramref name="map"/> parameter.
        /// </summary>
        /// <param name="map">The map to be printed.</param>
        /// <returns>A string containing the map.</returns>
        public string PrintToString(char[,] map)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    sb.Append(map[i, j]);
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}
