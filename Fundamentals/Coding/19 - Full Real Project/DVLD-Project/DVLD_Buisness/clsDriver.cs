using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsPerson PersonInfo;
        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewDriverAsync()
        {
            this.DriverID = await clsDriverData.AddNewDriverAsync(PersonID, CreatedByUserID).ConfigureAwait(false);
            return (this.DriverID != -1);
        }

        private async Task<bool> _UpdateDriverAsync()
        {
            return await clsDriverData.UpdateDriverAsync(this.DriverID, this.PersonID, this.CreatedByUserID).ConfigureAwait(false);
        }

        public static async Task<clsDriver> FindByDriverIDAsync(int DriverID)
        {
            DriverDTO dto = await clsDriverData.GetDriverInfoByDriverIDAsync(DriverID).ConfigureAwait(false);
            if (dto == null) return null;
            var driver = new clsDriver(dto.DriverID, dto.PersonID, dto.CreatedByUserID, dto.CreatedDate);
            driver.PersonInfo = await clsPerson.FindAsync(dto.PersonID).ConfigureAwait(false);
            return driver;
        }

        public static async Task<clsDriver> FindByPersonIDAsync(int PersonID)
        {
            DriverDTO dto = await clsDriverData.GetDriverInfoByPersonIDAsync(PersonID).ConfigureAwait(false);
            if (dto == null) return null;
            var driver = new clsDriver(dto.DriverID, dto.PersonID, dto.CreatedByUserID, dto.CreatedDate);
            driver.PersonInfo = await clsPerson.FindAsync(dto.PersonID).ConfigureAwait(false);
            return driver;
        }

        public static async Task<DataTable> GetAllDriversAsync()
        {
            return await clsDriverData.GetAllDriversAsync().ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewDriverAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateDriverAsync().ConfigureAwait(false);
            }
            return false;
        }

        public static async Task<DataTable> GetLicensesAsync(int DriverID)
        {
            return await clsLicense.GetDriverLicensesAsync(DriverID).ConfigureAwait(false);
        }

        public static async Task<DataTable> GetInternationalLicensesAsync(int DriverID)
        {
            return await clsInternationalLicense.GetDriverInternationalLicensesAsync(DriverID).ConfigureAwait(false);
        }

        // Sync wrappers for backward compatibility
        public static clsDriver FindByDriverID(int DriverID) => FindByDriverIDAsync(DriverID).GetAwaiter().GetResult();
        public static clsDriver FindByPersonID(int PersonID) => FindByPersonIDAsync(PersonID).GetAwaiter().GetResult();
        public static DataTable GetAllDrivers() => GetAllDriversAsync().GetAwaiter().GetResult();
        public bool Save() => SaveAsync().GetAwaiter().GetResult();
        public static DataTable GetLicenses(int DriverID) => GetLicensesAsync(DriverID).GetAwaiter().GetResult();
        public static DataTable GetInternationalLicenses(int DriverID) => GetInternationalLicensesAsync(DriverID).GetAwaiter().GetResult();
    }
}
