using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Controller.Statistic;

namespace GHBesignPattern.Controller.Simulation
{

    interface ISimulationRunner<T> where T : struct , IConvertible, IComparable, IFormattable
    {
        IDisplayer Displayer { set; }
        ISimulation<T> Simulation { set; }
        IStatisticsCollector<T> StatCollector { set; }

        void Start();
    }
}
