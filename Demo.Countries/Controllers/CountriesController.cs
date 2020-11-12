using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Countries.Models;
using Demo.Countries.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Countries.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {        
        private readonly ILogger<CountriesController> _logger;
        public ICountryRepository _countryRepo;

        public CountriesController(ILogger<CountriesController> logger, ICountryRepository countryRepo)
        {
            _logger = logger;
            _countryRepo = countryRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
            return await _countryRepo.GetAllAsync();
        }

        [HttpPost("new")]
        public async Task New([FromBody] Country newCountry)
        {
            _countryRepo.Add(newCountry);
            await _countryRepo.SaveAsync();
        }

        [HttpPost("update")]
        public async Task Update([FromBody] Country updatedCountry)
        {
            var dbCountry = await _countryRepo.GetById(updatedCountry.Id);

            dbCountry.Name = updatedCountry.Name;
            dbCountry.Code = updatedCountry.Code;

            _countryRepo.Update(dbCountry);
            await _countryRepo.SaveAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _countryRepo.Delete(id);
            await _countryRepo.SaveAsync();
        }

    }
}
