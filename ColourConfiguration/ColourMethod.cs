﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;

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

        public virtual Color CalculateColour(ColourData data)
        {
            float cosNL;
            float cosVR;

            Vector3 N = data.N;
            Vector3 L = data.L;
            cosNL = Vector3.Dot(N, L);
            float mulitplier = cosNL * 2;
            Vector3 R = new Vector3(2 * cosNL * N.X - L.X, 2 * cosNL * N.Y - L.Y, 2 * cosNL * N.Z - L.Z);
            //cosVR = (float)Math.Pow(2 * cosNL * N.Z - L.Z, data.m);//Wynikiem <V, R> bedzie zawsze ostania współrzedna R, ponieważ, V = [0, 0, 1];
            cosVR = (float)Math.Pow(Vector3.Normalize(R).Z, data.m);//Wynikiem <V, R> bedzie zawsze ostania współrzedna R, ponieważ, V = [0, 0, 1];

            int r, g, b;
            //Obliczenie składowej R
            float lambert = data.kd * data.Il.X * data.Io.X * cosNL * 255;
            float mirror = data.ks * data.Il.X * data.Io.X * cosVR * 255;
            int result = (int)(lambert + mirror);
            if (result < 0)
                r = 0;
            else if (result > 255)
                r = 255;
            else r = result;

            //Obliczenie składowej G
            lambert = data.kd * data.Il.Y * data.Io.Y * cosNL * 255;
            mirror = data.ks * data.Il.Y * data.Io.Y * cosVR * 255;
            result = (int)(lambert + mirror);
            if (result < 0)
                g = 0;
            else if (result > 255)
                g = 255;
            else g = result;

            //Obliczenie składowej B
            lambert = data.kd * data.Il.Z * data.Io.Z * cosNL * 255;
            mirror = data.ks * data.Il.Z * data.Io.Z * cosVR * 255;
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
        private Vector3 bar;
        private Vector3 row1;
        private Vector3 row2;
        private Vector3 row3;
        private float l21;
        private float l31;
        private float l32;
        Point[] points = new Point[3];
        Color[] colorPoints = new Color[3];
        /*float detA;
        float detPart1A;
        float detPart2A;
        float detPart3A;*/

        /*private void CalculateBaricentric(Point p)
        {
            //Wyliczenie wzorami cramera
            float p1 = points[0].X * p.Y - p.X * points[0].Y;
            float p2 = points[1].X * p.Y - p.X * points[1].Y;
            float p3 = points[2].X * p.Y - p.X * points[2].Y;

            //Debug.Assert(detA == 0);

            bar.X = (detPart1A - p3 + p2) / detA;
            bar.Y = (p3 - detPart2A + p1) / detA;
            bar.Z = (p2 - p1 + detPart3A) / detA;
        }*/

        private void CalculateBaricentric(Point p)
        { 
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
            int r = (int)(colorPoints[0].R * bar.X + colorPoints[1].R * bar.Y + colorPoints[2].R * bar.Z);
            if (r < 0)
                r = 0;
            else if (r > 255)
                r = 255;
            int g = (int)(colorPoints[0].G * bar.X + colorPoints[1].G * bar.Y + colorPoints[2].G * bar.Z);
            if (g < 0)
                g = 0;
            else if (g > 255)
                g = 255;
            int b = (int)(colorPoints[0].B * bar.X + colorPoints[1].B * bar.Y + colorPoints[2].B * bar.Z);
            if (b < 0)
                b = 0;
            else if (b > 255)
                b = 255;
            return Color.FromArgb(r, g, b);
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

            //Obliczenie wyznaczników do metody Cramera
            /*detPart1A = this.points[1].X * this.points[2].Y - this.points[2].X * this.points[1].Y;
            detPart2A =  this.points[0].X * this.points[2].Y - this.points[2].X * this.points[0].Y;
            detPart3A = this.points[0].X * this.points[1].Y - this.points[1].X * this.points[0].Y;
            detA = detPart1A - detPart2A + detPart3A;*/

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
