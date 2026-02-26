using System;
using System.Collections.Generic;
using System.Text;

namespace TestTDD
{
    public class Calcul
    {
        public double Addition(double x, double y)
        {
                return x + y;
        }


        public double Division(double x, double y)
        {
                return x / y;
        }

    }


    public class GradingCalculator
    {
        public int Score { get; set; }
        public int AttendancePercentage { get; set; }

        public char GetGrade()
        {

            if (Score > 90 && AttendancePercentage > 70) return 'A';
            else if (Score > 80 && AttendancePercentage > 60) return 'B';
            else if (Score > 60 && AttendancePercentage > 60) return 'C';
            else return 'F';
        }
    }

    public class Fib

    {

        private int _range;



        public Fib(int r)

        {

            _range = r;

        }



        public List<int> GetFibSeries()

        {
            List<int> result = new List<int>();
            int a = 0, b = 1, c = 0;
            if (_range == 1)
            {
                result.Add(0);
                return result;
            }

            result.Add(0);
            result.Add(1);

            for (int i = 2; i < _range; i++)

            {
                c = a + b;
                result.Add(c);
                a = b;
                b = c;
            }
            return result;

        }

    }

}
