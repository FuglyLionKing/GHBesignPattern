using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

namespace GHBesignPattern.Controller.Simulation
{
    public  class SimpleSimulation : ISimulation
    {
        private List<ICharacter> _characters;
        private IZone[,] _board;
        private IObservee _papaBears;

        public SimpleSimulation(List<ICharacter> characters, IZone[,] board, IObservee papaBears)
        {
            _characters = characters;
            _board = board;
            _papaBears = papaBears;
        }

        public List<ICharacter> Characters
        {
            get { return _characters; }
        }

        public IZone[,] Board
        {
            get { return _board; }
        }

        public IObservee PapaBears
        {
            get { return _papaBears; }
        }

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
