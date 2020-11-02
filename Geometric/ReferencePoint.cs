using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Wielokaty;

namespace Oswietlenie.Geometric
{
    class ReferencePoint
    {
        public Point Position { get; set; }
        public int Size { get; set; } = 1;
        public Color Colour { get; set; } = Color.Black;

        public ReferencePoint(int x, int y)
        {
            Position = new Point(x, y);
        }

        public ReferencePoint(Point p)
        {
            Position = p;
        }

        public void Draw(DirectBitmap bitmap)
        {
            bitmap.DrawPoint(Position, Size, Colour);
        }

        public bool Collide(Point p)
        {
            return p.X <= Position.X + Size + BitmapOperator.CollideMargin &&
                p.X >= Position.X - Size - BitmapOperator.CollideMargin &&
                p.Y <= Position.Y + Size + BitmapOperator.CollideMargin &&
                p.Y >= Position.Y - Size - BitmapOperator.CollideMargin;
        }

        public static implicit operator Point(ReferencePoint p) => p.Position;
    }
}
