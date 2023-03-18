using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnxancer
{
    public class LighteningFilter : IFilter
    {
        public ParameterInfo[] GetParametersInfo()
        {
            //--------------------------------------------------------------------------------
            // Возможный вариант оформления:

            //var result = new ParameterInfo[1];
            //result[0] = new ParameterInfo();
            //result[0].Name = "Coefficient";
            //result[0].minValue= 0;
            //result[0].maxValue= 0;
            //result[0].defaultValue = 1;
            //result[0].Increment = 0.05;
            //return result;
            //---------------------------------------------------------------------------------

            return new[]
            {
                new ParameterInfo()
                {
                    Name= "Сoefficient",
                    minValue = 0,
                    maxValue = 10,
                    defaultValue= 1,
                    Increment= 0.05,
                }
            };
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var newPhoto = new Photo(original.Width, original.Height);

            for (var x = 0; x < original.Width; x++)
                for (var y = 0; y < original.Width; y++)
                    newPhoto[x, y] = original[x, y] * parameters[0];

            return newPhoto;

        }
        public override string ToString()
        {
            return "Brightness";
        }
    }
}
