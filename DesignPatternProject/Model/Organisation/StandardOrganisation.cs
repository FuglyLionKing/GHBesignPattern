using GHBesignPattern.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHBesignPattern.Model.Organisation
{
    abstract class StandardOrganisation : IObservee
    {
        protected List<IObserver> observerList = new List<IObserver>();
        
        public void Update()
        {
            foreach (IObserver observer in observerList)
                observer.Update();
        }

        public void Attach(IObserver obs)
        {
            if(!this.observerList.Contains(obs))
                this.observerList.Add(obs);
        }

        public void Detach(IObserver obs)
        {
            this.observerList.Remove(obs);
        }
    }
}
