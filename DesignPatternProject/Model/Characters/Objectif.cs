namespace GHBesignPattern.Model.Characters
{

    delegate bool ObjectiveTester(ICharacter character);

    class Objectif
    {
        public bool Done;
        public ObjectiveTester ObjectiveComplete;
//        List<Objectif> Objectives;

        public Objectif(ObjectiveTester objo)
        {
            Done = null == objo ? true : false;
            ObjectiveComplete = objo;
        }
    }
}
