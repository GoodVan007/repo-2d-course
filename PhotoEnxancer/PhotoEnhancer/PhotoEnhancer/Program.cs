using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using PhotoEnhancer.Filters;

namespace PhotoEnhancer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficient));
            
            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var lightness = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;
                    return new Pixel(lightness, lightness, lightness);
                }));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            mainForm.AddFilter(new verticalReflection(
                "Отражение по вертикали",
                size => size,
                (point, size) => new Point(point.X,size.Height - point.Y - 1)
                ));
            //mainForm.AddFilter(new PixelFilter<LighteningParameters>(
            //    "Trashold", (pixel, parameters) =>
            //    {
            //        var lightness = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;

            //        if (lightness < parameters[])
            //            lightness = 0;
            //        else
            //            lightness = 1;

            //        Pixel result = new Pixel(lightness, lightness, lightness);

            //        return result;
            //    }));

            Application.Run(mainForm);
        }
    }
}
