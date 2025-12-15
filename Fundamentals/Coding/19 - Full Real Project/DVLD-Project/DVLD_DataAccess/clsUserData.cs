using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public UserDTO(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }
    }

    public class clsUserData
    {
        public static async Task<UserDTO> GetUserInfoByUserIDAsync(int userId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new UserDTO(
                                    userId,
                                    (int)reader["PersonID"],
                                    (string)reader["UserName"],
                                    (string)reader["Password"],
                                    (bool)reader["IsActive"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<UserDTO> GetUserInfoByPersonIDAsync(int personId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personId);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new UserDTO(
                                    (int)reader["UserID"],
                                    personId,
                                    (string)reader["UserName"],
                                    (string)reader["Password"],
                                    (bool)reader["IsActive"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<UserDTO> GetUserInfoByUsernameAndPasswordAsync(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", userName);
                    command.Parameters.AddWithValue("@Password", password);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new UserDTO(
                                    (int)reader["UserID"],
                                    (int)reader["PersonID"],
                                    (string)reader["UserName"],
                                    (string)reader["Password"],
                                    (bool)reader["IsActive"]
                                );
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<int> AddNewUserAsync(UserDTO userDTO)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                                 VALUES (@PersonID, @UserName, @Password, @IsActive);
                                 SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", userDTO.PersonID);
                    command.Parameters.AddWithValue("@UserName", userDTO.UserName);
                    command.Parameters.AddWithValue("@Password", userDTO.Password);
                    command.Parameters.AddWithValue("@IsActive", userDTO.IsActive);
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

        public static async Task<bool> UpdateUserAsync(UserDTO userDTO)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users SET PersonID = @PersonID, UserName = @UserName,
                                Password = @Password, IsActive = @IsActive WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userDTO.UserID);
                    command.Parameters.AddWithValue("@PersonID", userDTO.PersonID);
                    command.Parameters.AddWithValue("@UserName", userDTO.UserName);
                    command.Parameters.AddWithValue("@Password", userDTO.Password);
                    command.Parameters.AddWithValue("@IsActive", userDTO.IsActive);
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

        public static async Task<DataTable> GetAllUsersAsync()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT Users.UserID, Users.PersonID,
                                FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName,
                                Users.UserName, Users.IsActive
                                FROM Users INNER JOIN People ON Users.PersonID = People.PersonID";
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

        public static async Task<bool> DeleteUserAsync(int userId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
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

        public static async Task<bool> IsUserExistAsync(int userId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
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

        public static async Task<bool> IsUserExistByUsernameAsync(string userName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
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

        public static async Task<bool> IsUserExistForPersonIDAsync(int personId)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM Users WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personId);
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

        public static async Task<bool> ChangePasswordAsync(int userId, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users SET Password = @Password WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Password", newPassword);
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
