using System;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var Land = new Race<Vehicle>();
            var car1 = new LandVehicle("camel", 20, 30, 5);
            Land.Add(car1);
            var boot = new Boots();
            var broom = new Broom();
            var mycar = new LandVehicle("BMW", 100, 0, 0);
            Land.Add(broom);
            Land.Add(boot);
            Land.Add(mycar);
            Console.WriteLine(Land.Start(100).Name);
        }
    }
}