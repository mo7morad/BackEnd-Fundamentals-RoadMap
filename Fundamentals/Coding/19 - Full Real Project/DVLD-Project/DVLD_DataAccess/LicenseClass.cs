using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class LicenseClassDTO
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public LicenseClassDTO(int licenseClassID, string className, string classDescription,
            byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }
    }

    public class clsLicenseClassData
    {
        public static async Task<LicenseClassDTO> GetLicenseClassInfoByIDAsync(int licenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new LicenseClassDTO(
                                    licenseClassID,
                                    (string)reader["ClassName"],
                                    (string)reader["ClassDescription"],
                                    (byte)reader["MinimumAllowedAge"],
                                    (byte)reader["DefaultValidityLength"],
                                    Convert.ToSingle(reader["ClassFees"])
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<LicenseClassDTO> GetLicenseClassInfoByClassNameAsync(string className)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassName", className);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new LicenseClassDTO(
                                    (int)reader["LicenseClassID"],
                                    className,
                                    (string)reader["ClassDescription"],
                                    (byte)reader["MinimumAllowedAge"],
                                    (byte)reader["DefaultValidityLength"],
                                    Convert.ToSingle(reader["ClassFees"])
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<DataTable> GetAllLicenseClassesAsync()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM LicenseClasses order by ClassName";
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

        public static async Task<int> AddNewLicenseClassAsync(string className, string classDescription,
            byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Insert Into LicenseClasses 
           (ClassName,ClassDescription,MinimumAllowedAge, DefaultValidityLength,ClassFees)
                            Values (@ClassName,@ClassDescription,@MinimumAllowedAge, @DefaultValidityLength,@ClassFees);
                            SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassName", className);
                    command.Parameters.AddWithValue("@ClassDescription", classDescription);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", minimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", defaultValidityLength);
                    command.Parameters.AddWithValue("@ClassFees", classFees);
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

        public static async Task<bool> UpdateLicenseClassAsync(int licenseClassID, string className,
            string classDescription, byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update LicenseClasses  
                            set ClassName = @ClassName,
                                ClassDescription = @ClassDescription,
                                MinimumAllowedAge = @MinimumAllowedAge,
                                DefaultValidityLength = @DefaultValidityLength,
                                ClassFees = @ClassFees
                                where LicenseClassID = @LicenseClassID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    command.Parameters.AddWithValue("@ClassName", className);
                    command.Parameters.AddWithValue("@ClassDescription", classDescription);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", minimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", defaultValidityLength);
                    command.Parameters.AddWithValue("@ClassFees", classFees);
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
    }
}
