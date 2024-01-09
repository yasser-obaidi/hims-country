using HimsCountry.Data;
using HimsCountry.Data.Entities;
using HimsCountry.Repo.Commen;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using MySqlX.XDevAPI.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using HimsCountry.Data.Entities;

namespace HimsCountry.Data.Repo
{


    public class HimsCurrencyRepo : Repository<Currency>
    {
        public HimsCurrencyRepo(Context context) : base(context)
        {

        }
        public async Task<List<Currency>> GetAll()
        {
            return await Get().ToListAsync();
        }
        public async Task<Currency> GetById(int id)
        {
            var result = await context.Currencies
                .FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                return await context.Currencies
                .FirstOrDefaultAsync(e => e.Id == id);

            }
            throw new Exception("id not found");
        }
        public async Task<string> Add(Currency input)
        {
            await AddAsync(input);
            await context.SaveChangesAsync();
            return "Added successfully";
        }
        public async Task<string> UpdateCurrency(Currency currency)
        {
            var result = await context.Currencies
                .FirstOrDefaultAsync(e => e.Id == currency.Id);

            if (result != null)
            {
                result.Name = currency.Name;
                result.CurrencyCode = currency.CurrencyCode;
                result.DisplayOrder = currency.DisplayOrder;
                result.DisplayLocale = currency.DisplayLocale;
                result.IsActive = currency.IsActive;
                result.IsDefault = currency.IsDefault;


                var res = await context.SaveChangesAsync();
                if (res > 0)
                {

                    return "updated ";
                }
                else
                {
                    throw new Exception("not updated");
                     
                }
            }
            
            throw new Exception("id not found");

        }
        public async Task<string> DeleteCurrency(int id)
        {
            var setting = await context.Currencies.FindAsync(id);
            if (setting != null)
            {
                context.Currencies.Remove(setting);
                await context.SaveChangesAsync();
                return "deleted successfully";
            }
            throw new Exception("not deleted");
        }
    }
}
