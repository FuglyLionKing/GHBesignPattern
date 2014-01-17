using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Controller.Statistic;

namespace GHBesignPattern.Controller.Simulation
{
    public delegate void UpdateDisplayer();

    public interface ISimulationRunner 
    {
        UpdateDisplayer UpdateDisplayer { set; }
        ISimulation Simulation { set; }
        IStatisticsCollector StatCollector { set; }

        void Start();
    }
}
