using Oswietlenie.Geometric;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Wielokaty;

namespace Oswietlenie
{
    class ColourModel
    {

        public Color ColourObject { get; set; } = Color.Red;


        public Color GetColor(Point p)
        {
            return ColourObject;
        }

    }

   

}
