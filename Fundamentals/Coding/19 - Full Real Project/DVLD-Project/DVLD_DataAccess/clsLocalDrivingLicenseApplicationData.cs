using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DVLD_DataAccess
{
    public class LocalDrivingLicenseApplicationDTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public LocalDrivingLicenseApplicationDTO(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }
    }

    public class clsLocalDrivingLicenseApplicationData
    {
        public static async Task<LocalDrivingLicenseApplicationDTO> GetLocalDrivingLicenseApplicationInfoByIDAsync(int localDrivingLicenseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new LocalDrivingLicenseApplicationDTO(
                                    localDrivingLicenseApplicationID,
                                    (int)reader["ApplicationID"],
                                    (int)reader["LicenseClassID"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<LocalDrivingLicenseApplicationDTO> GetLocalDrivingLicenseApplicationInfoByApplicationIDAsync(int applicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new LocalDrivingLicenseApplicationDTO(
                                    (int)reader["LocalDrivingLicenseApplicationID"],
                                    applicationID,
                                    (int)reader["LicenseClassID"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<DataTable> GetAllLocalDrivingLicenseApplicationsAsync()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM LocalDrivingLicenseApplications_View order by ApplicationDate Desc";
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

        public static async Task<int> AddNewLocalDrivingLicenseApplicationAsync(int applicationID, int licenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                             VALUES (@ApplicationID,@LicenseClassID);
                             SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
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

        public static async Task<bool> UpdateLocalDrivingLicenseApplicationAsync(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update LocalDrivingLicenseApplications  
                            set ApplicationID = @ApplicationID,
                                LicenseClassID = @LicenseClassID
                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
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

        public static async Task<bool> DeleteLocalDrivingLicenseApplicationAsync(int localDrivingLicenseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Delete LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
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

        public static async Task<bool> DoesPassTestTypeAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        object result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                        if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                        {
                            return returnedResult;
                        }
                    }
                    catch (Exception) { }
                }
            }
            return false;
        }

        public static async Task<bool> DoesAttendTestTypeAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT top 1 1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        object result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                        return result != null;
                    }
                    catch (Exception) { return false; }
                }
            }
        }

        public static async Task<byte> TotalTrialsPerTestAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        object result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                        if (result != null && byte.TryParse(result.ToString(), out byte trials))
                        {
                            return trials;
                        }
                    }
                    catch (Exception) { }
                }
            }
            return 0;
        }

        public static async Task<bool> IsThereAnActiveScheduledTestAsync(int localDrivingLicenseApplicationID, int testTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT top 1 1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        object result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                        return result != null;
                    }
                    catch (Exception) { return false; }
                }
            }
        }
    }
}
