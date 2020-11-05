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
    class ColourModel
    {
        public double kd { get; set; }
        public double ks { get; set; }
        public int m { get; set; }

        public IColourObject ColourObject { get; set; }
        public IColourMethod ColourMethod { get; set; }
        public ILightVector LightVector { get; set; }
        public LightColour LigthColour { get; set; }
        public INormalMap NormalMap { get; set; }


        public Color GetColor(Point p)
        {
            ColourData data = new ColourData()
            {
                Il = this.LigthColour.GetLightColour(),
                Io = ColourObject.GetColorObject(p),
                L = LightVector.GetLightVector(p),
                N = NormalMap.GetNormalMap(p),
                kd = this.kd,
                ks = this.ks,
                m = this.m,
            };
            //kd * IL * IO * cos(kąt(N, L)) + ks * IL * IO * cos^m(kąt(V, R))
            return ColourMethod.CalculateColour(data);
        }

    }

   

}
