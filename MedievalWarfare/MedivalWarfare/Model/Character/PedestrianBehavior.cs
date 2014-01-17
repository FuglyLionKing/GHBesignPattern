using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

namespace MedievalWarfare.MedivalWarfare.Model.Character
{
    class PedestrianBehavior : IMovingBehavior 
    {
       
        private const int StepsAvailables = 1;


        public void Move(ICharacter character, IZone objectif)
        {

            IZone goToZone = null;
            IEnumerable<IZone> res = null;
            if (null != objectif)
            {
                res = DjikstraAlgorithm.Run(character, objectif);
            }

            if (null != res)
            {

                var enumerator = res.GetEnumerator();

                for (var i = 0; i < StepsAvailables+1 && i < res.Count(); ++i)
                {
                    enumerator.MoveNext();
                }

                //TODO add moveTo method to Zones or something (aspect ?) so moving a character automaticaly removes it from start and add it to finish

                goToZone = enumerator.Current;

            }
            else
            {
                Random rnd = new Random();
                goToZone = character.Position.Accesses[rnd.Next(0, character.Position.Accesses.Count)].Target;
            }


            Console.WriteLine(character.Name+" moved from "+character.Position.ToString()+" to "+goToZone.ToString());

            character.Position.Characters.Remove(character);
            character.Position = goToZone;
            character.Position.Characters.Add(character);

        }

        public bool IsReachable(ICharacter character, IZone objectif)
        {
            var res = DjikstraAlgorithm.Run(character, objectif);

            return null != res;
        }
    }
}
