using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.Entities;
using Bomberman.Entities.Items;

namespace Bomberman.Level
{
    /// <summary>
    /// Represents the level map before the time to build it.
    /// Is abstract, child classes represent different ways to build the level map.
    /// </summary>
    internal abstract class MapFactory
    {
        protected Hero hero;
        protected Exit exit;
        protected Level level;
        protected List<Monster> monsters = new();

        public MapFactory()
        {
        }
        internal void SetLevel(Level level)
        {
            this.level = level;
        }

        /// <summary>
        /// Returns a map filled with the correct entities created by child class specific procedures.
        /// </summary>
        /// <returns>A two dimensional array of entities representing stuff in a map.</returns>
        internal abstract Entity[,] getMap();

        /// <summary>
        /// Builds a two dimensional array of entities from a two dimensional array of characters representing the entities.
        /// </summary>
        /// <param name="template">A two dimensional array of characters representing a map.</param>
        /// <returns></returns>
        protected Entity[,] BuildMapFromTemplate(char[,] template)
        {
            int rowNum = template.GetLength(0);
            int columnNum = template.GetLength(1);

            Entity[,] res = new Entity[template.GetLength(0), template.GetLength(1)];
            monsters.Clear();

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < columnNum; j++)
                {
                    switch (template[i, j])
                    {
                        case '.':
                            res[i, j] = new Empty();
                            break;
                        case 'w':
                            res[i, j] = new Wall();
                            break;
                        case 'h':
                            hero = new Hero(level, i, j);
                            res[i, j] = hero;
                            break;
                        case 'm':
                            Monster monster = new Monster(level, i, j);
                            res[i, j] = monster;
                            monsters.Add(monster);
                            break;
                        case 'd':
                            res[i, j] = new DestroyableWall(new Empty());
                            break;
                        case 's':
                            res[i, j] = new DestroyableWall(new UpBooster());
                            break;
                        case 'a':
                            res[i, j] = new DestroyableWall(new AntiBooster());
                            break;
                        case 'f':
                            res[i, j] = new DestroyableWall(new Freezer());
                            break;
                        case 'c':
                            res[i, j] = new DestroyableWall(new Chest());
                            break;
                        case 'k':
                            res[i, j] = new DestroyableWall(new Key());
                            break;
                        case 'e':
                            exit = new Exit();
                            res[i, j] = new DestroyableWall(exit);
                            break;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Returns the hero from the map that was just created.
        /// </summary>
        /// <returns>An instance of <see cref="Hero"> contained in the current map.</returns>
        internal virtual Hero GetHero()
        {
            return hero;
        }

        /// <summary>
        /// Returns the exit from the map that was just created.
        /// </summary>
        /// <returns>An instance of <see cref="Exit"> contained in the current map.</returns>
        internal Exit GetExit()
        {
            return exit;
        }

        /// <summary>
        /// Returns a list of all the monsters from the map that was just created.
        /// </summary>
        /// <returns>An instance of a List of <see cref="Monster"> entities contained in the current map.</returns>
        internal List<Monster> GetMonsters()
        {
            return monsters;
        }
    }

    /// <summary>
    /// Takes care of building the level map from a template stored in a file.
    /// </summary>
    internal class FileMapFactory : MapFactory
    {
        readonly string fileName;
        char[,] template;

        public FileMapFactory(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Returns a two dimensional array of entities representing a map created according to template stored in the <see cref="template">.
        /// If the template was not yet created, creates the template.
        /// </summary>
        /// <returns>A two dimensional array of entities.</returns>
        internal override Entity[,] getMap()
        {
            if (template is null)
            {
                template = BuildTemplate();
            }

            return BuildMapFromTemplate(template);
        }

        /// <summary>
        /// Builds a template (two dimensional array of characters) of a map from a file.
        /// File name is stored in the <see cref="fileName"> field.
        /// </summary>
        /// <returns></returns>
        private char[,] BuildTemplate()
        {
            char[,] res;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string? line;
                int row = int.Parse(reader.ReadLine().Replace("\n", ""));
                int col = int.Parse(reader.ReadLine().Replace("\n", ""));

                res = new char[row, col];

                int r = 0;
                int c = 0;
                while ((line = reader.ReadLine()) is not null)
                {
                    c = 0;

                    line.Replace("\n", "");
                    foreach (char ch in line)
                    {
                        res[r, c] = ch;
                        c++;

                        if (c == col) break;
                    }
                    r++;
                    if (r == row) break;
                }
            }

            return res;
        }
    }

    /// <summary>
    /// Takes care of building the level map from a template stored in a file.
    /// </summary>
    internal class RandomMapFactory : MapFactory
    {
        readonly int seed;
        char[,] template;

        public RandomMapFactory(int seed)
        {
            this.seed = seed;
        }

        /// <summary>
        /// Returns a two dimensional array of entities representing a map created according to template stored in the <see cref="template">.
        /// If the template was not yet created, creates the template using the <see cref="RandomMapGenerator"> <see cref="mapGenerator">.
        /// </summary>
        /// <returns>A two dimensional array of entities.</returns>
        internal override Entity[,] getMap()
        {
            if (template is null)
            {
                Random r = new Random(1234);
                int rows = 15;
                int cols = 31;

                int min = rows * cols / 50;
                int max = cols * rows / 40;

                template = RandomMapGenerator.GetMap(seed, rows, cols, r.Next(min, max));
            }

            return BuildMapFromTemplate(template);
        }
    }
}
