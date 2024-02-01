
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFigure.Con
{
    internal class PlotDrawer
    {
        public PlotDrawer()
        {
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };

            ScottPlot.Plot myPlot = new();
            myPlot.Add.Scatter(dataX, dataY);
            myPlot.SavePng(@".\quickstart.png", 400, 300);
        }

    }
}
