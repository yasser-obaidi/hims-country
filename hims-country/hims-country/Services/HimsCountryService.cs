
    
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

            //private readonly IUnitOfWork unit;
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
            /*public async Task<Setting> GetByName(string setting)
            {

                var result = await unit.SystemSettings.GetByName(setting);
                if (result != null)
                {
                    var existingMemberNo =
                    unit.SystemSettings.context.Settings.FirstOrDefault(i => i.Name == setting);

                    var res = await unit.SystemSettings.GetByName(setting);
                    return res;
                }
                throw new Exception("name is not found");

            }

            public async Task<Setting> GetById(int id)
            {
                var res = await unit.SystemSettings.GetById2(id);
                return res;
            }


            public async Task<string> Add(Setting input)
            {

                var res = await unit.SystemSettings.Add(input);
                return res;

            }




            public async Task<string> DeleteSetting(int id)
            {
                var setting = await unit.SystemSettings.DeleteSetting(id);
                return setting;
            }

            public async Task<string> UpdateSetting(Setting setting)
            {
                var res = await unit.SystemSettings.UpdateSetting(setting);
                return res;

            }

            //var result = await unit.SystemSettings.GetByName(setting);
            //    return result;

        }
    */

        }
    }



