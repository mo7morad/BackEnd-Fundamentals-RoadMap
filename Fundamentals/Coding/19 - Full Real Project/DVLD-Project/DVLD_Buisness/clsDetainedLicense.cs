using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }
        public float FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUser CreatedByUserInfo { set; get; }
        public bool IsReleased { set; get; }
        public DateTime ReleaseDate { set; get; }
        public int ReleasedByUserID { set; get; }
        public clsUser ReleasedByUserInfo { set; get; }
        public int ReleaseApplicationID { set; get; }

        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MaxValue;
            this.ReleasedByUserID = 0;
            this.ReleaseApplicationID = -1;
            Mode = enMode.AddNew;
        }

        public clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID, bool IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewDetainedLicenseAsync()
        {
            this.DetainID = await clsDetainedLicenseData.AddNewDetainedLicenseAsync(
                this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID).ConfigureAwait(false);
            return (this.DetainID != -1);
        }

        private async Task<bool> _UpdateDetainedLicenseAsync()
        {
            return await clsDetainedLicenseData.UpdateDetainedLicenseAsync(
                this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID).ConfigureAwait(false);
        }

        public static async Task<clsDetainedLicense> FindAsync(int DetainID)
        {
            DetainedLicenseDTO dto = await clsDetainedLicenseData.GetDetainedLicenseInfoByIDAsync(DetainID).ConfigureAwait(false);
            if (dto == null) return null;
            var detained = new clsDetainedLicense(dto.DetainID, dto.LicenseID, dto.DetainDate,
                dto.FineFees, dto.CreatedByUserID, dto.IsReleased, dto.ReleaseDate,
                dto.ReleasedByUserID, dto.ReleaseApplicationID);
            detained.CreatedByUserInfo = await clsUser.FindByUserIDAsync(dto.CreatedByUserID).ConfigureAwait(false);
            if (dto.ReleasedByUserID != -1)
                detained.ReleasedByUserInfo = await clsUser.FindByUserIDAsync(dto.ReleasedByUserID).ConfigureAwait(false);
            return detained;
        }

        public static async Task<clsDetainedLicense> FindByLicenseIDAsync(int LicenseID)
        {
            DetainedLicenseDTO dto = await clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseIDAsync(LicenseID).ConfigureAwait(false);
            if (dto == null) return null;
            var detained = new clsDetainedLicense(dto.DetainID, dto.LicenseID, dto.DetainDate,
                dto.FineFees, dto.CreatedByUserID, dto.IsReleased, dto.ReleaseDate,
                dto.ReleasedByUserID, dto.ReleaseApplicationID);
            detained.CreatedByUserInfo = await clsUser.FindByUserIDAsync(dto.CreatedByUserID).ConfigureAwait(false);
            if (dto.ReleasedByUserID != -1)
                detained.ReleasedByUserInfo = await clsUser.FindByUserIDAsync(dto.ReleasedByUserID).ConfigureAwait(false);
            return detained;
        }

        public static async Task<DataTable> GetAllDetainedLicensesAsync()
        {
            return await clsDetainedLicenseData.GetAllDetainedLicensesAsync().ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewDetainedLicenseAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateDetainedLicenseAsync().ConfigureAwait(false);
            }
            return false;
        }

        public static async Task<bool> IsLicenseDetainedAsync(int LicenseID)
        {
            return await clsDetainedLicenseData.IsLicenseDetainedAsync(LicenseID).ConfigureAwait(false);
        }

        public async Task<bool> ReleaseDetainedLicenseAsync(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return await clsDetainedLicenseData.ReleaseDetainedLicenseAsync(
                this.DetainID, ReleasedByUserID, ReleaseApplicationID).ConfigureAwait(false);
        }

        // Sync wrappers for backward compatibility
        public static clsDetainedLicense Find(int DetainID) => FindAsync(DetainID).GetAwaiter().GetResult();
        public static clsDetainedLicense FindByLicenseID(int LicenseID) => FindByLicenseIDAsync(LicenseID).GetAwaiter().GetResult();
        public static DataTable GetAllDetainedLicenses() => GetAllDetainedLicensesAsync().GetAwaiter().GetResult();
        public bool Save() => SaveAsync().GetAwaiter().GetResult();
        public static bool IsLicenseDetained(int LicenseID) => IsLicenseDetainedAsync(LicenseID).GetAwaiter().GetResult();
        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID) => ReleaseDetainedLicenseAsync(ReleasedByUserID, ReleaseApplicationID).GetAwaiter().GetResult();
    }
}
