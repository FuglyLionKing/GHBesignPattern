using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Controller.Simulation;

namespace GHBesignPattern.Controller.Statistic
{
    interface IStatisticsCollector
    {
        ISimulation Simulation { set; }

        //TODO pass it all living sthings
        void CollectInformation();

        void UdateStatistics();
    }
}
