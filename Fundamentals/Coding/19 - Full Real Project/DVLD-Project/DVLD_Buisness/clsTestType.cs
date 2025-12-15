using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public enTestType ID { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public float Fees { set; get; }

        public clsTestType()
        {
            this.ID = enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            Mode = enMode.AddNew;
        }

        public clsTestType(enTestType ID, string TestTypeTitle, string Description, float TestTypeFees)
        {
            this.ID = ID;
            this.Title = TestTypeTitle;
            this.Description = Description;
            this.Fees = TestTypeFees;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewTestTypeAsync()
        {
            int id = await clsTestTypeData.AddNewTestTypeAsync(this.Title, this.Description, this.Fees).ConfigureAwait(false);
            this.ID = (enTestType)id;
            return (this.Title != "");
        }

        private async Task<bool> _UpdateTestTypeAsync()
        {
            return await clsTestTypeData.UpdateTestTypeAsync((int)this.ID, this.Title, this.Description, this.Fees).ConfigureAwait(false);
        }

        public static async Task<clsTestType> FindAsync(enTestType TestTypeID)
        {
            TestTypeDTO dto = await clsTestTypeData.GetTestTypeInfoByIDAsync((int)TestTypeID).ConfigureAwait(false);
            if (dto == null) return null;
            return new clsTestType(TestTypeID, dto.TestTypeTitle, dto.TestTypeDescription, dto.TestTypeFees);
        }

        public static async Task<DataTable> GetAllTestTypesAsync()
        {
            return await clsTestTypeData.GetAllTestTypesAsync().ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewTestTypeAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateTestTypeAsync().ConfigureAwait(false);
            }
            return false;
        }

        // Sync wrappers for backward compatibility
        public static clsTestType Find(enTestType TestTypeID) => FindAsync(TestTypeID).GetAwaiter().GetResult();
        public static DataTable GetAllTestTypes() => GetAllTestTypesAsync().GetAwaiter().GetResult();
        public bool Save() => SaveAsync().GetAwaiter().GetResult();
    }
}
