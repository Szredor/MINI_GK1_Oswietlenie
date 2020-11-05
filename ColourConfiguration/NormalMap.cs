using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Oswietlenie.ColourConfiguration
{
    interface INormalMap
    {
        Vector3 GetNormalMap(Point p);
    }

    class StaticNormalMap : INormalMap
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

    class TextureNormalMap : INormalMap
    {
        public Bitmap texture;

        public TextureNormalMap(string texturePath)
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

        private int Scale(int val, int a, int b)
        {
            if (val <= a)
                return a;
            if (val >= b)
                return b;
            return a + (val - a) * (b - a) / (b - a);
        }

        public Vector3 GetNormalMap(Point p)
        {
            Color col = texture.GetPixel(p.X, p.Y);
            return new Vector3((float)(col.R - 128) / 255, (float)(col.G - 128) / 255, (float)(col.R) / 255);
        }
    }
}
