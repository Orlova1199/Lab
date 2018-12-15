using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
        //интерфейс IPrint
        interface IPrint
        {
            void Print();
        }

        //класс «Геометрическая фигура»
        abstract class Figure
        {
            public string Type
            {
                get
                {
                    return this._Type;
                }
                protected set
                {
                    this._Type = value;
                }
            }
            string _Type;
            public abstract double Area();

            public override string ToString()
            {
                return this.Type + " площадью " +
               this.Area().ToString();
            }
        }

        //класс «Прямоугольник»
        class Rectangle : Figure, IPrint
        {
            double height;
            double width;
            public Rectangle(double ph, double pw)
            {
                this.height = ph;
                this.width = pw;
                this.Type = "Прямоугольник";
            }

            public override double Area()
            {
                double Result = this.width * this.height;
                return Result;
            }
            public void Print()
            {
                Console.WriteLine(this.ToString());
            }
        }

        //класс «Квадрат»
        class Square : Rectangle, IPrint
        {
            public Square(double size)
            : base(size, size)
            {
                this.Type = "Квадрат";
            }
        }

        //класс «Круг»
        class Circle : Figure, IPrint
        {
            double radius;
            public Circle(double pr)
            {
                this.radius = pr;
                this.Type = "Круг";
            }
            public override double Area()
            {
                double Result = Math.PI * this.radius * this.radius;
                return Result;
            }
            public void Print()
            {
                Console.WriteLine(this.ToString());
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Rectangle rect = new Rectangle(3, 5);
                Square square = new Square(11);
                Circle circle = new Circle(2);
                rect.Print();
                square.Print();
                circle.Print();
                Console.ReadKey();
            }
        }
       
}
