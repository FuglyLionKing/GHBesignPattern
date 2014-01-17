using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

namespace GHBesignPattern.Controller.Simulation
{

    public interface ISimulation  
    {

        List<ICharacter>  Characters { get; }
       
        //Object are already inside zones
        IZone[,] Board { get; }
        IObservee PapaBears { get; }

        void Update();

        void UpdatePapaBear();

        void AnalyzeSituation();

        void MoveAll();

        void CombatAll();

        void UpdateObjects();
    }
}
