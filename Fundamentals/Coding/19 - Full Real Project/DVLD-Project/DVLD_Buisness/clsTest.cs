using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public clsTestAppointment TestAppointmentInfo { set; get; }
        public bool TestResult { set; get; }
        public string Notes { set; get; }
        public int CreatedByUserID { set; get; }

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        public clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewTestAsync()
        {
            this.TestID = await clsTestData.AddNewTestAsync(this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID).ConfigureAwait(false);
            return (this.TestID != -1);
        }

        private async Task<bool> _UpdateTestAsync()
        {
            return await clsTestData.UpdateTestAsync(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID).ConfigureAwait(false);
        }

        public static async Task<clsTest> FindAsync(int TestID)
        {
            TestDTO dto = await clsTestData.GetTestInfoByIDAsync(TestID).ConfigureAwait(false);
            if (dto == null) return null;
            var test = new clsTest(dto.TestID, dto.TestAppointmentID, dto.TestResult, dto.Notes, dto.CreatedByUserID);
            test.TestAppointmentInfo = await clsTestAppointment.FindAsync(dto.TestAppointmentID).ConfigureAwait(false);
            return test;
        }

        public static async Task<clsTest> FindLastTestPerPersonAndLicenseClassAsync(int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            TestDTO dto = await clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClassAsync(PersonID, LicenseClassID, (int)TestTypeID).ConfigureAwait(false);
            if (dto == null) return null;
            var test = new clsTest(dto.TestID, dto.TestAppointmentID, dto.TestResult, dto.Notes, dto.CreatedByUserID);
            test.TestAppointmentInfo = await clsTestAppointment.FindAsync(dto.TestAppointmentID).ConfigureAwait(false);
            return test;
        }

        public static async Task<DataTable> GetAllTestsAsync()
        {
            return await clsTestData.GetAllTestsAsync().ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewTestAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateTestAsync().ConfigureAwait(false);
            }
            return false;
        }

        public static async Task<byte> GetPassedTestCountAsync(int LocalDrivingLicenseApplicationID)
        {
            return await clsTestData.GetPassedTestCountAsync(LocalDrivingLicenseApplicationID).ConfigureAwait(false);
        }

        public static async Task<bool> PassedAllTestsAsync(int LocalDrivingLicenseApplicationID)
        {
            return await GetPassedTestCountAsync(LocalDrivingLicenseApplicationID).ConfigureAwait(false) == 3;
        }

        // Sync wrappers for backward compatibility
        public static clsTest Find(int TestID) => FindAsync(TestID).GetAwaiter().GetResult();
        public static clsTest FindLastTestPerPersonAndLicenseClass(int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID) => FindLastTestPerPersonAndLicenseClassAsync(PersonID, LicenseClassID, TestTypeID).GetAwaiter().GetResult();
        public static DataTable GetAllTests() => GetAllTestsAsync().GetAwaiter().GetResult();
        public bool Save() => SaveAsync().GetAwaiter().GetResult();
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID) => GetPassedTestCountAsync(LocalDrivingLicenseApplicationID).GetAwaiter().GetResult();
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID) => PassedAllTestsAsync(LocalDrivingLicenseApplicationID).GetAwaiter().GetResult();
    }
}
