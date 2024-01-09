
    
using HimsCountry.Data;
using HimsCountry.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HimsCountry.Data.Repo;
using HimsCountry.Repo.Commen;
using System.Diagnostics.Metrics;


namespace HimsCountry.Services
    {
        public class HimsCountryService
    {

             
            private readonly IUnitOfWork unit;
            public HimsCountryService(IUnitOfWork unitOfWork)
            { //injection repo in service
                unit = unitOfWork;
            }
            public async Task<List<Country>> GetAll()
            {
                return await unit.countryRepo.GetAll();
            }
            public async Task<Country> GetById(int id)
            {
                var res = await unit.countryRepo.GetById(id);
                return res;
            }
        public async Task<string> Add(Country input)
        {
            var existingName = unit.countryRepo.context
                .Countries.FirstOrDefault(i => i.Name == input.Name);
            var existingThreeLetterIsoCode = unit.countryRepo.context
                .Countries.FirstOrDefault(i => i.ThreeLetterIsoCode == input.ThreeLetterIsoCode);
            var existingNumericIsoCode = unit.countryRepo.context
               .Countries.FirstOrDefault(i => i.NumericIsoCode == input.NumericIsoCode);

            
            
            if (existingName != null)
            {
                throw new Exception("Name  already exist");
            }
            if (existingThreeLetterIsoCode != null)
            {
                throw new Exception("ThreeLetterIsoCode  already exist");
            }

            if (existingNumericIsoCode != null)
            {
                throw new Exception("NumericIsoCode  already exist");
            }
            var res = await unit.countryRepo.Add(input);
            return res;






        }
        public async Task<string> UpdateCountry(Country country)
            {
                var res = await unit.countryRepo.UpdateCountry(country);
                return res;

            }
            public async Task<string> DeleteCountry(int id)
            {
                var setting = await unit.countryRepo.DeleteCountry(id);
                return setting;
            }
             

        }
    }



