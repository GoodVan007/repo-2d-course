using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnxancer
{
    public class Pixel
    {
        private double r;
        public double R
        {
            get => r;
            set => r = CheckValue(value);
        }

        private double g;
        public double G
        {
            get => g;
            set => g = CheckValue(value);
        }

        private double b;
        public double B
        {
            get => b;
            set => b = CheckValue(value);
        }

        public Pixel(double red, double green, double blue)
        {
            R = red;
            G = green;
            B = blue;
        }

        public static Pixel operator *(Pixel k, double p)
        {
            Pixel result = new Pixel();

            result.r = Trim(k * p.r);
            result.g = Trim(k * p.g);
            result.b = Trim(k * p.b);

            return result;

        }

        public static Pixel operator *(Pixel p, double k) => k * p;

        private double CheckValue(double val)
        {
            if (val < 0 || val > 1)
                throw new ArgumentException("Неверное значение яркости канала");

            return val;
        }
    }
}