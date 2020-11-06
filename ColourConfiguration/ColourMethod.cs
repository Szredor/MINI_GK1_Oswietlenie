using Oswietlenie.Geometric;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Wielokaty;

namespace Oswietlenie.ColourConfiguration
{

    public struct ColourData
    {
        public Vector3 Il;
        public Vector3 Io;
        public Vector3 L;
        public Vector3 N;
        public float kd;
        public float ks;
        public int m;
    }

    public class AcurateLambertMethod
    {
        protected readonly Vector3 V = new Vector3(0, 0, 1);

        protected float cosNL;
        protected float cosVR;
        protected ColourData cdata;

        public virtual Color CalculateColour(ColourData data)
        {
            cdata = data;
            Vector3 N = data.N;
            Vector3 L = data.L;
            cosNL = Vector3.Dot(N, L);
            float mulitplier = cosNL * 2;
            cosVR = (float)Math.Pow(2 * cosNL * N.Z - L.Z, data.m);//Wynikiem <V, R> bedzie zawsze ostania współrzedna R, ponieważ, V = [0, 0, 1];

            int r, g, b;
            //Obliczenie składowej R
            float lambert = cdata.kd * data.Il.X * data.Io.X * cosNL * 255;
            float mirror = cdata.ks * data.Il.X * data.Io.X * cosVR * 255;
            int result = (int)(lambert + mirror);
            if (result < 0)
                r = 0;
            else if (result > 255)
                r = 255;
            else r = result;

            //Obliczenie składowej G
            lambert = cdata.kd * data.Il.Y * data.Io.Y * cosNL * 255;
            mirror = cdata.ks * data.Il.Y * data.Io.Y * cosVR * 255;
            result = (int)(lambert + mirror);
            if (result < 0)
                g = 0;
            else if (result > 255)
                g = 255;
            else g = result;

            //Obliczenie składowej B
            lambert = cdata.kd * data.Il.Z * data.Io.Z * cosNL * 255;
            mirror = cdata.ks * data.Il.Z * data.Io.Z * cosVR * 255;
            result = (int)(lambert + mirror);
            if (result < 0)
                b = 0;
            else if (result > 255)
                b = 255;
            else b = result;

            return Color.FromArgb(r, g, b);
        }

    }

    public class InterpolateLambertMethod
    {
        //Przechowywanie L z rozkładu LU
        private Vector3 row1;
        private Vector3 row2;
        private Vector3 row3;
        private float l21;
        private float l31;
        private float l32;
        private Vector3 bar;
        Point[] points = new Point[3];
        Color[] colorPoints = new Color[3];
        float wholeArea;


        private void CalculateBaricentric(Point p)
        {
            //Rozwiazanie ukladu rownan z rozkladu LU
            bar.X = p.X;
            bar.Y = p.Y - l21 * p.X;
            bar.Z = 1 - p.X * l31 - p.Y * l32;
            bar.Z = bar.Z / row3.Z;
            bar.Y = (bar.Y - bar.Z * row2.Z) / row2.Y;
            bar.X = (bar.X - bar.Z * row1.Z - bar.Y * row1.Y) / row1.X;
            //bar.Z = 1 - bar.X - bar.Y;
        }

        /*private float Heron(Point A, Point B, Point C)
        {
            float AB = A.Substract(B).EuclideanMeasureF();
            float BC = B.Substract(C).EuclideanMeasureF();
            float AC = A.Substract(C).EuclideanMeasureF();
            float halfL = (AB + BC + AC) / 2.0f;

            float result = MathF.Sqrt(halfL * (halfL - AB) * (halfL - BC) * (halfL - AC));
            if (float.IsNaN(result))
                return 1;
            return result;
        }
        private void CalculateBaricentric(Point p)
        {
            bar.X = Heron(points[1], points[2], p) / wholeArea;
            bar.Y = Heron(points[0], points[2], p) / wholeArea;
            bar.Z = 1 - bar.X - bar.Y;
        }*/

        public Color CalculateColour(Point p)
        {
            CalculateBaricentric(p);
            return Color.FromArgb((int)(colorPoints[0].R * bar.X + colorPoints[1].R * bar.Y + colorPoints[2].R * bar.Z),
                (int)(colorPoints[0].G * bar.X + colorPoints[1].G * bar.Y + colorPoints[2].G * bar.Z),
                (int)(colorPoints[0].B * bar.X + colorPoints[1].B * bar.Y + colorPoints[2].B * bar.Z));
        }

        public void SetContext((Point p, Color c)[] points)
        {
            this.points[0] = points[0].p;
            this.points[1] = points[1].p;
            this.points[2] = points[2].p;

            //Obliczenie kolorow w 3 punktach trojkata
            colorPoints[0] = points[0].c;
            colorPoints[1] = points[1].c;
            colorPoints[2] = points[2].c;

            //wholeArea = Heron(this.points[0], this.points[1], this.points[2]);

            
            //rozklad L macierzy [x1, x2, x3; y1, y2, y3; 1, 1, 1]
            row1 = new Vector3(this.points[0].X, this.points[1].X, this.points[2].X);
            l21 = this.points[0].Y / row1.X;
            l31 = 1 / row1.X;
            row2 = new Vector3(0.0f, this.points[1].Y - row1.Y * l21, this.points[2].Y - row1.Z * l21);
            l32 = (1 - l31 * row1.Y) / row2.Y;
            row3 = new Vector3(0, 0, 1 - row1.Z * l31 - row2.Z * l32);
        }
    }
    
}
