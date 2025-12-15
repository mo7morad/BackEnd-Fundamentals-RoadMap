using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class TestAppointmentDTO
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public TestAppointmentDTO(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
        }
    }

    public class clsTestAppointmentData
    {
        public static async Task<TestAppointmentDTO> GetTestAppointmentInfoByIDAsync(int testAppointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new TestAppointmentDTO(
                                    testAppointmentID,
                                    (int)reader["TestTypeID"],
                                    (int)reader["LocalDrivingLicenseApplicationID"],
                                    (DateTime)reader["AppointmentDate"],
                                    Convert.ToSingle(reader["PaidFees"]),
                                    (int)reader["CreatedByUserID"],
                                    (bool)reader["IsLocked"],
                                    reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : (int)reader["RetakeTestApplicationID"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<TestAppointmentDTO> GetLastTestAppointmentAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT top 1 * FROM TestAppointments
                WHERE (TestTypeID = @TestTypeID) AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                order by TestAppointmentID Desc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new TestAppointmentDTO(
                                    (int)reader["TestAppointmentID"],
                                    testTypeID,
                                    localDrivingLicenseApplicationID,
                                    (DateTime)reader["AppointmentDate"],
                                    Convert.ToSingle(reader["PaidFees"]),
                                    (int)reader["CreatedByUserID"],
                                    (bool)reader["IsLocked"],
                                    reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : (int)reader["RetakeTestApplicationID"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<DataTable> GetAllTestAppointmentsAsync()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select * from TestAppointments_View order by AppointmentDate Desc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                    catch (Exception) { }
                }
            }
            return dt;
        }

        public static async Task<DataTable> GetApplicationTestAppointmentsPerTestTypeAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                        FROM TestAppointments
                        WHERE (TestTypeID = @TestTypeID) AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                        order by TestAppointmentID desc;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (reader.HasRows) dt.Load(reader);
                        }
                    }
                    catch (Exception) { }
                }
            }
            return dt;
        }

        public static async Task<int> AddNewTestAppointmentAsync(int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, int retakeTestApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Insert Into TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
                            Values (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,0,@RetakeTestApplicationID);
                            SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", paidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", retakeTestApplicationID == -1 ? (object)DBNull.Value : retakeTestApplicationID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        object result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            return insertedID;
                        }
                    }
                    catch (Exception) { }
                }
            }
            return -1;
        }

        public static async Task<bool> UpdateTestAppointmentAsync(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update TestAppointments  
                            set TestTypeID = @TestTypeID,
                                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                AppointmentDate = @AppointmentDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID = @CreatedByUserID,
                                IsLocked=@IsLocked,
                                RetakeTestApplicationID=@RetakeTestApplicationID
                                where TestAppointmentID = @TestAppointmentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", paidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                    command.Parameters.AddWithValue("@IsLocked", isLocked);
                    command.Parameters.AddWithValue("@RetakeTestApplicationID", retakeTestApplicationID == -1 ? (object)DBNull.Value : retakeTestApplicationID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        int rowsAffected = await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                        return rowsAffected > 0;
                    }
                    catch (Exception) { return false; }
                }
            }
        }

        public static async Task<int> GetTestIDAsync(int testAppointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        object result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                        if (result != null && int.TryParse(result.ToString(), out int testID))
                        {
                            return testID;
                        }
                    }
                    catch (Exception) { }
                }
            }
            return -1;
        }
    }
}
