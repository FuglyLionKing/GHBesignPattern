using System;
using GHBesignPattern.Controller.Statistic;

namespace GHBesignPattern.Controller.Simulation
{

    public class SimpleSimulationRunner : ISimulationRunner 
    {
        private IDisplayer _displayer;
        private ISimulation _simulation;
        private IStatisticsCollector _statCollector;
        //milliseconds
        public int Rate = 1000;


        public IDisplayer Displayer
        {
            set { _displayer = value; }
        }

        public ISimulation Simulation
        {
            set { _simulation = value; }
        }

        public IStatisticsCollector StatCollector
        {
            set { _statCollector = value; }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        void ISimulationRunner.Start()
        {
            if (null == _simulation)
                return;

            bool run = true;

            int late = 0;

            while (run)
            {
                DateTime start = System.DateTime.UtcNow;

                _simulation.Update();
                _simulation.UpdatePapaBear();
                _simulation.MoveAll();
                _simulation.AnalyzeSituation();
                _simulation.CombatAll();
                _simulation.UpdateObjects();

                if (null != _statCollector)
                {
                    _statCollector.CollectInformation(_simulation.Characters);
                    _statCollector.UdateStatistics();
                }

                if (null != _displayer)
                    _displayer.UpdateDisplay();

                run = !IsFinished();

                int sleepingSpan = Rate - late - (int) (System.DateTime.UtcNow - start).TotalMilliseconds;

                if (0 > sleepingSpan)
                {
                    System.Threading.Thread.Sleep(sleepingSpan);
                }
                else
                {
                    late = -sleepingSpan;
                }
            }
        }

        private bool IsFinished()
        {
            return false;
        }
    }

}