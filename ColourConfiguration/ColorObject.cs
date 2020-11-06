using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Oswietlenie.ColourConfiguration
{
    public interface IColourObject
    {
        Vector3 GetColorObject(Point p);
    }

    public class SolidColor : IColourObject
    {
        private Vector3 colour;

        public SolidColor(Color colour)
        {
            this.colour = new Vector3(colour.R/255.0f, colour.G/ 255.0f, colour.B/ 255.0f);
        }

        public Vector3 GetColorObject(Point p)
        {
            return colour;
        }
    }

    public class TextureColor : IColourObject
    {
        private Vector3[] texture;
        private int width;
        private int height;

        public TextureColor(string texturePath)
        {
            try
            {
                Bitmap bmp = (Bitmap)Image.FromFile(texturePath);
                width = bmp.Width;
                height = bmp.Height;
                texture = new Vector3[width * height];
                for (int y = 0; y < bmp.Height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        Color px = bmp.GetPixel(x, y);
                        texture [y * width + x] = new Vector3(px.R / 255.0f, px.G / 255.0f, px.B / 255.0f);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public Vector3 GetColorObject(Point p)
        {
            return texture[(p.Y % height) * width + (p.X % width)];
        }
    }
}
