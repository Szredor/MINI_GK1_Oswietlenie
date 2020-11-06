using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Wielokaty;

namespace Oswietlenie.Geometric
{
    public class TriangleMesh: IDisposable
    {
        private ReferencePoint[,] mesh;
        private Triangle[] triangles;
        private int rows;
        private int cols;

        public TriangleMesh(Point position, int width, int height, int pointsHeight, int pointsWidth)
        {
            cols = pointsWidth;
            rows = pointsHeight;
            mesh = new ReferencePoint[rows, cols];

            int dx = width / (cols - 1);
            int dy = height / (rows - 1);
            for (int row = 0; row < rows; ++row)
            {
                for (int col = 0; col < cols; ++col)
                    mesh[row, col] = new ReferencePoint(position.X + col * dx, position.Y + row * dy);
            }

            List<Triangle> ts = new List<Triangle>();
            for (int row = 0; row < rows - 1; ++row)
            {
                for (int col = 0; col < cols - 1; ++col)
                {
                    ts.Add(new Triangle(mesh[row, col], mesh[row + 1, col], mesh[row, col + 1]));
                    ts.Add(new Triangle(mesh[row + 1, col + 1], mesh[row + 1, col], mesh[row, col + 1]));
                }
            }

            triangles = ts.ToArray();
            BitmapOperator.Instance.RegisterTriangleMesh(this);
        }

        public void Dispose()
        {
            BitmapOperator.Instance.UnregisterTriangleMesh(this);
        }

        public void Draw(DirectBitmap bitmap)
        {
            for (int row = 0; row < rows - 1; ++row)
            {
                for (int col = 0; col < cols - 1; ++col)
                {
                    bitmap.DrawLine(mesh[row, col], mesh[row, col + 1]);
                    bitmap.DrawLine(mesh[row, col], mesh[row + 1, col]);
                    bitmap.DrawLine(mesh[row+1, col], mesh[row, col + 1]);
                }
            }

            for (int row = 0; row < rows - 1; ++row)
                bitmap.DrawLine(mesh[row, cols - 1], mesh[row + 1, cols - 1]);
            for (int col = 0; col < cols - 1; ++col)
                bitmap.DrawLine(mesh[rows - 1, col], mesh[rows - 1, col + 1]);

            for (int row = 0; row < rows; ++row)
            {
                for (int col = 0; col < cols; ++col)
                    mesh[row, col].Draw(bitmap);
            }
        }

        public void Fill(DirectBitmap bitmap, IColourModel model)
        {
            foreach (Triangle trian in triangles)
                trian.Fill(bitmap, model);
        }

        public void FillParalell(DirectBitmap bitmap, IColourModel model)
        {
            Parallel.ForEach(triangles, (trian) => trian.Fill(bitmap, model));
        }

        public bool Collides(Point p, out ReferencePoint point)
        {
            for (int row = 0; row < rows; ++row)
            {
                for (int col = 0; col < cols; ++col)
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
