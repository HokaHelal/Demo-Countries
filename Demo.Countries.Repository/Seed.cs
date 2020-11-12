using Demo.Countries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Countries.Repository
{
    public class Seed
    {
        public static void CountrySeed(DataContext ctx)
        {
            if (!ctx.Countries.Any())
            {
                using (var dbContextTransaction = ctx.Database.BeginTransaction())
                {
                    var countries = new List<Country>();
                    
                    countries.Add(new Country { Name = "Afghanistan", Code = "AFG" });
                    countries.Add(new Country { Name = "Albania", Code = "ALB" });
                    countries.Add(new Country { Name = "Algeria", Code = "DZA" });
                    countries.Add(new Country { Name = "American Samoa", Code = "ASM" });
                    countries.Add(new Country { Name = "Andorra", Code = "AND" });
                    
                    ctx.Countries.AddRange(countries);                   
                    ctx.SaveChanges();
                  
                    dbContextTransaction.Commit();
                }
            }
        }

    }
}
