using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { set; get; }
        public clsTestType.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestAppInfo { set; get; }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            Mode = enMode.AddNew;
        }

        public clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID,
           int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,
           int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            Mode = enMode.Update;
        }

        private async Task<bool> _AddNewTestAppointmentAsync()
        {
            this.TestAppointmentID = await clsTestAppointmentData.AddNewTestAppointmentAsync(
                (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.RetakeTestApplicationID).ConfigureAwait(false);
            return (this.TestAppointmentID != -1);
        }

        private async Task<bool> _UpdateTestAppointmentAsync()
        {
            return await clsTestAppointmentData.UpdateTestAppointmentAsync(
                this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID).ConfigureAwait(false);
        }

        public static async Task<clsTestAppointment> FindAsync(int TestAppointmentID)
        {
            TestAppointmentDTO dto = await clsTestAppointmentData.GetTestAppointmentInfoByIDAsync(TestAppointmentID).ConfigureAwait(false);
            if (dto == null) return null;
            var appt = new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)dto.TestTypeID,
                dto.LocalDrivingLicenseApplicationID, dto.AppointmentDate, dto.PaidFees,
                dto.CreatedByUserID, dto.IsLocked, dto.RetakeTestApplicationID);
            if (dto.RetakeTestApplicationID != -1)
                appt.RetakeTestAppInfo = await clsApplication.FindBaseApplicationAsync(dto.RetakeTestApplicationID).ConfigureAwait(false);
            return appt;
        }

        public static async Task<clsTestAppointment> GetLastTestAppointmentAsync(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            TestAppointmentDTO dto = await clsTestAppointmentData.GetLastTestAppointmentAsync(LocalDrivingLicenseApplicationID, (int)TestTypeID).ConfigureAwait(false);
            if (dto == null) return null;
            var appt = new clsTestAppointment(dto.TestAppointmentID, TestTypeID,
                LocalDrivingLicenseApplicationID, dto.AppointmentDate, dto.PaidFees,
                dto.CreatedByUserID, dto.IsLocked, dto.RetakeTestApplicationID);
            if (dto.RetakeTestApplicationID != -1)
                appt.RetakeTestAppInfo = await clsApplication.FindBaseApplicationAsync(dto.RetakeTestApplicationID).ConfigureAwait(false);
            return appt;
        }

        public static async Task<DataTable> GetAllTestAppointmentsAsync()
        {
            return await clsTestAppointmentData.GetAllTestAppointmentsAsync().ConfigureAwait(false);
        }

        public async Task<DataTable> GetApplicationTestAppointmentsPerTestTypeAsync(clsTestType.enTestType TestTypeID)
        {
            return await clsTestAppointmentData.GetApplicationTestAppointmentsPerTestTypeAsync(this.LocalDrivingLicenseApplicationID, (int)TestTypeID).ConfigureAwait(false);
        }

        public static async Task<DataTable> GetApplicationTestAppointmentsPerTestTypeAsync(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return await clsTestAppointmentData.GetApplicationTestAppointmentsPerTestTypeAsync(LocalDrivingLicenseApplicationID, (int)TestTypeID).ConfigureAwait(false);
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewTestAppointmentAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateTestAppointmentAsync().ConfigureAwait(false);
            }
            return false;
        }

        public async Task<int> GetTestIDAsync()
        {
            return await clsTestAppointmentData.GetTestIDAsync(TestAppointmentID).ConfigureAwait(false);
        }

        // Sync wrappers for backward compatibility
        public static clsTestAppointment Find(int TestAppointmentID) => FindAsync(TestAppointmentID).GetAwaiter().GetResult();
        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID) => GetLastTestAppointmentAsync(LocalDrivingLicenseApplicationID, TestTypeID).GetAwaiter().GetResult();
        public static DataTable GetAllTestAppointments() => GetAllTestAppointmentsAsync().GetAwaiter().GetResult();
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID) => GetApplicationTestAppointmentsPerTestTypeAsync(LocalDrivingLicenseApplicationID, TestTypeID).GetAwaiter().GetResult();
        public bool Save() => SaveAsync().GetAwaiter().GetResult();
        public int TestID => GetTestIDAsync().GetAwaiter().GetResult();
    }
}
