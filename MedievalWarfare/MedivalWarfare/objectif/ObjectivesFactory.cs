using System.Collections.Generic;
using GHBesignPattern.Model.Characters;
using GHBesignPattern.Model.Items;

namespace MedievalWarfare.MedivalWarfare.objectif
{
    public class ObjectivesFactory
    {
        public static ObjectiveTester PickUpObjectif(IItem item)
        {
            return
                charac => charac.Items.Contains(item);
        }


        public static List<Objectif> GenerateObjectivesFrom(List<IItem> items, int desiredNumber)
        {
            var ans = new List<Objectif>();

            for (; 0 < desiredNumber; desiredNumber--)
            {
                IItem item = items[desiredNumber%items.Count];
                var obj = new Objectif(PickUpObjectif(item)) {target = item};
                ans.Add(obj);
            }


            return ans;
        }
    }
}