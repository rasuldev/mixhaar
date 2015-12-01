using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}
