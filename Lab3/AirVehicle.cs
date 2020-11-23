using System;
using System.Security.Cryptography;

namespace Lab3
{
    public class AirVehicle : Vehicle
    {
        public AirVehicle(string name, int speed) : base(speed, name)
        {
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
        public Broom() : base("Broom", 20)
        {
            Speed = 20;
            Name = "Broom";
        }
    }

    public class Carpet : AirVehicle
    {
        public Carpet() : base("Carpet", 10)
        {
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
        public Stupa() : base("Stupa", 8)
        {
        }

        public override double Race(double distance)
        {
            return distance - (distance / 100) * 6;
        }
    }
}