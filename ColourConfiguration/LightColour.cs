using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace Oswietlenie.ColourConfiguration
{
    class LightColour
    {
        private Vector3 colour;

        public LightColour(Color colour)
        {
            SetColour(colour);
        }

        public void SetColour(Color colour)
        {
            this.colour = new Vector3(colour.R, colour.G, colour.B);
        }

        public Vector3 GetLightColour()
        {
            return this.colour;
        }
    }
}
