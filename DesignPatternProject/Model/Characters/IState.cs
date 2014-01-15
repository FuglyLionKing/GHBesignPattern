using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationV1.Model.Characters
{
    abstract class State
    {
        IReadOnlyList<string> validValues { get; }
        string value { get; set; }

        public static bool operator ==(State me, State other)
        {
            if (me == null) return other == null;
            return (me.GetType() == other.GetType()) && (me == other);
        }


    }
}
