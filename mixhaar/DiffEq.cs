using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DiscreteFunctions;
using DiscreteFunctionsPlots;
using static System.Math;
using static System.Linq.Enumerable;

namespace mixhaar
{
    public partial class DiffEq : GraphBuilders.GraphBuilder2DForm
    {
        private DiffEqSolver solver;
        Plot2D plotExact = new Plot2D("Exact");
        Plot2D plotNum = new Plot2D("Numerical");
        private double SegmentStart = 0;
        private double SegmentEnd = 1;



        public DiffEq()
        {
            InitializeComponent();
            GraphBuilder.DrawPlot(plotExact);
            GraphBuilder.DrawPlot(plotNum);
            Init();
        }


        public void Init()
        {
            var a = 1;
            var b = 2;
            Func<double, double> f = t => 1 + t + t * t;

            Func<double, double> exactSolution = t => t * t / 2;

            plotExact.DiscreteFunction = new DiscreteFunction2D(exactSolution, SegmentStart, SegmentEnd, 1000);
            plotExact.Refresh();
            solver = new DiffEqSolver(x => 1, x => a, x => b, f, 0, 0);
        }

        public Func<double, double> Solve()
        {
            int nodesCount = (int)nupNodesCount.Value;
            int coeffsCount = (int)nupCoeffsCount.Value;

            var nodes = Range(0, nodesCount).Select(j => SegmentStart + j * (SegmentEnd - SegmentStart) / (nodesCount - 1)).ToArray();
            return solver.Solve(nodes, coeffsCount);
        }

        public void Draw()
        {
            var numSolution = Solve();
            plotNum.DiscreteFunction = new DiscreteFunction2D(numSolution, SegmentStart, SegmentEnd, 1000);
            plotNum.Refresh();
        }

        private void nupNodesCount_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
