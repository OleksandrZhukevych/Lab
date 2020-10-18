using System;
using System.Collections.Generic;


namespace VectorWork
{
    public class Vector
    {
        private double n;

        private List<double> coord = new List<double>();

        public List<double> Coord { get => coord; set => coord = value; }

        public double N
        {
            get { return n; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Radius must be => 0");
                else n = value;
            }
        }

        public Vector() { N = 0; List<double> l = new List<double>(); Coord = l; }

        public Vector(double n, List<double> list) { N = n; Coord = list; }

        static public bool isValid(double n, List<double> list)
        {
            double i = list.Count;
            if (i == n) { return true; }
            else { return false; };
        }

        public bool AreDimensionsEqual(Vector vector1)
        {
            if (vector1.N == N) return true;
            else return false;
        }

        static public List<double> Addition(Vector vector1, Vector vector2) {
            if (vector1.AreDimensionsEqual(vector2))
            {
                List<double> res = new List<double>();
                for (int i = 0; i < vector1.N; i++)
                {
                    double el = vector1.Coord[i] + vector2.Coord[i];
                    res.Add(el);
                }
                return res;
            }
            else { throw new ArgumentOutOfRangeException(); };
        }

        static public List<double> Subtraction(Vector vector1, Vector vector2) {
            if (vector1.AreDimensionsEqual(vector2))
            {
                List<double> res = new List<double>();
                for (int i = 0; i < vector1.N; i++)
                {
                    double el = vector1.Coord[i] - vector2.Coord[i];
                    res.Add(el);
                }
                return res;
            }
            else { throw new ArgumentOutOfRangeException(); };
        }

        public List<double> Multipication(double l) {
            List<double> res = new List<double>();
            for (int i = 0; i < N; i++)
            {
                double el = Coord[i] * l;
                res.Add(el);
            }
            return res;
        }

        public double Module()
        {
            double res, prom = 0;
            for (int i = 0; i < N; i++)
            {
                double s = Coord[i];
                prom += Math.Pow(s, 2);
            }
            res = Math.Sqrt(prom);
            return res;
        }
        
        static public double Scalar(Vector vector1, Vector vector2) {
            if (vector1.AreDimensionsEqual(vector2))
            {
                double res = 0;
                for (int i = 0; i < vector1.N; i++)
                {
                    res += vector1.Coord[i] * vector2.Coord[i];
                }
                return res;
            }
            else { throw new ArgumentOutOfRangeException(); };
        }

        static public bool Comparison(Vector vector1, Vector vector2)
        {
            if (vector1.AreDimensionsEqual(vector2))
            {
                bool check = true;
                for (int i = 0; i < vector1.N; i++)
                {
                    double i1 = vector1.Coord[i];
                    double i2 = vector2.Coord[i];
                    if (i1 == i2 && check == true) { check = true; }
                    else if(i1 != i2) {
                        check = false;
                    }
                }
                return check;
            }
            else { return false; };
        }

        public void Input()
        {
            double n = Convert.ToDouble(Console.ReadLine());
            while (n <= 0)
            {
                double x = Convert.ToDouble(Console.ReadLine());
                coord.Add(x);
            }
            Vector v = new Vector(n, coord);
        }

        public void Print()
        {
            Console.WriteLine($"Dimension: {n} Coordinates: {coord}");
        }
        
        static void Main()
        {
        }
    }
}