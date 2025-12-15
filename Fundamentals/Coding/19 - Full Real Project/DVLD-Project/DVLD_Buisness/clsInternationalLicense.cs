using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsInternationalLicense : clsApplication
    {
        public new enum enMode { AddNew = 0, Update = 1 };
        public new enMode Mode = enMode.AddNew;

        public clsDriver DriverInfo;
        public int InternationalLicenseID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }

        public clsInternationalLicense()
        {
            this.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        public clsInternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID,
            int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
            : base(ApplicationID, ApplicantPersonID, ApplicationDate,
                  (int)clsApplication.enApplicationType.NewInternationalLicense,
                  ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewInternationalLicenseAsync()
        {
            this.InternationalLicenseID = await clsInternationalLicenseData.AddNewInternationalLicenseAsync(
                this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID).ConfigureAwait(false);
            return (this.InternationalLicenseID != -1);
        }

        private async Task<bool> _UpdateInternationalLicenseAsync()
        {
            return await clsInternationalLicenseData.UpdateInternationalLicenseAsync(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID).ConfigureAwait(false);
        }

        public static new async Task<clsInternationalLicense> FindAsync(int InternationalLicenseID)
        {
            InternationalLicenseDTO dto = await clsInternationalLicenseData.GetInternationalLicenseInfoByIDAsync(InternationalLicenseID).ConfigureAwait(false);
            if (dto == null) return null;

            clsApplication Application = await clsApplication.FindBaseApplicationAsync(dto.ApplicationID).ConfigureAwait(false);
            if (Application == null) return null;

            var license = new clsInternationalLicense(Application.ApplicationID, Application.ApplicantPersonID,
                Application.ApplicationDate, Application.ApplicationStatus, Application.LastStatusDate,
                Application.PaidFees, Application.CreatedByUserID,
                dto.InternationalLicenseID, dto.DriverID, dto.IssuedUsingLocalLicenseID,
                dto.IssueDate, dto.ExpirationDate, dto.IsActive);
            license.DriverInfo = await clsDriver.FindByDriverIDAsync(dto.DriverID).ConfigureAwait(false);
            return license;
        }

        public static async Task<DataTable> GetAllInternationalLicensesAsync()
        {
            return await clsInternationalLicenseData.GetAllInternationalLicensesAsync().ConfigureAwait(false);
        }

        public static async Task<DataTable> GetDriverInternationalLicensesAsync(int DriverID)
        {
            return await clsInternationalLicenseData.GetDriverInternationalLicensesAsync(DriverID).ConfigureAwait(false);
        }

        public new async Task<bool> SaveAsync()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!await base.SaveAsync().ConfigureAwait(false))
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewInternationalLicenseAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateInternationalLicenseAsync().ConfigureAwait(false);
            }
            return false;
        }

        public static async Task<int> GetActiveInternationalLicenseIDByDriverIDAsync(int DriverID)
        {
            return await clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverIDAsync(DriverID).ConfigureAwait(false);
        }

        // Sync wrappers for backward compatibility
        public static new clsInternationalLicense Find(int InternationalLicenseID) => FindAsync(InternationalLicenseID).GetAwaiter().GetResult();
        public static DataTable GetAllInternationalLicenses() => GetAllInternationalLicensesAsync().GetAwaiter().GetResult();
        public static DataTable GetDriverInternationalLicenses(int DriverID) => GetDriverInternationalLicensesAsync(DriverID).GetAwaiter().GetResult();
        public new bool Save() => SaveAsync().GetAwaiter().GetResult();
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID) => GetActiveInternationalLicenseIDByDriverIDAsync(DriverID).GetAwaiter().GetResult();
    }
}
