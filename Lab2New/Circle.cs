using System;

namespace Main
{
    public class Circle : Figure
    {
        public int Id { get; set; }
        public Circle(int y, int x, int degree, double size)
        {
            Y = y;
            X = x;
            Degree = degree;
            Size = size;
        }

        public override double S()
        {
            return Math.PI * Size * Size;
        }
    }
}
