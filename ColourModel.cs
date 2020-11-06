using Oswietlenie.ColourConfiguration;
using Oswietlenie.Geometric;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Wielokaty;

namespace Oswietlenie
{
    public interface IColourModel
    {
        public float kd { get; set; }
        public float ks { get; set; }
        public int m { get; set; }
        public IColourObject ColourObject { get; set; }
        public ILightVector LightVector { get; set; }
        public LightColour LigthColor { get; set; }
        public INormalMap NormalMap { get; set; }

        public Color GetColor(Point p);
        public void SetTriangleContext(Triangle triangle);
        public void Clone(IColourModel other);
    }

    public class ColourModelAcurate: IColourModel
    {
        public float kd { get; set; }
        public float ks { get; set; }
        public int m { get; set; }

        public IColourObject ColourObject { get; set; }

        public ILightVector LightVector { get; set; }
        public LightColour LigthColor { get; set; }
        public INormalMap NormalMap { get; set; }

        private AcurateLambertMethod acurateMethod = new AcurateLambertMethod();

        public Color GetColor(Point p)
        {
            //return Color.Red;

            ColourData data = new ColourData();
            data.Il = this.LigthColor.GetLightColour();
            data.Io = ColourObject.GetColorObject(p);
            data.L = LightVector.GetLightVector(p);
            data.N = NormalMap.GetNormalMap(p);
            data.kd = kd;
            data.ks = ks;
            data.m = m;

            //kd * IL * IO * cos(kąt(N, L)) + ks * IL * IO * cos^m(kąt(V, R))
            return acurateMethod.CalculateColour(data);
        }

        public void SetTriangleContext(Triangle triangle)
        { }

        public void Clone(IColourModel other)
        {
            if (other == null)
                return;

            kd = other.kd;
            ks = other.ks;
            m = other.m;
            ColourObject = other.ColourObject;
            LightVector = other.LightVector;
            LigthColor = other.LigthColor;
            NormalMap = other.NormalMap;
        }
    }

    public class ColourModelApprox : IColourModel
    {
        public float kd { get; set; }
        public float ks { get; set; }
        public int m { get; set; }

        public IColourObject ColourObject { get; set; }
        public ILightVector LightVector { get; set; }
        public LightColour LigthColor { get; set; }
        public INormalMap NormalMap { get; set; }

        private InterpolateLambertMethod approxMethod = new InterpolateLambertMethod();
        private AcurateLambertMethod acurateMethod = new AcurateLambertMethod();

        public ColourData CreateColourData(Point p)
        {
            ColourData data = new ColourData();
            data.Il = this.LigthColor.GetLightColour();
            data.Io = ColourObject.GetColorObject(p);
            data.L = LightVector.GetLightVector(p);
            data.N = NormalMap.GetNormalMap(p);
            data.kd = kd;
            data.ks = ks;
            data.m = m;

            return data;
        }

        public Color GetColor(Point p)
        {
             return approxMethod.CalculateColour(p);
        }

        public void SetTriangleContext(Triangle triangle)
        {
            (Point, Color)[] context = new (Point, Color)[]
            {
                (triangle.points[0], acurateMethod.CalculateColour(CreateColourData(triangle.points[0]))),
                (triangle.points[1], acurateMethod.CalculateColour(CreateColourData(triangle.points[1]))),
                (triangle.points[2], acurateMethod.CalculateColour(CreateColourData(triangle.points[2])))
            };
            approxMethod.SetContext(context);
        }

        public void Clone(IColourModel other)
        {
            if (other == null)
                return;

            kd = other.kd;
            ks = other.ks;
            m = other.m;
            ColourObject = other.ColourObject;
            LightVector = other.LightVector;
            LigthColor = other.LigthColor;
            NormalMap = other.NormalMap;
        }
    }


   

}
