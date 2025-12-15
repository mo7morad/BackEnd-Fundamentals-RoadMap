using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsCountry
    {
        public int ID { set; get; }
        public string CountryName { set; get; }

        public clsCountry()
        {
            this.ID = -1;
            this.CountryName = "";
        }

        private clsCountry(int ID, string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        // Async methods
        public static async Task<clsCountry> FindAsync(int ID)
        {
            CountryDTO dto = await clsCountryData.GetCountryInfoByIDAsync(ID).ConfigureAwait(false);
            if (dto == null) return null;
            return new clsCountry(dto.ID, dto.CountryName);
        }

        public static async Task<clsCountry> FindByNameAsync(string CountryName)
        {
            CountryDTO dto = await clsCountryData.GetCountryInfoByNameAsync(CountryName).ConfigureAwait(false);
            if (dto == null) return null;
            return new clsCountry(dto.ID, dto.CountryName);
        }

        public static async Task<DataTable> GetAllCountriesAsync()
        {
            return await clsCountryData.GetAllCountriesAsync().ConfigureAwait(false);
        }

        // Sync wrappers for backward compatibility
        public static clsCountry Find(int ID) => FindAsync(ID).GetAwaiter().GetResult();
        public static clsCountry Find(string CountryName) => FindByNameAsync(CountryName).GetAwaiter().GetResult();
        public static DataTable GetAllCountries() => GetAllCountriesAsync().GetAwaiter().GetResult();
    }
}
