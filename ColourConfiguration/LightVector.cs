using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Oswietlenie.ColourConfiguration
{
    public interface ILightVector
    {
        Vector3 GetLightVector(Point p);
        void UpdateLight();
    }

    public class StaticLightVector : ILightVector
    {
        private Vector3 light;

        public StaticLightVector(Vector3 v)
        {
            light = Vector3.Normalize(new Vector3(v.X, v.Y, v.Z));
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

    public class MovingLightSource : ILightVector
    {
        
        private const float dt = 0.1f;
        private const float maxT = 100;
        private const float minT = 50;
        
        public static int updateInterval = 150;
        private bool ascending = true;
        private float t = 80;
        private Vector3 offset;
        private Vector3 lightPos;
        private const float multiplier = 200;

        public MovingLightSource(int width, int height)
        {
            offset = new Vector3(width / 2.0f, height / 2.0f, 0);
        }

        public Vector3 GetLightVector(Point p)
        {
            return Vector3.Normalize(new Vector3(lightPos.X - p.X, p.Y - lightPos.Y, lightPos.Z));
        }

        public void UpdateLight()
        {
            if (ascending)
            {
                t += dt;
                if (t > maxT)
                    ascending = false;
            }
            else
            {
                t -= dt;
                if (t < minT)
                    ascending = true;
            }

            lightPos = Vector3.Add(new Vector3(MathF.Cos(t)* multiplier, MathF.Sin(t) * multiplier, t), offset);            
        }   
    }
}
