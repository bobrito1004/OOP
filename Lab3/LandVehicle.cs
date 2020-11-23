using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Lab3
{
    public class LandVehicle : Vehicle
    {
        protected int TimeUntilRest { get; set; }
        protected int RestTime { get; set; }
        public LandVehicle(string name, int speed, int TTR, int RT)
            : base(speed, name)
        {
            TimeUntilRest = TTR;
            RestTime = RT;
        }

        protected LandVehicle()
        {
            Speed = 0;
            Name = "Unknown land";
            TimeUntilRest = 0;
            RestTime = 0;
        }
        public override double Race(double distance)
        {
            var time = distance / Speed;
            if (time < TimeUntilRest || TimeUntilRest == 0)
            {
                return time;
            }
            return time + RestTime * Math.Floor(time / TimeUntilRest);
        }
    }

    public class Centaur : LandVehicle
    {
        private Centaur()
        {
            Speed = 15;
            Name = "Centaur";
            TimeUntilRest = 8;
            RestTime = 2;
        }
    }

    public class Camel : LandVehicle
    {
        public Camel()
        {
            Speed = 10;
            Name = "Camel";
            TimeUntilRest = 30;
            RestTime = 0;
        }

        public override double Race(double distance)
        {
            var time = distance / Speed;
            var restCount = Convert.ToInt32(Math.Floor(time / TimeUntilRest));
            switch (restCount)
            {
                case 0:
                    return time;
                case 1:
                    return time + 5;
                default:
                    return time + 5 + (restCount - 1) * 8;
            }
        }
    }

    public class FastCamel : LandVehicle
    {
        public FastCamel()
        {
            Speed = 40;
            Name = "Fast Camel";
            TimeUntilRest = 10;
            RestTime = 0;
        }

        public override double Race(double distance)
        {
            var time = distance / Speed;
            var restCount = Convert.ToInt32(Math.Floor(time / TimeUntilRest));
            switch (restCount)
            {
                case 0:
                    return time;
                case 1:
                    return time + 5;
                case 2:
                    return time + 11.5;
                default:
                    return time + 11.5 + (restCount - 2) * 8;
            }
        }
    }

    public class Boots : LandVehicle
    {
        public Boots()
        {
            Speed = 6;
            Name = "Boots";
            TimeUntilRest = 60;
            RestTime = 0;
        }

        public override double Race(double distance)
        {
            var time = distance / Speed;
            var restCount = Convert.ToInt32(Math.Floor(time / TimeUntilRest));
            switch (restCount)
            {
                case 0:
                    return time;
                case 1:
                    return time + 10;
                default:
                    return time + 10 + (restCount - 1) * 5;
            }
        }
    }
}