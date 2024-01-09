
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
            var existingName = unit.currencyRepo.context
                .Currencies.FirstOrDefault(i => i.Name == input.Name);

            var existingCurrencyCode= unit.currencyRepo.context
                .Currencies.FirstOrDefault(i => i.CurrencyCode == input.CurrencyCode);

            
            if (existingName != null)
            {
                throw new Exception("Name  already exist");
            }
            if (existingCurrencyCode != null)
            {
                throw new Exception("Currency Code  already exist");
            }

            if (input.CurrencyCode == "LYD")
            {
                input.IsDefault = true;
                var res = await unit.currencyRepo.Add(input);
                return res;
            }
            input.IsDefault = false;
            var result = await unit.currencyRepo.Add(input);
            return result;


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
         

    }
}

