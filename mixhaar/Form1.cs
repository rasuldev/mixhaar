using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscreteFunctions;
using DiscreteFunctionsPlots;
using GraphBuilders;

namespace mixhaar
{
    public partial class Form1 : GraphBuilder2DForm
    {
        Plot2D plotHaar = new Plot2D("Haar");
        Plot2D plotMix = new Plot2D("Mixed from Haar");

        public Form1() : base(2)
        {
            InitializeComponent();
            Height = Height + 1;
            GetGraphBuilder(0).DrawPlot(plotHaar);
            GetGraphBuilder(1).DrawPlot(plotMix);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
        }

        void Draw(int r, int n)
        {
            if (n - r >= 1)
            {
                plotHaar.DiscreteFunction = new DiscreteFunction2D(Functions.Function.Haar(n - r), 0, 1, 1000);
                plotHaar.Refresh();
            }
            plotMix.DiscreteFunction = new DiscreteFunction2D(Functions.Function.MixedHaar2(r, n), 0, 1, 1000);
            plotMix.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Draw((int)nupR.Value, (int)nupN.Value);
        }

        private void nupN_ValueChanged(object sender, EventArgs e)
        {
            Draw((int)nupR.Value, (int)nupN.Value);
        }
    }
}
