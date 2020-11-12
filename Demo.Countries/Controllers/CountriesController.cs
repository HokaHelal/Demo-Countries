using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Demo.Countries.Models;
using Demo.Countries.Repository;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var countryList = await _countryRepo.GetAllAsync();

                return Ok(countryList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var exMsg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                throw new System.Web.Http.HttpResponseException(exMsg);
            }
        }

        [HttpPost("new")]
        public async Task<IActionResult> New([FromBody] Country newCountry)
        {
            try
            {
                if (newCountry == null)
                {
                    return NotFound("New country cannot be null");
                }
                if (newCountry.Name == string.Empty)
                {
                    return BadRequest("Country name cannot be empty");
                }
                
                _countryRepo.Add(newCountry);
                await _countryRepo.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var exMsg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                throw new System.Web.Http.HttpResponseException(exMsg);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Country updatedCountry)
        {
            try
            {
                if (updatedCountry == null)
                {
                    return NotFound("New country cannot be null");
                }
                if (updatedCountry.Name == string.Empty)
                {
                    return BadRequest("Country name cannot be empty");
                }

                var dbCountry = await _countryRepo.GetById(updatedCountry.Id);

                if (dbCountry == null)
                {
                    return BadRequest("No country exist with following Id");
                }

                dbCountry.Name = updatedCountry.Name;
                dbCountry.Code = updatedCountry.Code;

                _countryRepo.Update(dbCountry);
                await _countryRepo.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var exMsg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                throw new System.Web.Http.HttpResponseException(exMsg);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbCountry = await _countryRepo.GetById(id);

                if (dbCountry == null)
                {
                    return BadRequest("No country exist with following Id");
                }

                await _countryRepo.Delete(id);
                await _countryRepo.SaveAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var exMsg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                throw new System.Web.Http.HttpResponseException(exMsg);
            }
        }

    }
}
