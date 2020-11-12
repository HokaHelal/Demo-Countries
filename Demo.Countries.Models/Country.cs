using GenericRepository.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Countries.Models
{
    public class Country : Entity<int>
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
