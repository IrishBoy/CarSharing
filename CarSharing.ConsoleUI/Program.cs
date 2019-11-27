using CarSharing.Core;
using CarSharing.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Check files in the output folder..");

            var repo = new Repository();

            //List<Car> freeCars = repo.GetFreeCars();
            List<Car> freeCars = repo.GetFreeCarsLINQOnly();
            foreach (var item in freeCars)
            {
                Console.WriteLine(item.Model.Name, " - ", item.Location.Latitude, ",", item.Location.Longitude);
            }

            repo.Save();
            Console.WriteLine("Data saved!");

            Console.ReadKey();
        }
    }
}
