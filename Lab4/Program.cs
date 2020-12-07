using System;
using System.Runtime.InteropServices;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var bu = new Backup();
            var createAlg = new CreateNormalPoint();
            bu.SetAlg(new RemovePointLimits());
            bu.CreatePoint(createAlg);
            var bf = new BackupFile("D:\\Games\\Steam\\steam.dll");
            Console.WriteLine(bf.Info.Length);
            bu.Add("D:\\Games\\Steam\\steam.dll");
            bu.Refresh();
            Console.WriteLine(bu.Files.Count);
            
        }
    }
}