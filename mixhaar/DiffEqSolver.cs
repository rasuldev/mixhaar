using System;
using static mixhaar.Functions.Function;

namespace mixhaar
{
    public class DiffEqSolver
    {
        private double a, b, y0, y1;
        private Func<double, double> f;

        /// <summary>
        /// Solves differential equation y''(t)+ay'(t)+by(t)=f(t), y(0)=y0, y'(0)=y1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="f"></param>
        public DiffEqSolver(double a, double b, Func<double, double> f, double y0, double y1)
        {
            this.a = a;
            this.b = b;
            this.f = f;
            this.y0 = y0;
            this.y1 = y1;
        }

        public double[] Solve(double[] nodes, int n)
        {
            var m = nodes.Length;
            var A = new double[m, n];
            var B = new double[m];
            for (int j = 0; j < m; j++)
            {
                for (int k = 0; k <= n; k++)
                {
                    var t = nodes[j];
                    A[j, k] = Haar(k)(t) + a * MixedHaar2(1, k + 1)(t) + b * MixedHaar2(2, k + 2)(t);
                }
                B[j] = f(nodes[j]) - a * y1 - b * (y0 + y1 * nodes[j]);
            }

            return mathlib.LinearSystem.Solve(A, B);
        }
    }
}