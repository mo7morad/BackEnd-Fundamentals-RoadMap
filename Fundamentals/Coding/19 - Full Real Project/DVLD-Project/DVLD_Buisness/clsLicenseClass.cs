using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public byte MinimumAllowedAge { set; get; }
        public byte DefaultValidityLength { set; get; }
        public float ClassFees { set; get; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;
            Mode = enMode.AddNew;
        }

        public clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewLicenseClassAsync()
        {
            this.LicenseClassID = await clsLicenseClassData.AddNewLicenseClassAsync(
                this.ClassName, this.ClassDescription, this.MinimumAllowedAge,
                this.DefaultValidityLength, this.ClassFees).ConfigureAwait(false);
            return (this.LicenseClassID != -1);
        }

        private async Task<bool> _UpdateLicenseClassAsync()
        {
            return await clsLicenseClassData.UpdateLicenseClassAsync(
                this.LicenseClassID, this.ClassName, this.ClassDescription,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees).ConfigureAwait(false);
        }

        public static async Task<clsLicenseClass> FindAsync(int LicenseClassID)
        {
            LicenseClassDTO dto = await clsLicenseClassData.GetLicenseClassInfoByIDAsync(LicenseClassID).ConfigureAwait(false);
            if (dto == null) return null;
            return new clsLicenseClass(dto.LicenseClassID, dto.ClassName, dto.ClassDescription,
                dto.MinimumAllowedAge, dto.DefaultValidityLength, dto.ClassFees);
        }

        public static async Task<clsLicenseClass> FindByNameAsync(string ClassName)
        {
            LicenseClassDTO dto = await clsLicenseClassData.GetLicenseClassInfoByClassNameAsync(ClassName).ConfigureAwait(false);
            if (dto == null) return null;
            return new clsLicenseClass(dto.LicenseClassID, dto.ClassName, dto.ClassDescription,
                dto.MinimumAllowedAge, dto.DefaultValidityLength, dto.ClassFees);
        }

        public static async Task<DataTable> GetAllLicenseClassesAsync()
        {
            return await clsLicenseClassData.GetAllLicenseClassesAsync().ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewLicenseClassAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateLicenseClassAsync().ConfigureAwait(false);
            }
            return false;
        }

        // Sync wrappers for backward compatibility
        public static clsLicenseClass Find(int LicenseClassID)
        {
            return FindAsync(LicenseClassID).GetAwaiter().GetResult();
        }

        public static clsLicenseClass Find(string ClassName)
        {
            return FindByNameAsync(ClassName).GetAwaiter().GetResult();
        }

        public static DataTable GetAllLicenseClasses()
        {
            return GetAllLicenseClassesAsync().GetAwaiter().GetResult();
        }

        public bool Save()
        {
            return SaveAsync().GetAwaiter().GetResult();
        }
    }
}
