using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Controller.Statistic;

namespace GHBesignPattern.Controller.Simulation
{
 
    interface ISimulationRunner
    {
        IDisplayer Displayer { set; }
        ISimulation Simulation { set; }
        IStatisticsCollector StatCollector { set; }

        void Start();
    }
}
