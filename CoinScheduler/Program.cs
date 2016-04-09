using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace CoinScheduler
{
    class Program
    {
        static CityContext context;
        public static void Main()
        {
            Timer t = new Timer(updateCoin, null, 0, 60000);
            Console.ReadLine();
        }
        public static void updateCoin(object o)
        {
            context = new CityContext();
            var city = context.Cities.ToList();
            foreach (var item in city)
            {
                item.GoldCoins++;
            }
            context.SaveChanges();
            Console.WriteLine("Coin Updated");
            GC.Collect();
        }
    }


    public class CityContext : DbContext
    {
        public CityContext() : base("CitySimulation")
        {

        }
        public DbSet<City> Cities { get; set; }
    }

    [Table("City")]
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int GoldCoins { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}
