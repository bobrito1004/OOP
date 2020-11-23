using System;
using System.Security.Cryptography;

namespace Lab3
{
    public class AirVehicle : Vehicle
    {
        public AirVehicle(int speed, string name)
            : base(speed, name)
        {
        }

        protected AirVehicle()
        {
            Speed = 0;
            Name = "Unknown Air";
        }

        public override double Race(double distance)
        {
            var dist = Convert.ToInt32(Math.Floor(distance / 1000));
            var ans = 0.0;
            for (int i = 0; i < dist; i++)
            {
                ans += 10 * (100 - i);
            }
            ans += (distance - dist * 1000) * (100 - dist);
            return ans;
        }
    }

    public class Broom : AirVehicle
    {
        public Broom()
        {
            Speed = 20;
            Name = "Broom";
        }
    }

    public class Carpet : AirVehicle
    {
        public Carpet()
        {
            Speed = 10;
            Name = "Carpet";
        }

        public override double Race(double distance)
        {
            if (distance < 1000)
            {
                return distance;
            }

            if (distance < 5000)
            {
                return distance - (distance / 100) * 3;
            }

            if (distance < 10000)
            {
                return distance - (distance / 10);
            }
            return distance - (distance / 20);
        }
    }

    public class Stupa : AirVehicle
    {
        public Stupa()
        {
            Speed = 8;
            Name = "Stupa";
        }

        public override double Race(double distance)
        {
            return distance - (distance / 100) * 6;
        }
    }
}