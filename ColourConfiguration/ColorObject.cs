using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Oswietlenie.ColourConfiguration
{
    interface IColourObject
    {
        Vector3 GetColorObject(Point p);
    }

    class SolidColor : IColourObject
    {
        private Color colour;

        public SolidColor(Color colour)
        {
            this.colour = colour;
        }

        public Vector3 GetColorObject(Point p)
        {
            return new Vector3(colour.R, colour.G, colour.B);
        }
    }

    class TextureColor : IColourObject
    {
        public Bitmap texture;

        public TextureColor(string texturePath)
        {
            try
            {
                texture = (Bitmap)Image.FromFile(texturePath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public Vector3 GetColorObject(Point p)
        {
            Color px = texture.GetPixel(p.X, p.Y);
            return new Vector3(px.R, px.G, px.B);
        }
    }
}
