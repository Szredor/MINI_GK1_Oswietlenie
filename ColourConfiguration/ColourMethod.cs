using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace Oswietlenie.ColourConfiguration
{
    interface IColourMethod
    {
        public Color CalculateColour(ColourData data);
    }

    struct ColourData
    {
        public Vector3 Il;
        public Vector3 Io;
        public Vector3 L;
        public Vector3 N;
        public double kd;
        public double ks;
        public int m;
    }

    class AcurateLambertMethod : IColourMethod
    {
        protected readonly Vector3 V = new Vector3(0, 0, 1);

        protected float cosNL;
        protected float cosVR;

        private float Clamp(float v, float a, float b)
        {
            if (v < a)
                return a;
            if (v > b)
                return b;
            return v;
        }

        private float Cos(Vector3 a, Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        protected int CalculateLambert(float Il, float Io, double kd, double ks, int m)
        {
            
            float result = (float)(kd * Il * Io * cosNL + ks * Il * Io * cosVR);
            return (int)(Clamp(result, 0, 1) * 255);
        }

        public virtual Color CalculateColour(ColourData data)
        {
            cosNL = Cos(data.N, data.L);
            Vector3 R = Vector3.Subtract(Vector3.Multiply(Vector3.Dot(data.N, data.L) * 2, data.N), data.L);
            cosVR = (float)Math.Pow(Cos(V, R), data.m);
            Color result = Color.FromArgb(CalculateLambert(data.Il.X, data.Io.X, data.kd, data.ks, data.m),
                CalculateLambert(data.Il.Y, data.Io.Y, data.kd, data.ks, data.m),
                CalculateLambert(data.Il.Z, data.Io.Z, data.kd, data.ks, data.m));

            return result;
        }
    }

    class InterpolateLambertMethod : AcurateLambertMethod
    {
        public override Color CalculateColour(ColourData data)
        {
            return base.CalculateColour(data);
        }
    }
    
}
