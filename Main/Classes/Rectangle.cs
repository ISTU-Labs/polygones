using System;

namespace Main
{
    public class Rectangle : Figure
    {
        public int Id { get; set; }
        public double Coef { get; set; }

        public Rectangle(int y, int x, int degree, double size, double coef)
        {   
            Y = y;
            X = x;
            Degree = degree;
            Size = size;
            Coef = coef;
        }

        public override double S()   
        {
            return Size * Size * Coef;
        }

        public override string ToString()   
        {
            return String.Format("Центр: ({0};{1})\tУгол наклона: {2} град.\tРадиус: {3}\t" +
                                 "Отношение сторон: {4}", X, Y, Degree, Size, Coef);
        }
    }
}
