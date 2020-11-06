using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Oswietlenie.ColourConfiguration
{
    public interface INormalMap
    {
        Vector3 GetNormalMap(Point p);
    }

    public class StaticNormalMap : INormalMap
    {
        private Vector3 vec;

        public StaticNormalMap(Vector3 v)
        {
            float len = v.Length();
            vec = new Vector3(v.X / len, v.Y / len, v.Z / len);
        }

        public Vector3 GetNormalMap(Point p)
        {
            return vec;
        }
    }

    public class TextureNormalMap : INormalMap
    {
        private Vector3[] texture;
        private int width;
        private int height;

        public TextureNormalMap(string texturePath)
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
                        texture [y * width + x] = Vector3.Normalize(new Vector3((px.R - 128) / 255.0f, (px.G - 128) / 255.0f, (float)(px.R) / 255.0f));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public Vector3 GetNormalMap(Point p)
        {
            return texture[(p.Y % height) * width + (p.X % width)];
        }
    }
}
