using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Controller.Simulation;
using GHBesignPattern.Model.Characters;

namespace GHBesignPattern.Controller.Statistic
{
    public interface IStatisticsCollector 
    {
        ISimulation Simulation { set; }

        void CollectInformation(List<ICharacter> characters );

        void UdateStatistics();
    }
}
