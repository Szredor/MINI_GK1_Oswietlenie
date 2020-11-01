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
        public Color Colour { get; set; } = Color.Black;

        public Triangle(ReferencePoint p1, ReferencePoint p2, ReferencePoint p3)
        {
            points[0] = p1;
            points[1] = p2;
            points[2] = p3;
        }
    }
}
