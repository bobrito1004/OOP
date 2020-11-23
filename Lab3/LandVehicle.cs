using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Lab3
{
    public class LandVehicle : Vehicle
    {
        protected int TimeUntilRest;
        protected int RestTime;

        public LandVehicle(string name, int speed, int TTR, int RT)
            : base(speed, name)
        {
            TimeUntilRest = TTR;
            RestTime = RT;
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
        private Centaur() : base("Centaur", 15, 8, 2)
        {
        }
    }

    public class Camel : LandVehicle
    {
        public Camel() : base("Camel", 10, 30, 0)
        {
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
        public FastCamel() : base("Fast Camel", 40, 10, 0)
        {
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
        public Boots() : base("Boots", 6, 60, 0)
        {
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