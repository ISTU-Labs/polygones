using System;

namespace Main
{
    public class Figure
    {
        public int Y { get; set; }
        public int X { get; set; }
        public int Degree { get; set; }
        public double Size { get; set; }

        public override string ToString()   
        {
            return String.Format("Центр: ({0};{1})\tУгол наклона: {2} град.\tРадиус: {3}",
                X, Y, Degree, Size);
        }
        public virtual double S()   
        {
            return 1;
        }
    }
}
