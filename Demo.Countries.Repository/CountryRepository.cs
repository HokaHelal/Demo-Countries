using Demo.Countries.Models;
using GenericRepository;

namespace Demo.Countries.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private DataContext _ctx;

        public CountryRepository(DataContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
