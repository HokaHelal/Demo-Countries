using Demo.Countries.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.Countries.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
    }
}
