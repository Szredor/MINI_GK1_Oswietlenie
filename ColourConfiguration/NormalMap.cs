using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using Wielokaty;

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
                        texture [y * width + x] = Vector3.Normalize(new Vector3((px.R - 128) / 255.0f, (px.G - 128) / 255.0f, (px.B) / 255.0f));
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

    public class WaveNormalMap : INormalMap
    {
        private int x0;
        private int y0;

        public WaveNormalMap(int width, int height)
        {
            x0 = width / 2;
            y0 = height / 2;
        }

        public Vector3 GetNormalMap(Point p)
        {
            //Obliczam pochodna funkcji f(x,y) = cos(srqt(x^2 + y^2))
            float x = (p.X - x0) / BitmapOperator.Instance.WaveDistance;
            float y = (p.Y - y0) / BitmapOperator.Instance.WaveDistance;

            double part1 = Math.Sqrt(x * x + y * y);
            double part2 = Math.Cos(part1) / part1 ;

            //N = ||(-df/dx, -df/dy, 1)||
            return Vector3.Normalize(new Vector3((float)(-part2 * x), (float)(-part2 * y), 1));
        }
    }
}
