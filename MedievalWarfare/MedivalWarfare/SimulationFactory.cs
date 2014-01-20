using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            var board = new SquareBoard(25, 25);
            board.Build();
            var rand = new Random();
            var apples = new List<IItem>();

            for (var i = 0; i < 10; ++i)
            {
                apples.Add(new Apple());
                var x = rand.Next(1, board.Zones.GetLength(0));
                var y = rand.Next(1, board.Zones.GetLength(1));
                //Console.Out.WriteLine("A - x:" + x +" y:" + y);
                board.Zones[x, y].Items.Add(apples[i]);
            }
            
            var knights = new List<ICharacter>();

            var sight = new TwentyOutOfTenOnBothEyesEyeSight();
            var move = new PedestrianBehavior();

            var objos = ObjectivesFactory.GenerateObjectivesFrom(apples, 20);

            for (var i = 0; i < 3; ++i)
            {
                var ob = new List<Objectif> { objos[i] };
                var x = rand.Next(1, board.Zones.GetLength(0));
                var y = rand.Next(1, board.Zones.GetLength(1));
                //Console.Out.WriteLine("K - x:" + x + " y:" + y);
                knights.Add(new Knight(null, 100, move, board.Zones[x, y], "K" + i, ob, new List<IItem>(), warStates.Peace, sight));
            }
            return new SimpleSimulation(knights,board.Zones,null);
        }
    }
}
