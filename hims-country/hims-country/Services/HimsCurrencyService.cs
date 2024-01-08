
using HimsCountry.Data;
using HimsCountry.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HimsCountry.Data.Repo;
using HimsCountry.Repo.Commen;
using System.Diagnostics.Metrics;
using HimsCountry.Services;

namespace HimsCurrency.Services
{
    public class HimsCurrencyService
    {

        //private readonly IUnitOfWork unit;
        private readonly IUnitOfWork unit;
        public HimsCurrencyService(IUnitOfWork unitOfWork)
        { //injection repo in service
            unit = unitOfWork;
        }
        public async Task<List<Currency>> GetAll()
        {
            return await unit.currencyRepo.GetAll();
        }
        public async Task<Currency> GetById(int id)
        {
            var res = await unit.currencyRepo.GetById(id);
            return res;
        }
        public async Task<string> Add(Currency input)
        {

            var res = await unit.currencyRepo.Add(input);
            return res;

        }
        public async Task<string> UpdateCurrency(Currency currency)
        {
            var res = await unit.currencyRepo.UpdateCurrency(currency);
            return res;

        }
        public async Task<string> DeleteCurrency(int id)
        {
            var setting = await unit.currencyRepo.DeleteCurrency(id);
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

