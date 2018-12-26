using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    delegate string StrInt(string str, int num);

    class Program
    {
        // Возвращает строку, в которой каждый символ str повторяется num раз
        static string StrIntMethod(string str, int num)
        {
            string tmp = "";
            foreach (char x in str)
            {
                for (int i = 0; i < num; ++i)
                {
                    tmp += x;
                }
            }
            return tmp;
        }
        static void Method(string description, string str, int num, StrInt meth)
        {
            Console.Write(description + ": ");
            Console.WriteLine(meth(str, num));
        }

        static void Method1(string description, string str, int num, Func<string, int, string> meth)
        {
            Console.Write(description + ": ");
            Console.WriteLine(meth(str, num));
        }

    
        static void Main(string[] args)
        {
            string str = "hello";
            int num = 5;

            Console.WriteLine("Делегат MyDeleg:");
            Method("Передача метода", str, num, StrIntMethod);
            Method("Передача лямбда-выражения", str, num, (x, y) => x + y.ToString());
       
            Console.WriteLine("\nОбобщенный делегат:");
            Method1("Передача метода", str, num, StrIntMethod);
            Method1("Передача лямбда-выражения", str, num, (x, y) => x + y.ToString());
            Console.ReadKey();
        }
    }
}
