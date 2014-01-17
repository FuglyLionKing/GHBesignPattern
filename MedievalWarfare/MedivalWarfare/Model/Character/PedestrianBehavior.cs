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
            var res = DjikstraAlgorithm.Run(character, objectif);

            if (null != res)
            {

                var enumerator = res.GetEnumerator();

                for (var i = 0; i < StepsAvailables && i < res.Count(); ++i)
                {
                    enumerator.MoveNext();
                }

                //TODO add moveTo method to Zones or something (aspect ?) so moving a character automaticaly removes it from start and add it to finish

                goToZone = enumerator.Current;

            }
            else
            {
                goToZone = character.Position.Accesses[0].Target;
            }

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
