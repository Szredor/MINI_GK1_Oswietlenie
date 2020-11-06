using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using Wielokaty;

namespace Oswietlenie.Geometric
{
    public class ReferencePoint
    {
        public Vector3 Position { get; set; }
        public int Size { get; set; } = 1;
        public Color Colour { get; set; } = Color.Black;

        public ReferencePoint(int x, int y, int z = 0)
        {
            Position = new Vector3(x, y, z);
        }

        public ReferencePoint(Point p)
        {
            Position = new Vector3(p.X, p.Y, 0);
        }

        public ReferencePoint(Vector3 v)
        {
            Position = v;
        }

        public void Draw(DirectBitmap bitmap)
        {
            bitmap.DrawPoint(this, Size, Colour);
        }

        public bool Collide(Point p)
        {
            return p.X <= Position.X + Size + BitmapOperator.CollideMargin &&
                p.X >= Position.X - Size - BitmapOperator.CollideMargin &&
                p.Y <= Position.Y + Size + BitmapOperator.CollideMargin &&
                p.Y >= Position.Y - Size - BitmapOperator.CollideMargin;
        }

        public static implicit operator Point(ReferencePoint p) => new Point((int)p.Position.X, (int)p.Position.Y);
        public static implicit operator Vector3(ReferencePoint p) => p.Position;
    }
}
