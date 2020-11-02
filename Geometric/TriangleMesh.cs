using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Wielokaty;

namespace Oswietlenie.Geometric
{
    class TriangleMesh: IDisposable
    {
        private ReferencePoint[,] mesh;
        private int PointHeight;
        private int PointWidth;
        private int Height;
        private int Width;
        private Point Position;

        public TriangleMesh(Point position, int width, int height, int pointsHeight, int pointsWidth)
        {
            Position = position;
            PointWidth = pointsWidth;
            PointHeight = pointsHeight;
            Width = width;
            Height = height;
            mesh = new ReferencePoint[PointHeight, PointWidth];

            int dx = width / (PointWidth - 1);
            int dy = height / (PointHeight - 1);
            for (int row = 0; row < PointHeight; ++row)
            {
                for (int col = 0; col < PointWidth; ++col)
                    mesh[row, col] = new ReferencePoint(Position.X + col * dx, Position.Y + row * dy);
            }

            BitmapOperator.Instance.RegisterTriangleMesh(this);
        }

        public void Dispose()
        {
            BitmapOperator.Instance.UnregisterTriangleMesh(this);
        }

        public void Draw(DirectBitmap bitmap)
        {
            for (int row = 0; row < PointHeight - 1; ++row)
            {
                for (int col = 0; col < PointWidth - 1; ++col)
                {
                    bitmap.DrawLine(mesh[row, col], mesh[row, col + 1]);
                    bitmap.DrawLine(mesh[row, col], mesh[row + 1, col]);
                    bitmap.DrawLine(mesh[row, col], mesh[row + 1, col + 1]);
                }
            }

            for (int row = 0; row < PointHeight - 1; ++row)
                bitmap.DrawLine(mesh[row, PointWidth - 1], mesh[row + 1, PointWidth - 1]);
            for (int col = 0; col < PointWidth - 1; ++col)
                bitmap.DrawLine(mesh[PointHeight - 1, col], mesh[PointHeight - 1, col + 1]);

            for (int row = 0; row < PointHeight; ++row)
            {
                for (int col = 0; col < PointWidth; ++col)
                    mesh[row, col].Draw(bitmap);
            }
        }

        public bool Collides(Point p, out ReferencePoint point)
        {
            for (int row = 0; row < PointHeight; ++row)
            {
                for (int col = 0; col < PointWidth; ++col)
                    if (mesh[row, col].Collide(p))
                    {
                        point = mesh[row, col];
                        return true;
                    }
            }

            point = null;
            return false;
        }
    }
}
