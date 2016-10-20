using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiEF.DataLayer;
using VegiEF.Services;

namespace VegiEF
{
    class Program
    {
        static void Main(string[] args)
        {
            IVegiDataService service = new VegiDataService();

            var growableItemsList = service.GetAllGrowableItems();

            foreach (var growableItem in growableItemsList)
            {
                Console.WriteLine(growableItem.Name);
            }
         
            // Console openhouden tot er op een knop gedrukt is.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
