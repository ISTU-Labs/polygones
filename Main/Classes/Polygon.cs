using System;

namespace Main
{
    public class Polygon : Figure
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public Polygon(int y, int x, int degree, double size, int count)
        {   
            Y = y;
            X = x;
            Degree = degree;
            Size = size;
            Count = count;
        }

        public override double S()   
        {
            return 0.5 * Size * Size * Count * Math.Sin(2*Math.PI/Count);
        }

        public override string ToString()   
        {
            return String.Format("Центр: ({0};{1})\tУгол наклона: {2} град.\tРадиус: {3}\t" +
                                 "Число сторон: {4}", X, Y, Degree, Size, Count);
        }
    }
}
