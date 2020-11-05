using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace Oswietlenie.ColourConfiguration
{
    interface ILightVector
    {
        Vector3 GetLightVector(Point p);
        void UpdateLight();
    }

    class StaticLightVector : ILightVector
    {
        private Vector3 light;

        public StaticLightVector(Vector3 v)
        {
            float len = v.Length();
            light = new Vector3(v.X / len, v.Y / len, v.Z / len);
        }

        public Vector3 GetLightVector(Point p)
        {
            return light;
        }

        public void UpdateLight()
        {
            return;
        }
    }

    class MovingLightSource : ILightVector
    {
        public Vector3 GetLightVector(Point p)
        {
            throw new NotImplementedException();
        }

        public void UpdateLight()
        {
            throw new NotImplementedException();
        }
    }
}
