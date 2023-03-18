using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexStruct
{
    public struct Complex
    {
        public double Re, Im;

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        
        public static Complex operator +(Complex a, Complex b) => new Complex(a.Re + b.Re, a.Im + b.Im); // Сумма

        //public static Complex operator +(Complex a, double b) => new Complex(a.Re + b, a.Im + b); //Сложение

        public static Complex operator -(Complex a, Complex b) => new Complex(a.Re - b.Re, a.Im - b.Im); //Вычитание

        public double Abs => Math.Round(Math.Sqrt(Re * Re + Im * Im), 3); // Модуль(Длина вектора)

        public override bool Equals(object obj)
        {
            return obj != null 
                && GetType().Equals(obj.GetType()) 
                && (Re == ((Complex)obj).Re) 
                && (Im == ((Complex)obj).Im);
        }
        public override int GetHashCode() => ToString().GetHashCode();

        public override string ToString()
        {
            if (Re == 0.0 && Im == 0.0) return "0";
            if(Im == 0.0) return $"{Re}";
            if(Re == 0.0)
            {
                if (Im == 1.0) return "i";
                if (Im == -1.0) return "-i";
                return $"{Im}i";
            }
            string sing = Im < 0.0 ? "- " : "+ ";
            if (Math.Abs(Im) != 1.0) sing += $"{Math.Abs(Im)}";
            return $"{Re} {sing}i";

        }


        //Для первоначальной проверки кода выставлял тип КОНСОЛЬНОЕ ПРИЛОЖЕНИЕ и проверял вручную(проще)
        //Работает :)

        //static void Main(string[] args)
        //{
        //    var cn1 = new Complex(5, -7);
        //    var cn2 = new Complex(5, -7);

        //    Console.WriteLine($"+ : {cn1 + cn2}");
        //    Console.WriteLine($"- : {cn1 - cn2}");
        //    Console.ReadKey();
        //}
    }

  
}