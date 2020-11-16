using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Wielokaty;

namespace Oswietlenie.Geometric
{
    public class Triangle
    {
        private static int id_counter = 1;
        public readonly int id = ++id_counter;
        public ReferencePoint[] points = new ReferencePoint[3];
        public IColourModel colourModel;

        public Triangle(ReferencePoint p1, ReferencePoint p2, ReferencePoint p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }

        public void SetColourModel(IColourModel model)
        {   
            colourModel = model.CreateCopy();
            colourModel.SetTriangleContext(this);
        }

        public void Fill(DirectBitmap bitmap, IColourModel model)
        {
            ActiveLineList aet = new ActiveLineList(points);

            List<Point> scanLine;
            while (aet.Increment())
            {
                scanLine = aet.GetPointsOnScanLine();
                var it = scanLine.GetEnumerator();
                while (it.MoveNext())
                {
                    Point one = it.Current;
                    it.MoveNext();
                    Point two = it.Current;
                    for (int x = one.X; x <= two.X; ++x)
                        bitmap.SetPixel(x, one.Y, colourModel.GetColor(new Point(x, one.Y)));
                }
            }
        }
    }
}
