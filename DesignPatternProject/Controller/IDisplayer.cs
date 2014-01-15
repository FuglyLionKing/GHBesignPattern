using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Controller.Simulation;

namespace GHBesignPattern.Controller
{
    public interface IDisplayer<T> where T : struct , IConvertible, IComparable, IFormattable
    {
        ISimulation<T> Simulation { set; }

        void UpdateDisplay();
    }
}
