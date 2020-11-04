using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Wielokaty;

namespace Oswietlenie.Geometric
{
    class Triangle
    {
        private ReferencePoint[] points = new ReferencePoint[3];

        public Triangle(ReferencePoint p1, ReferencePoint p2, ReferencePoint p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }

        public void Fill(DirectBitmap bitmap, ColourModel model)
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
                        bitmap.SetPixel(x, one.Y, model.GetColor(new Point(x, one.Y)));
                }
            }
        }
    }
}
