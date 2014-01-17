using System.Collections.Generic;
using System.Linq;
using GHBesignPattern.Controller.Simulation;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;
using MedievalWarfare.MedivalWarfare.Model;
using MedievalWarfare.MedivalWarfare.Model.Character;
using MedievalWarfare.MedivalWarfare.Model.items;
using MedievalWarfare.MedivalWarfare.objectif;

namespace MedievalWarfare.MedivalWarfare
{
    public class SimulationFactory
    {

        public static SimpleSimulation GenerateSimpleSimulation()
        {
            var board = new SquareBoard(15, 10);
            board.Build();
            var apples = new List<IItem>();

            for (int i = 0; i < 10; ++i)
            {
                apples.Add(new Apple());
                board.Zones[i, 9].Items.Add(apples[i]);
            }
            
            var knights = new List<ICharacter>();

            var sight = new TwentyOutOfTenOnBothEyesEyeSight();
            var move = new PedestrianBehavior();

            var objos = ObjectivesFactory.GenerateObjectivesFrom(apples, 5);

         
            

            for (int i = 0; i < 5; ++i)
            {
                var ob = new List<Objectif>();
                ob.Add(objos[i]);
                knights.Add(new Knight(null,100,move,board.Zones[0,i],"knight "+i,ob,new List<IItem>(), warStates.Peace,sight));
            }
            for (int i = 0; i < 5; ++i)
            {
                var ob = new List<Objectif>();
                ob.Add(objos[i]);
                knights.Add(new Knight(null, 100, move, board.Zones[0, i], "knight " + i, ob, new List<IItem>(), warStates.Peace, sight));
            }

            var sim = new SimpleSimulation(knights,board.Zones,null);


            return sim;


        }
    }
}
