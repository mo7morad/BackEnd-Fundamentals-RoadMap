using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public enMode Mode = enMode.AddNew;

        public int ApplicationID { set; get; }
        public int ApplicantPersonID { set; get; }
        public clsPerson PersonInfo { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public clsApplicationType ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { set; get; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New: return "New";
                    case enApplicationStatus.Cancelled: return "Cancelled";
                    case enApplicationStatus.Completed: return "Completed";
                    default: return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUser CreatedByUserInfo;

        // Add ApplicantFullName property for backward compatibility
        public string ApplicantFullName
        {
            get
            {
                return PersonInfo?.FullName ?? "";
            }
        }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        protected clsApplication(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }

        private ApplicationDTO ToDTO()
        {
            return new ApplicationDTO(ApplicationID, ApplicantPersonID, ApplicationDate,
                ApplicationTypeID, (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }

        private static clsApplication FromDTO(ApplicationDTO dto)
        {
            if (dto == null) return null;
            return new clsApplication(dto.ApplicationID, dto.ApplicantPersonID, dto.ApplicationDate,
                dto.ApplicationTypeID, (enApplicationStatus)dto.ApplicationStatus, dto.LastStatusDate,
                dto.PaidFees, dto.CreatedByUserID);
        }

        private async Task<bool> _AddNewApplicationAsync()
        {
            this.ApplicationID = await clsApplicationData.AddNewApplicationAsync(ToDTO()).ConfigureAwait(false);
            return (this.ApplicationID != -1);
        }

        private async Task<bool> _UpdateApplicationAsync()
        {
            return await clsApplicationData.UpdateApplicationAsync(ToDTO()).ConfigureAwait(false);
        }

        public static async Task<clsApplication> FindBaseApplicationAsync(int ApplicationID)
        {
            ApplicationDTO dto = await clsApplicationData.GetApplicationInfoByIDAsync(ApplicationID).ConfigureAwait(false);
            if (dto == null) return null;
            var app = FromDTO(dto);
            app.ApplicationTypeInfo = await clsApplicationType.FindAsync(dto.ApplicationTypeID).ConfigureAwait(false);
            app.CreatedByUserInfo = await clsUser.FindByUserIDAsync(dto.CreatedByUserID).ConfigureAwait(false);
            app.PersonInfo = await clsPerson.FindAsync(dto.ApplicantPersonID).ConfigureAwait(false);
            return app;
        }

        public async Task<bool> CancelAsync()
        {
            return await clsApplicationData.UpdateStatusAsync(ApplicationID, 2).ConfigureAwait(false);
        }

        public async Task<bool> SetCompleteAsync()
        {
            return await clsApplicationData.UpdateStatusAsync(ApplicationID, 3).ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewApplicationAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateApplicationAsync().ConfigureAwait(false);
            }
            return false;
        }

        public async Task<bool> DeleteAsync()
        {
            return await clsApplicationData.DeleteApplicationAsync(this.ApplicationID).ConfigureAwait(false);
        }

        public static async Task<bool> IsApplicationExistAsync(int ApplicationID)
        {
            return await clsApplicationData.IsApplicationExistAsync(ApplicationID).ConfigureAwait(false);
        }

        public static async Task<bool> DoesPersonHaveActiveApplicationAsync(int PersonID, int ApplicationTypeID)
        {
            return await clsApplicationData.DoesPersonHaveActiveApplicationAsync(PersonID, ApplicationTypeID).ConfigureAwait(false);
        }

        public static async Task<int> GetActiveApplicationIDAsync(int PersonID, enApplicationType ApplicationTypeID)
        {
            return await clsApplicationData.GetActiveApplicationIDAsync(PersonID, (int)ApplicationTypeID).ConfigureAwait(false);
        }

        public static async Task<int> GetActiveApplicationIDForLicenseClassAsync(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return await clsApplicationData.GetActiveApplicationIDForLicenseClassAsync(PersonID, (int)ApplicationTypeID, LicenseClassID).ConfigureAwait(false);
        }

        // Sync wrappers for backward compatibility
        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            return FindBaseApplicationAsync(ApplicationID).GetAwaiter().GetResult();
        }

        public bool Cancel()
        {
            return CancelAsync().GetAwaiter().GetResult();
        }

        public bool SetComplete()
        {
            return SetCompleteAsync().GetAwaiter().GetResult();
        }

        public bool Save()
        {
            return SaveAsync().GetAwaiter().GetResult();
        }

        public bool Delete()
        {
            return DeleteAsync().GetAwaiter().GetResult();
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return IsApplicationExistAsync(ApplicationID).GetAwaiter().GetResult();
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplicationAsync(PersonID, ApplicationTypeID).GetAwaiter().GetResult();
        }

        public static int GetActiveApplicationID(int PersonID, enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationIDAsync(PersonID, ApplicationTypeID).GetAwaiter().GetResult();
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return GetActiveApplicationIDForLicenseClassAsync(PersonID, ApplicationTypeID, LicenseClassID).GetAwaiter().GetResult();
        }
    }
}
