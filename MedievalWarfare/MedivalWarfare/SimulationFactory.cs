using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;
using MedievalWarfare.MedivalWarfare.Model;
using MedievalWarfare.MedivalWarfare.Model.Character;
using MedievalWarfare.MedivalWarfare.Model.items;
using MedievalWarfare.MedivalWarfare.objectif;

namespace GHBesignPattern.Controller.Simulation
{
    class SimulationFactory
    {

        public static SimpleSimulation GenerateSimpleSimulation()
        {
            var apples = new List<IItem>();

            for (int i = 0; i < 10; ++i)
            {
                apples.Add(new Apple());
            }

            var knights = new List<ICharacter>();

            var sight = new TwentyOutOfTenOnBothEyesEyeSight();
            var move = new PedestrianBehavior();

            var objos = ObjectivesFactory.GenerateObjectivesFrom(apples, 5);

            var board = new SquareBoard(15, 10);
            board.Build();

            for (int i = 0; i < 5; ++i)
            {
                var ob = new List<Objectif>();
                ob.Add(objos[i]);
                knights.Add(new Knight(null,100,move,board.zones[0,i],"knight "+i,ob,new List<IItem>(), warStates.Peace,sight));
            }

            var sim = new SimpleSimulation(knights,board.zones,null);


            return sim;


        }
    }
}
