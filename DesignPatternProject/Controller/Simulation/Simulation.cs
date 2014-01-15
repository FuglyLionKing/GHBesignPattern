using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHBesignPattern.Controller.Simulation
{

    interface ISimulation
    {
        //TODO sgetset livingthings
        //TODO getset objects
        //TODO getset terrain
        //TODO getset papabears

        void Run();

        void Update();

        void UpdatePapaBear();

        void AnalyzeSituation();

        void MoveAll();

        void CombatAll();

        void UpdateObjects();
    }
}
