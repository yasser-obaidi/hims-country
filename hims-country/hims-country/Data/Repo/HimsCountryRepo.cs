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


    public class HimsCountryRepo : Repository<Country>
    {
        public HimsCountryRepo(Context context) : base(context)
        {

        }
        public async Task<List<Country>> GetAll()
        {
            return await Get().ToListAsync();
        }
        public async Task<Country> GetById(int id)
        {
            var result = await context.Countries
                .FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                return await context.Countries
                .FirstOrDefaultAsync(e => e.Id == id);

            }
            throw new Exception("id not found");
        }
        public async Task<string> Add(Country input)
        {
            await AddAsync(input);
            await context.SaveChangesAsync();
            return "Added successfully";
        }
        public async Task<string> UpdateCountry(Country country)
        {
            var result = await context.Countries
                .FirstOrDefaultAsync(e => e.Id == country.Id);

            if (result != null)
            {
                result.Name = country.Name;
                result.NumericIsoCode = country.NumericIsoCode;
                result.DisplayOrder = country.DisplayOrder;
                result.ThreeLetterIsoCode = country.ThreeLetterIsoCode;
                result.IsActive = country.IsActive;
                


                var res = await context.SaveChangesAsync();
                if (res > 0)
                {

                    return "updated ";
                }
                else
                {
                    throw new Exception("not updated");
                    // return "not updated";
                }
            }
            //return "id not found";
            throw new Exception("id not found");

        }
        public async Task<string> DeleteCountry(int id)
        {
            var country = await context.Countries.FindAsync(id);
            if (country != null)
            {
                context.Countries.Remove(country);
                await context.SaveChangesAsync();
                return "deleted successfully";
            }
            throw new Exception("not deleted");
        }
    }
}
