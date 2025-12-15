using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public new enum enMode { AddNew = 0, Update = 1 };
        public new enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { set; get; }
        public clsLicenseClass LicenseClassInfo;

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
            Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID, int LicenseClassID)
            : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                  ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewLocalDrivingLicenseApplicationAsync()
        {
            this.LocalDrivingLicenseApplicationID = await clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplicationAsync(
                this.ApplicationID, this.LicenseClassID).ConfigureAwait(false);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private async Task<bool> _UpdateLocalDrivingLicenseApplicationAsync()
        {
            return await clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplicationAsync(
                this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID).ConfigureAwait(false);
        }

        public static async Task<clsLocalDrivingLicenseApplication> FindByLocalDrivingAppLicenseIDAsync(int LocalDrivingLicenseApplicationID)
        {
            LocalDrivingLicenseApplicationDTO dto = await clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByIDAsync(LocalDrivingLicenseApplicationID).ConfigureAwait(false);
            if (dto == null) return null;

            clsApplication Application = await clsApplication.FindBaseApplicationAsync(dto.ApplicationID).ConfigureAwait(false);
            if (Application == null) return null;

            var app = new clsLocalDrivingLicenseApplication(
                dto.LocalDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID,
                Application.ApplicationDate, Application.ApplicationTypeID,
                Application.ApplicationStatus, Application.LastStatusDate,
                Application.PaidFees, Application.CreatedByUserID, dto.LicenseClassID);
            app.LicenseClassInfo = await clsLicenseClass.FindAsync(dto.LicenseClassID).ConfigureAwait(false);
            return app;
        }

        public static async Task<clsLocalDrivingLicenseApplication> FindByApplicationIDAsync(int ApplicationID)
        {
            LocalDrivingLicenseApplicationDTO dto = await clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationIDAsync(ApplicationID).ConfigureAwait(false);
            if (dto == null) return null;

            clsApplication Application = await clsApplication.FindBaseApplicationAsync(dto.ApplicationID).ConfigureAwait(false);
            if (Application == null) return null;

            var app = new clsLocalDrivingLicenseApplication(
                dto.LocalDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID,
                Application.ApplicationDate, Application.ApplicationTypeID,
                Application.ApplicationStatus, Application.LastStatusDate,
                Application.PaidFees, Application.CreatedByUserID, dto.LicenseClassID);
            app.LicenseClassInfo = await clsLicenseClass.FindAsync(dto.LicenseClassID).ConfigureAwait(false);
            return app;
        }

        public async Task<string> GetPersonFullNameAsync()
        {
            var person = await clsPerson.FindAsync(ApplicantPersonID).ConfigureAwait(false);
            return person?.FullName ?? "";
        }

        public new async Task<bool> SaveAsync()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!await base.SaveAsync().ConfigureAwait(false))
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewLocalDrivingLicenseApplicationAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateLocalDrivingLicenseApplicationAsync().ConfigureAwait(false);
            }
            return false;
        }

        public static async Task<DataTable> GetAllLocalDrivingLicenseApplicationsAsync()
        {
            return await clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationsAsync().ConfigureAwait(false);
        }

        public new async Task<bool> DeleteAsync()
        {
            bool IsLocalDrivingApplicationDeleted = await clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplicationAsync(this.LocalDrivingLicenseApplicationID).ConfigureAwait(false);
            if (!IsLocalDrivingApplicationDeleted) return false;
            return await base.DeleteAsync().ConfigureAwait(false);
        }

        public async Task<bool> DoesPassTestTypeAsync(clsTestType.enTestType TestTypeID)
        {
            return await clsLocalDrivingLicenseApplicationData.DoesPassTestTypeAsync(this.LocalDrivingLicenseApplicationID, (int)TestTypeID).ConfigureAwait(false);
        }

        public async Task<bool> DoesPassPreviousTestAsync(clsTestType.enTestType CurrentTestType)
        {
            switch (CurrentTestType)
            {
                case clsTestType.enTestType.VisionTest: return true;
                case clsTestType.enTestType.WrittenTest: return await DoesPassTestTypeAsync(clsTestType.enTestType.VisionTest).ConfigureAwait(false);
                case clsTestType.enTestType.StreetTest: return await DoesPassTestTypeAsync(clsTestType.enTestType.WrittenTest).ConfigureAwait(false);
                default: return false;
            }
        }

        public async Task<bool> DoesAttendTestTypeAsync(clsTestType.enTestType TestTypeID)
        {
            return await clsLocalDrivingLicenseApplicationData.DoesAttendTestTypeAsync(this.LocalDrivingLicenseApplicationID, (int)TestTypeID).ConfigureAwait(false);
        }

        public async Task<byte> TotalTrialsPerTestAsync(clsTestType.enTestType TestTypeID)
        {
            return await clsLocalDrivingLicenseApplicationData.TotalTrialsPerTestAsync(this.LocalDrivingLicenseApplicationID, (int)TestTypeID).ConfigureAwait(false);
        }

        public static async Task<bool> IsThereAnActiveScheduledTestAsync(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return await clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTestAsync(LocalDrivingLicenseApplicationID, (int)TestTypeID).ConfigureAwait(false);
        }

        public async Task<clsTest> GetLastTestPerTestTypeAsync(clsTestType.enTestType TestTypeID)
        {
            return await clsTest.FindLastTestPerPersonAndLicenseClassAsync(this.ApplicantPersonID, this.LicenseClassID, TestTypeID).ConfigureAwait(false);
        }

        public async Task<byte> GetPassedTestCountAsync()
        {
            return await clsTest.GetPassedTestCountAsync(this.LocalDrivingLicenseApplicationID).ConfigureAwait(false);
        }

        public async Task<bool> PassedAllTestsAsync()
        {
            return await clsTest.PassedAllTestsAsync(this.LocalDrivingLicenseApplicationID).ConfigureAwait(false);
        }

        public async Task<int> IssueLicenseForTheFirstTimeAsync(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;
            clsDriver Driver = await clsDriver.FindByPersonIDAsync(this.ApplicantPersonID).ConfigureAwait(false);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (await Driver.SaveAsync().ConfigureAwait(false))
                    DriverID = Driver.DriverID;
                else
                    return -1;
            }
            else
            {
                DriverID = Driver.DriverID;
            }

            clsLicense License = new clsLicense();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (await License.SaveAsync().ConfigureAwait(false))
            {
                await this.SetCompleteAsync().ConfigureAwait(false);
                return License.LicenseID;
            }
            return -1;
        }

        public async Task<bool> IsLicenseIssuedAsync()
        {
            return (await GetActiveLicenseIDAsync().ConfigureAwait(false)) != -1;
        }

        public async Task<int> GetActiveLicenseIDAsync()
        {
            return await clsLicense.GetActiveLicenseIDByPersonIDAsync(this.ApplicantPersonID, this.LicenseClassID).ConfigureAwait(false);
        }

        // Sync wrappers for backward compatibility
        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            return FindByLocalDrivingAppLicenseIDAsync(LocalDrivingLicenseApplicationID).GetAwaiter().GetResult();
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            return FindByApplicationIDAsync(ApplicationID).GetAwaiter().GetResult();
        }

        public string PersonFullName => GetPersonFullNameAsync().GetAwaiter().GetResult();

        public new bool Save()
        {
            return SaveAsync().GetAwaiter().GetResult();
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return GetAllLocalDrivingLicenseApplicationsAsync().GetAwaiter().GetResult();
        }

        public new bool Delete()
        {
            return DeleteAsync().GetAwaiter().GetResult();
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return DoesPassTestTypeAsync(TestTypeID).GetAwaiter().GetResult();
        }

        public bool DoesPassPreviousTest(clsTestType.enTestType CurrentTestType)
        {
            return DoesPassPreviousTestAsync(CurrentTestType).GetAwaiter().GetResult();
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return DoesAttendTestTypeAsync(TestTypeID).GetAwaiter().GetResult();
        }

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return TotalTrialsPerTestAsync(TestTypeID).GetAwaiter().GetResult();
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return IsThereAnActiveScheduledTestAsync(LocalDrivingLicenseApplicationID, TestTypeID).GetAwaiter().GetResult();
        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return GetLastTestPerTestTypeAsync(TestTypeID).GetAwaiter().GetResult();
        }

        public byte GetPassedTestCount()
        {
            return GetPassedTestCountAsync().GetAwaiter().GetResult();
        }

        public bool PassedAllTests()
        {
            return PassedAllTestsAsync().GetAwaiter().GetResult();
        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            return IssueLicenseForTheFirstTimeAsync(Notes, CreatedByUserID).GetAwaiter().GetResult();
        }

        public bool IsLicenseIssued()
        {
            return IsLicenseIssuedAsync().GetAwaiter().GetResult();
        }

        public int GetActiveLicenseID()
        {
            return GetActiveLicenseIDAsync().GetAwaiter().GetResult();
        }

        // Instance version of IsThereAnActiveScheduledTest for backward compatibility
        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }

        // Static version of DoesPassTestType for backward compatibility
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestTypeAsync(LocalDrivingLicenseApplicationID, (int)TestTypeID).GetAwaiter().GetResult();
        }
    }
}
