using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Race<T> where T : Vehicle
    {
        private List<T> Contestants = new List<T>();

        public void Add(T v)
        {
            Contestants.Add(v);
        }
        
        public Vehicle Start(double distance)
        {
            if (Contestants.Count == 0)
            {
                throw new Exception("Никто не пришёл на гоночки((");
            }
            var best = Double.MaxValue;
            Vehicle winner = new Camel();
            foreach (var v in Contestants)
            {
                var t = v.Race(distance);
                if (!(t < best)) continue;
                best = t;
                winner = v;
            }
            return winner;
        }
    }
}