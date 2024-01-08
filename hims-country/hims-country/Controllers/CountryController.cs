using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HimsCountry.Data.Entities;
using HimsCountry.Data.Repo;
using HimsCountry.Data.Repo;
using HimsCountry.Services;
using HimsCountry.Data;


namespace HimsCountry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly HimsCountryRepo _Repo;
        private readonly HimsCountryService service;

        public CountryController(HimsCountryRepo countryRepo, HimsCountryService countryService)
        {
            _Repo = countryRepo;
            service = countryService;


        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _Repo.GetAll());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await service.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(Country input)
        {
            try
            {
                var res = await service.Add(input);

                return Ok(res);

                // return await service.Add(input);

                //return Ok(res);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //await _Repo.Add(input);
            //return Ok("ok");

        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateCountry(Country input)
        {
            try
            {
                var res = await service.UpdateCountry(input);

                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //var res = await _Repo.UpdateSetting(input);

            //return Ok(res);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int input)
        {
            try
            {
                return Ok(await service.DeleteCountry(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //var res = await _Repo.DeleteSetting(input);

            //return Ok(res);

        }

    }
}
