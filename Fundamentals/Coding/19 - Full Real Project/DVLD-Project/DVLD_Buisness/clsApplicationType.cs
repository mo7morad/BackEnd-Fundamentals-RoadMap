using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Title { set; get; }
        public float Fees { set; get; }

        public clsApplicationType()
        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            Mode = enMode.AddNew;
        }

        public clsApplicationType(int ID, string ApplicationTypeTitle, float ApplicationTypeFees)
        {
            this.ID = ID;
            this.Title = ApplicationTypeTitle;
            this.Fees = ApplicationTypeFees;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewApplicationTypeAsync()
        {
            this.ID = await clsApplicationTypeData.AddNewApplicationTypeAsync(this.Title, this.Fees).ConfigureAwait(false);
            return (this.ID != -1);
        }

        private async Task<bool> _UpdateApplicationTypeAsync()
        {
            return await clsApplicationTypeData.UpdateApplicationTypeAsync(this.ID, this.Title, this.Fees).ConfigureAwait(false);
        }

        public static async Task<clsApplicationType> FindAsync(int ID)
        {
            ApplicationTypeDTO dto = await clsApplicationTypeData.GetApplicationTypeInfoByIDAsync(ID).ConfigureAwait(false);
            if (dto == null) return null;
            return new clsApplicationType(dto.ApplicationTypeID, dto.ApplicationTypeTitle, dto.ApplicationFees);
        }

        public static async Task<DataTable> GetAllApplicationTypesAsync()
        {
            return await clsApplicationTypeData.GetAllApplicationTypesAsync().ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewApplicationTypeAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateApplicationTypeAsync().ConfigureAwait(false);
            }
            return false;
        }

        // Sync wrappers for backward compatibility
        public static clsApplicationType Find(int ID)
        {
            return FindAsync(ID).GetAwaiter().GetResult();
        }

        public static DataTable GetAllApplicationTypes()
        {
            return GetAllApplicationTypesAsync().GetAwaiter().GetResult();
        }

        public bool Save()
        {
            return SaveAsync().GetAwaiter().GetResult();
        }
    }
}
