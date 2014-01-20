using System.Collections.Generic;
using GHBesignPattern.Controller.Simulation;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

namespace MedievalWarfare.MedivalWarfare
{
    public  class SimpleSimulation : ISimulation
    {
        public SimpleSimulation(List<ICharacter> characters, IZone[,] board, IObservee papaBears)
        {
            Characters = characters;
            Board = board;
            PapaBears = papaBears;
        }

        public List<ICharacter> Characters { get; private set; }

        public IZone[,] Board { get; private set; }

        public IObservee PapaBears { get; private set; }

        public void Update()
        {
            foreach (var character in Characters)
            {
                character.ResolveObjectives();
            }
        }

        public void UpdatePapaBear()
        {
            //TODO
        }

        public void AnalyzeSituation()
        {
            foreach (var character in Characters)
            {
                character.Examine();
            }
        }

        public void MoveAll()
        {
            foreach (var character in Characters)
            {
                character.Move();
            }
        }

        public void CombatAll()
        {
           //TODO
        }

        public void UpdateObjects()
        {
            //TODO
        }
    }
}
