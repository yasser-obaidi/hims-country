
using HimsCountry.Services;
using HimsCountry.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace HimsCountry.Services
{


    public interface IUnitOfWork
    {

        public HimsCurrencyRepo currencyRepo { get; }
        public HimsCountryRepo countryRepo { get; }

    }



    public class UnitOfWork : IUnitOfWork
    {
        public HimsCurrencyRepo currencyRepo { get; }

        public HimsCountryRepo countryRepo { get; }
        // public HimsCountryRepo countryRepo => throw new NotImplementedException();

        public UnitOfWork(HimsCurrencyRepo Repo, HimsCountryRepo _countryRepo)
        {
            currencyRepo = Repo;
            countryRepo = _countryRepo;


        }


    }


}

