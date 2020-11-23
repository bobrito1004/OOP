using System;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var All = new Race<Vehicle>();
            var Land = new Race<LandVehicle>();
            var car1 = new LandVehicle("camel", 10, 30, 5);
            var boot = new Boots();
            var broom = new Broom();
            var mycar = new LandVehicle("BMW", 100, 0, 0);
            All.Add(car1);
            All.Add(broom);
            All.Add(boot);
            All.Add(mycar);
            Land.Add(car1);
            Land.Add(broom);
            Land.Add(boot);
            Land.Add(mycar);
            Console.WriteLine(Land.Start(100).Name);
        }
    }
}