using System;
using System.Collections.Generic;
using System.Linq;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;

namespace MedievalWarfare.MedivalWarfare.Model.Character
{
    public class TwentyOutOfTenOnBothEyesEyeSight : ISightCapabilities
    {
        private const int viewDistance = 40;

        public List<IZone> Find(ICharacter character, List<IItem> items, List<ICharacter> characters, List<IZone> zones)
        {
            var zonesOfInterest = new List<IZone>();

            var doneZones = new List<IZone>();


            Find(character.Position, items, characters, zones, viewDistance, ref zonesOfInterest, ref doneZones);
            if(zonesOfInterest.Count > 0)
            Console.WriteLine(character.ToString()+" wants to go to "+zonesOfInterest[0].ToString());

            return zonesOfInterest;
        }

        private void Find(IZone from, IEnumerable<IItem> items, IEnumerable<ICharacter> characters, IEnumerable<IZone> zones, int distance,
            ref List<IZone> zonesOfInterest, ref List<IZone> doneZones)
        {
            if (0 > distance || doneZones.Contains(from))
                return;
                
            if(from.Items.Count != 0)
                Console.WriteLine(from.ToString());

            if (ContainsOneOf(from.Items, items) || ContainsOneOf(from.Characters, characters) || zones.Contains(from))
            {
                zonesOfInterest.Add(from);
            }

            doneZones.Add(from);

            foreach (IAccess access in from.Accesses)
            {
                Find(access.Target, items, characters, zones, distance - 1, ref zonesOfInterest, ref doneZones);
            }
        }

        private static bool ContainsOneOf<T>(ICollection<T> container, IEnumerable<T> list)
        {
            return list.Any(container.Contains);
        }
    }
}