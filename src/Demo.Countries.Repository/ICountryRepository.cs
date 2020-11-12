using Demo.Countries.Models;
using GenericRepository.Core;

namespace Demo.Countries.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
    }
}
