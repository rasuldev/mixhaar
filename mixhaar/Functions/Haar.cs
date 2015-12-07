using System;
using mathlib;
using static System.Math;

namespace mixhaar.Functions
{
    public static class Function
    {
        public static Func<double, double> Haar(int n)
        {
            if (n == 1) return x => 1;
            Func<double, double> log2 = t => Log(t, 2);
            // Find k and i in representation n=2^k + i
            var k = Floor(log2(n - 1));
            var i = n - Pow(2, k);

            return x =>
            {
                if (x < (i - 1) / Pow(2, k)) return 0;
                if (x < (2 * i - 1) / Pow(2, k + 1)) return Pow(2, k / 2);
                if (x < i / Pow(2, k)) return -Pow(2, k / 2);
                return 0;
            };
        }


        // n >= 1, r >= 1
        public static Func<double, double> MixedHaar(int r, int n)
        {
            if (n <= r)
            {
                var fact = Factorial(n-1);
                return x => Pow(x, n-1) / fact;
            }

            var c = 1 / Factorial(r - 1);
            return x => c * Integrals.Trapezoid(t => Pow(x - t, r - 1) * Haar(n - r)(t), 0, x, 1000);
        }

        public static int Factorial(int n)
        {
            var fact = 1;
            for (int i = 2; i < n; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }


}