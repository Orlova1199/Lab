using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			double a, b, c, d;
			string s;

			// Ввод коэффициента А
			Console.Write("Введите коэффициент А ");
			do
			{
				s = Console.ReadLine();
				if (!double.TryParse(s, out a)) Console.Write("Ввод некоректен. Повторите попытку ");
			}
			while (!double.TryParse(s, out a));

			// Ввод коэффициента B
			Console.Write("Введите коэффициент B ");
			do
			{
				s = Console.ReadLine();
				if (!double.TryParse(s, out b)) Console.Write("Ввод некоректен. Повторите попытку ");
			}
			while (!double.TryParse(s, out b));

			// Ввод коэффициента C
			Console.Write("Введите коэффициент C ");
			do
			{
				s = Console.ReadLine();
				if (!double.TryParse(s, out c)) Console.Write("Ввод некоректен. Повторите попытку ");
			}
			while (!double.TryParse(s, out c));

            if (a == 0) // прямая
            {
                Console.Write("Задано уравнение прямой");
                if (b == 0)
                    if (c == 0)
                        Console.Write(", совпадающей с осью ОХ. Корнями уравнения являютя все точки этой прямой.");
                    else
                        Console.Write(", параллельной оси ОХ. Корней нет.");
                else
                    Console.Write($". Корень: {-c / b}.");
            }
            else // парабола
            {
                Console.Write("Задано уравнение параболы. ");
                d = (b * b - 4 * a * c);
                if (d < 0)
                    Console.Write("Корней нет.");
                else
                            if (d == 0)
                    Console.Write($"Корень: {-b / (2 * a)}.");
                else
                    Console.Write($"2 корня: {(-b - Math.Pow(d, 0.5)) / (2 * a)}; {(-b + Math.Pow(d, 0.5)) / (2 * a)}.");
            }      

			Console.ReadKey();
		}
	}
}
