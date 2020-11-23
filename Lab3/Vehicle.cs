using System;

namespace Lab3
{
    public abstract class Vehicle
    {
        public int Speed { get; set; }
        public string Name { get; set; }

        protected Vehicle(int speed, string name)
        {
            if (speed < 0)
            {
                throw new Exception("Speed can`t be negative");
            }

            Speed = speed;
            Name = name;
        }

        public virtual double Race(double distance)
        {
            return distance / Speed;
        }
    }
}