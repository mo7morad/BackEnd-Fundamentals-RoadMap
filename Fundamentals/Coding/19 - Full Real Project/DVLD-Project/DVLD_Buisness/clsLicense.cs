using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using System.Xml.Linq;
using DVLD_DataAccess;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Buisness
{
    public class clsLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public clsDriver DriverInfo;
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClass { set; get; }
        public clsLicenseClass LicenseClassIfo;
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public string IssueReasonText => GetIssueReasonText(this.IssueReason);
        public clsDetainedLicense DetainedInfo { set; get; }
        public int CreatedByUserID { set; get; }
        public async Task<bool> IsDetainedAsync()
        {
            return await clsDetainedLicense.IsLicenseDetainedAsync(this.LicenseID).ConfigureAwait(false);
        }

        public clsLicense()

        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)

        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewLicenseAsync()
        {
            this.LicenseID = await clsLicenseData.AddNewLicenseAsync(
                this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, (byte)this.IssueReason, this.CreatedByUserID).ConfigureAwait(false);
            return (this.LicenseID != -1);
        }

        private async Task<bool> _UpdateLicenseAsync()
        {
            return await clsLicenseData.UpdateLicenseAsync(
                this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
                this.IsActive, (byte)this.IssueReason, this.CreatedByUserID).ConfigureAwait(false);
        }

        public static async Task<clsLicense> FindAsync(int LicenseID)
        {
            LicenseDTO dto = await clsLicenseData.GetLicenseInfoByIDAsync(LicenseID).ConfigureAwait(false);
            if (dto == null) return null;
            var license = new clsLicense(dto.LicenseID, dto.ApplicationID, dto.DriverID, dto.LicenseClass,
                dto.IssueDate, dto.ExpirationDate, dto.Notes, dto.PaidFees,
                dto.IsActive, (enIssueReason)dto.IssueReason, dto.CreatedByUserID);
            license.DriverInfo = await clsDriver.FindByDriverIDAsync(dto.DriverID).ConfigureAwait(false);
            license.LicenseClassIfo = await clsLicenseClass.FindAsync(dto.LicenseClass).ConfigureAwait(false);
            license.DetainedInfo = await clsDetainedLicense.FindByLicenseIDAsync(dto.LicenseID).ConfigureAwait(false);
            return license;
        }

        public static async Task<DataTable> GetAllLicensesAsync()
        {
            return await clsLicenseData.GetAllLicensesAsync().ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewLicenseAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateLicenseAsync().ConfigureAwait(false);
            }
            return false;
        }

        public static async Task<bool> IsLicenseExistByPersonIDAsync(int PersonID, int LicenseClassID)
        {
            return (await GetActiveLicenseIDByPersonIDAsync(PersonID, LicenseClassID).ConfigureAwait(false)) != -1;
        }

        public static async Task<int> GetActiveLicenseIDByPersonIDAsync(int PersonID, int LicenseClassID)
        {
            return await clsLicenseData.GetActiveLicenseIDByPersonIDAsync(PersonID, LicenseClassID).ConfigureAwait(false);
        }

        public static async Task<DataTable> GetDriverLicensesAsync(int DriverID)
        {
            return await clsLicenseData.GetDriverLicensesAsync(DriverID).ConfigureAwait(false);
        }

        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }

        public async Task<bool> DeactivateCurrentLicenseAsync()
        {
            return await clsLicenseData.DeactivateLicenseAsync(this.LicenseID).ConfigureAwait(false);
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public async Task<int> DetainAsync(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToSingle(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!await detainedLicense.SaveAsync().ConfigureAwait(false))
                return -1;

            return detainedLicense.DetainID;
        }

        public async Task<(bool Success, int ApplicationID)> ReleaseDetainedLicenseAsync(int ReleasedByUserID)
        {
            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            var appType = await clsApplicationType.FindAsync((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ConfigureAwait(false);
            Application.PaidFees = appType.Fees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!await Application.SaveAsync().ConfigureAwait(false))
                return (false, -1);

            bool released = await this.DetainedInfo.ReleaseDetainedLicenseAsync(ReleasedByUserID, Application.ApplicationID).ConfigureAwait(false);
            return (released, Application.ApplicationID);
        }

        public async Task<clsLicense> RenewLicenseAsync(string Notes, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            var appType = await clsApplicationType.FindAsync((int)clsApplication.enApplicationType.RenewDrivingLicense).ConfigureAwait(false);
            Application.PaidFees = appType.Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!await Application.SaveAsync().ConfigureAwait(false))
                return null;

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassIfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassIfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!await NewLicense.SaveAsync().ConfigureAwait(false))
                return null;

            await DeactivateCurrentLicenseAsync().ConfigureAwait(false);
            return NewLicense;
        }

        public async Task<clsLicense> ReplaceAsync(enIssueReason IssueReason, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            var appType = await clsApplicationType.FindAsync(Application.ApplicationTypeID).ConfigureAwait(false);
            Application.PaidFees = appType.Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!await Application.SaveAsync().ConfigureAwait(false))
                return null;

            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!await NewLicense.SaveAsync().ConfigureAwait(false))
                return null;

            await DeactivateCurrentLicenseAsync().ConfigureAwait(false);
            return NewLicense;
        }

        // Sync wrappers for backward compatibility
        public static clsLicense Find(int LicenseID) => FindAsync(LicenseID).GetAwaiter().GetResult();
        public static DataTable GetAllLicenses() => GetAllLicensesAsync().GetAwaiter().GetResult();
        public bool Save() => SaveAsync().GetAwaiter().GetResult();
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID) => IsLicenseExistByPersonIDAsync(PersonID, LicenseClassID).GetAwaiter().GetResult();
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID) => GetActiveLicenseIDByPersonIDAsync(PersonID, LicenseClassID).GetAwaiter().GetResult();
        public static DataTable GetDriverLicenses(int DriverID) => GetDriverLicensesAsync(DriverID).GetAwaiter().GetResult();
        public bool DeactivateCurrentLicense() => DeactivateCurrentLicenseAsync().GetAwaiter().GetResult();
        public bool IsDetained() => IsDetainedAsync().GetAwaiter().GetResult();
        public int Detain(float FineFees, int CreatedByUserID) => DetainAsync(FineFees, CreatedByUserID).GetAwaiter().GetResult();
        public int ReleaseDetainedLicense(int ReleasedByUserID) { var result = ReleaseDetainedLicenseAsync(ReleasedByUserID).GetAwaiter().GetResult(); return result.ApplicationID; }
        public clsLicense RenewLicense(string Notes, int CreatedByUserID) => RenewLicenseAsync(Notes, CreatedByUserID).GetAwaiter().GetResult();
        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID) => ReplaceAsync(IssueReason, CreatedByUserID).GetAwaiter().GetResult();
    }
}
