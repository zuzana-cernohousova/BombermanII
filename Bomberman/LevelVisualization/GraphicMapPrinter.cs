using Bomberman.Entities;
using Bomberman.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.LevelVisualization
{
    /// <summary>
    /// Creates a visual representation of the level map. 
    /// </summary>
    internal class GraphicMapPrinter
    {
        PictureBox[,]? PictureBoxMap;

        Panel panel = new();
        BombermanForm bf;

        int imageHeight = 0;
        int imageWidth = 0;

        Dictionary<ImageID, Image> images = new();

        /// <summary>
        /// Creates a new instance of the <see cref="GraphicMapPrinter"/> class.
        /// </summary>
        /// <param name="bf">The BombermanForm the level will be displayed in.</param>
        /// <param name="rows">Number of rows of the level.</param>
        /// <param name="columns">Number of columns of the level.</param>
        public GraphicMapPrinter(BombermanForm bf, int rows, int columns)
        {
            this.bf = bf;
            CreatePictureBoxes(rows, columns);
        }


        /// <summary>
        /// Sets <see cref="imageHeight"/> and <see cref="imageWidth"/> by analyzing one of the pictures.
        /// </summary>
        void GetPictureDimensions()
        {
            Image hero = Resources.Hero;

            imageHeight = hero.Height;
            imageWidth = hero.Width;
        }

        /// <summary>
        /// Creates a two dimensional array of <paramref name="rows"/> x <paramref name="cols"/> instances of <see cref="PictureBox"/> and sets their dimensions.
        /// </summary>
        /// <param name="rows">Number of rows in level map.</param>
        /// <param name="cols">Number of columns in level map.</param>
        void CreatePictureBoxes(int rows, int cols)
        {
            PictureBox[,] res = new PictureBox[rows, cols];

            GetPictureDimensions();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    PictureBox box = new();
                    box.Width = imageWidth;
                    box.Height = imageHeight;

                    // x - horizontal, from left to right
                    // y - vertical, from top to bottom

                    box.Location = new Point(
                        10 + imageWidth * c,
                        10 + imageHeight * r
                        );

                    res[r, c] = box;
                }
            }
            PictureBoxMap = res;
        }

        /// <summary>
        /// Puts correct pictures into picterboxes according to the <paramref name="map"/>.
        /// </summary>
        /// <param name="map">Map of entities representig the current state of the current level.</param>
        internal void UpdatePictures(Entity[,] map)
        {
            for (int r = 0; r < map.GetLength(0); r++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    Entity e = map[r, c];

                    if (!images.ContainsKey(e.ImageID))
                    {
                        GetPictureFromResources(e.ImageID);
                    }

                    PictureBoxMap[r, c].Image = images[e.ImageID];
                }
            }
        }

        void GetPictureFromResources(ImageID imageID)
        {
            object? o = Resources.ResourceManager.GetObject(imageID.ToString());
            if (o is not null)
            {
                if (o is Image)
                {
                    images[imageID] = (Image)o;
                }
            }
        }

        /// <summary>
        /// Adds a Panel containing all the PictureBoxes into the BombermanForm so that they can be shown.
        /// </summary>
        internal void AddGraphicsToForm()
        {
            panel.Location = new Point(0, 0);
            panel.Height = bf.Height;
            panel.Width = bf.Width;

            for (int r = 0; r < PictureBoxMap.GetLength(0); r++)
            {
                for (int c = 0; c < PictureBoxMap.GetLength(1); c++)
                {
                    panel.Controls.Add(PictureBoxMap[r, c]);

                }
            }

            bf.Controls.Add(panel);
        }

        /// <summary>
        /// Removes the panel from the BombermanForm so that they dont show and new ones (for a new level) can be displayed.
        /// </summary>
        internal void RemoveGraphicsFromForm()
        {
            bf.Controls.Remove(panel);
        }


        /// <summary>
        /// Hides the level graphics by setting the panels Visible property to <see langword="false"/>.
        /// </summary>
        internal void HideGraphics()
        {
            panel.Visible = false;
            return;
        }


        /// <summary>
        /// Shows the level graphics by setting the panels Visible property to <see langword="true"/>.
        /// </summary>
        internal void ShowGraphics()
        {
            panel.Height = bf.Height;
            panel.Width = bf.Width;
            panel.Visible = true;

            return;
        }

        /// <summary>
        /// Returns the dimensions of level map in pixels
        /// </summary>
        /// <returns>A tupple of two ints, where the first int signifies the height and the second int signifies the width of the level map in pixels</returns>
        internal (int, int) GetSizeOfGame()
        {
            return (PictureBoxMap.GetLength(0) * imageHeight, PictureBoxMap.GetLength(1) * imageWidth);
        }

    }
}
