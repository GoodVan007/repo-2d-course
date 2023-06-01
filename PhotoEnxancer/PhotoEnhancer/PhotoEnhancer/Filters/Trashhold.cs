using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer.Filters
{
    public class Trashhold : PixelFilter
    {
        public override ParameterInfo[] GetParametersInfo()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Коэффициент",
                    MinValue = 0,
                    MaxValue = 1,
                    DefaultValue = 0.5,
                    Increment = 0.01
                }
            };
        }

        public override Pixel ProcessPixel(Pixel pixel, double[] parameters)
        {
            var lightness = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;

            if(lightness < parameters[0]) 
                lightness = 0;
            else
                lightness = 1;

            Pixel result = new Pixel(lightness, lightness, lightness);

            return result;
        }


        
        public override string ToString()
        {
            return "Trashhold";
        }
    
    }
}
