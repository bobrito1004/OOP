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

        protected Vehicle()
        {
            Speed = 0;
            Name = "Unknown";
        }
        public virtual double Race(double distance)
        {
            return distance / Speed;
        }
    }
}