using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace Oswietlenie.ColourConfiguration
{
    public class LightColour
    {
        private Vector3 colour;

        public LightColour(Color colour)
        {
            SetColour(colour);
        }

        public void SetColour(Color colour)
        {
            this.colour = new Vector3(colour.R/255.0f, colour.G/ 255.0f, colour.B/ 255.0f);
        }

        public Vector3 GetLightColour()
        {
            return this.colour;
        }
    }
}
