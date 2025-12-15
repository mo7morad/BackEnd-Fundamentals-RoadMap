using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_DataAccess.clsCountryData;
using System.Net;
using System.Security.Policy;

namespace DVLD_DataAccess
{
    public class DetainedLicenseDTO
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        public DetainedLicenseDTO(int detainID, int licenseID, DateTime detainDate, float fineFees,
            int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
        }
    }

    public class clsDetainedLicenseData
    {
        public static async Task<DetainedLicenseDTO> GetDetainedLicenseInfoByIDAsync(int detainID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", detainID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new DetainedLicenseDTO(
                                    detainID,
                                    (int)reader["LicenseID"],
                                    (DateTime)reader["DetainDate"],
                                    Convert.ToSingle(reader["FineFees"]),
                                    (int)reader["CreatedByUserID"],
                                    (bool)reader["IsReleased"],
                                    reader["ReleaseDate"] == DBNull.Value ? DateTime.MaxValue : (DateTime)reader["ReleaseDate"],
                                    reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"],
                                    reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<DetainedLicenseDTO> GetDetainedLicenseInfoByLicenseIDAsync(int licenseID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new DetainedLicenseDTO(
                                    (int)reader["DetainID"],
                                    licenseID,
                                    (DateTime)reader["DetainDate"],
                                    Convert.ToSingle(reader["FineFees"]),
                                    (int)reader["CreatedByUserID"],
                                    (bool)reader["IsReleased"],
                                    reader["ReleaseDate"] == DBNull.Value ? DateTime.MaxValue : (DateTime)reader["ReleaseDate"],
                                    reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"],
                                    reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<DataTable> GetAllDetainedLicensesAsync()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "select * from detainedLicenses_View order by IsReleased ,DetainID;";
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

        public static async Task<int> AddNewDetainedLicenseAsync(int licenseID, DateTime detainDate, float fineFees, int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO dbo.DetainedLicenses
                               (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                            VALUES
                               (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                            SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    command.Parameters.AddWithValue("@DetainDate", detainDate);
                    command.Parameters.AddWithValue("@FineFees", fineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
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

        public static async Task<bool> UpdateDetainedLicenseAsync(int detainID, int licenseID, DateTime detainDate, float fineFees, int createdByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE dbo.DetainedLicenses
                              SET LicenseID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID
                              WHERE DetainID=@DetainID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", detainID);
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    command.Parameters.AddWithValue("@DetainDate", detainDate);
                    command.Parameters.AddWithValue("@FineFees", fineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
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

        public static async Task<bool> ReleaseDetainedLicenseAsync(int detainID, int releasedByUserID, int releaseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleasedByUserID = @ReleasedByUserID,
                              ReleaseApplicationID = @ReleaseApplicationID   
                              WHERE DetainID=@DetainID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", detainID);
                    command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
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

        public static async Task<bool> IsLicenseDetainedAsync(int licenseID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"select 1 from detainedLicenses where LicenseID=@LicenseID and IsReleased=0;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
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
