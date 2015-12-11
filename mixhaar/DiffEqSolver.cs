using System;

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

        //public double[] Solve()
        //{
            
        //}
    }
}