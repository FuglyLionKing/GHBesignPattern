﻿using System.Collections.Generic;
using System.Linq;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;

namespace MedievalWarfare.MedivalWarfare.Model.Character
{
    public class TwentyOutOfTenOnBothEyesEyeSight : ISightCapabilities
    {
        private const int viewDistance = 15;

        public List<IZone> Find(ICharacter character, List<IItem> items, List<ICharacter> characters)
        {
            var zonesOfInterest = new List<IZone>();

            var doneZones = new List<IZone>();


            Find(character.Position, items, characters, viewDistance, ref zonesOfInterest, ref doneZones);

            return zonesOfInterest;
        }

        private void Find(IZone from, IEnumerable<IItem> items, IEnumerable<ICharacter> characters, int distance,
            ref List<IZone> zonesOfInterest, ref List<IZone> doneZones)
        {
            if (0 > distance || doneZones.Contains(from))
                return;

            if (ContainsOneOf(from.Items, items) || ContainsOneOf(from.Characters, characters))
            {
                zonesOfInterest.Add(from);
            }

            doneZones.Add(from);

            foreach (IAccess access in from.Accesses)
            {
                Find(from, items, characters, distance - 1, ref zonesOfInterest, ref doneZones);
            }
        }

        private static bool ContainsOneOf<T>(ICollection<T> container, IEnumerable<T> list)
        {
            return list.Any(container.Contains);
        }
    }
}