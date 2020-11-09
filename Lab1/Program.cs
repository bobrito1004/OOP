using System;
using System.Collections.Generic;

namespace lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var ip1 = new IniParser("asdsadasd");
                //var ip2 = new IniParser();
                //ip2.set_path(AppContext.BaseDirectory + "test.txt");
                Console.WriteLine("Enter a category to look at:");
                var cat = Console.ReadLine();
                Console.WriteLine("Enter a key to look for:");
                var key = Console.ReadLine();
                Console.WriteLine("Enter the DataType of this key: ");
                var dtype = Console.ReadLine();
                switch (dtype)
                {
                    case "int":
                        Console.WriteLine(ip1.find_int(cat, key));
                        break;
                    case "float":
                        Console.WriteLine(ip1.find_float(cat, key));
                        break;
                    case "string":
                        Console.WriteLine(ip1.find_string(cat, key));
                        break;
                    default:
                        throw new Exception($"There is no {dtype} datatype");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}