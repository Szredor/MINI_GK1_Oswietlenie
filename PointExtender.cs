using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace Wielokaty
{
    static class PointExtender
    {
        public static Point Add(this Point A, Point B) => new Point(A.X + B.X, A.Y + B.Y);
        public static Point Substract(this Point A, Point B) => new Point(A.X - B.X, A.Y - B.Y);
        public static Point Multiply(this Point A, int alfa) => new Point(A.X * alfa, A.Y * alfa);
        public static Point Multiply(this Point A, double alfa) => new Point((int)(A.X * alfa), (int)(A.Y * alfa));
        public static Point Divide(this Point A, int alfa) => new Point(A.X / alfa, A.Y / alfa);
        public static Point Divide(this Point A, double alfa) => new Point((int)(A.X / alfa), (int)(A.Y / alfa));
        public static int DotProduct(this Point A, Point B) => A.X * B.X + A.Y * B.Y;
        public static int CrossProduct(this Point A, Point B) => A.X * B.Y - B.X * A.Y;
        public static Point ChangeLength(this Point A, int length) => A.Multiply(length).Divide(A.EuclideanMeasureInt() == 0 ? 1 : A.EuclideanMeasureInt());
        public static Point PerpendicularClockwise(this Point A) => new Point(A.Y, -A.X);
        public static Point PerpendicularAnticlockwise(this Point A) => new Point(-A.Y, A.X);
        public static Point Oposite(this Point A) => new Point(-A.X, -A.Y);
        public static Point Rotate(this Point A, double cosTheta, double sinTheta) =>
            new Point((int)(A.X * cosTheta - A.Y * sinTheta), (int)(A.X * sinTheta + A.Y * cosTheta));
        public static Point Rotate(this Point A, int angle) => Rotate(A, Math.Cos(angle * Math.PI / 180), Math.Sin(angle * Math.PI / 180));
        public static double EuclideanMeasure(this Point A) => Math.Sqrt(A.X * A.X + A.Y * A.Y);
        public static int EuclideanMeasureInt(this Point A) => (int)Math.Floor(EuclideanMeasure(A));
        public static (double r, double fi) ToPolar(this Point A) => (A.EuclideanMeasure(), Math.Atan2(A.Y, A.X));
        public static Point FromPolar(double r, double fi) => new Point((int)(r * Math.Cos(fi)), (int)(r * Math.Sin(fi)));
    }
}
