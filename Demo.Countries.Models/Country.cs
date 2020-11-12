using GenericRepository.Model;
using System;

namespace Demo.Countries.Models
{
    public class Country : Entity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
