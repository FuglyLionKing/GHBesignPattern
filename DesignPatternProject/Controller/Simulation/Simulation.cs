using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

namespace GHBesignPattern.Controller.Simulation
{

    public interface ISimulation <T> where T : struct , IConvertible, IComparable, IFormattable
    {

        List<ICharacter<T>>  Characters { get; }
       
        //Object are already inside zones
        IZone<T> Terrain { get; }
        IObservee PapaBears { get; }

        void Run();

        void Update();

        void UpdatePapaBear();

        void AnalyzeSituation();

        void MoveAll();

        void CombatAll();

        void UpdateObjects();
    }
}
