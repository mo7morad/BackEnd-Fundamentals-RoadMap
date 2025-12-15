using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class PersonDTO
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public PersonDTO(int personID, string firstName, string secondName, string thirdName, string lastName, string nationalNo, DateTime dateOfBirth, short gender, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID; FirstName = firstName; SecondName = secondName; ThirdName = thirdName; LastName = lastName; NationalNo = nationalNo; DateOfBirth = dateOfBirth; Gender = gender; Address = address; Phone = phone; Email = email; NationalityCountryID = nationalityCountryID; ImagePath = imagePath;
        }
    }

    public class clsPersonData
    {
        public static async Task<PersonDTO> GetPersonInfoByIDAsync(int personID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM People WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new PersonDTO(personID, (string)reader["FirstName"], (string)reader["SecondName"], reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "", (string)reader["LastName"], (string)reader["NationalNo"], (DateTime)reader["DateOfBirth"], (byte)reader["gender"], (string)reader["Address"], (string)reader["Phone"], reader["Email"] != DBNull.Value ? (string)reader["Email"] : "", (int)reader["NationalityCountryID"], reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "");
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<PersonDTO> GetPersonInfoByNationalNoAsync(string nationalNo)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", nationalNo);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (await reader.ReadAsync().ConfigureAwait(false))
                            {
                                return new PersonDTO((int)reader["PersonID"], (string)reader["FirstName"], (string)reader["SecondName"], reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "", (string)reader["LastName"], nationalNo, (DateTime)reader["DateOfBirth"], (byte)reader["gender"], (string)reader["Address"], (string)reader["Phone"], reader["Email"] != DBNull.Value ? (string)reader["Email"] : "", (int)reader["NationalityCountryID"], reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "");
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            return null;
        }

        public static async Task<int> AddNewPersonAsync(PersonDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO People (FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, gender, Address, Phone, Email, NationalityCountryID, ImagePath) VALUES (@FirstName, @SecondName, @ThirdName, @LastName, @NationalNo, @DateOfBirth, @gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    command.Parameters.AddWithValue("@SecondName", dto.SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(dto.ThirdName) ? (object)DBNull.Value : dto.ThirdName);
                    command.Parameters.AddWithValue("@LastName", dto.LastName);
                    command.Parameters.AddWithValue("@NationalNo", dto.NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
                    command.Parameters.AddWithValue("@gender", dto.Gender);
                    command.Parameters.AddWithValue("@Address", dto.Address);
                    command.Parameters.AddWithValue("@Phone", dto.Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(dto.Email) ? (object)DBNull.Value : dto.Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", dto.NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(dto.ImagePath) ? (object)DBNull.Value : dto.ImagePath);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        object result = await command.ExecuteScalarAsync().ConfigureAwait(false);
                        if (result != null && int.TryParse(result.ToString(), out int insertedID)) return insertedID;
                    }
                    catch (Exception) { }
                }
            }
            return -1;
        }

        public static async Task<bool> UpdatePersonAsync(PersonDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Update People set FirstName=@FirstName, SecondName=@SecondName, ThirdName=@ThirdName, LastName=@LastName, NationalNo=@NationalNo, DateOfBirth=@DateOfBirth, gender=@gender, Address=@Address, Phone=@Phone, Email=@Email, NationalityCountryID=@NationalityCountryID, ImagePath=@ImagePath where PersonID=@PersonID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", dto.PersonID);
                    command.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    command.Parameters.AddWithValue("@SecondName", dto.SecondName);
                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(dto.ThirdName) ? (object)DBNull.Value : dto.ThirdName);
                    command.Parameters.AddWithValue("@LastName", dto.LastName);
                    command.Parameters.AddWithValue("@NationalNo", dto.NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
                    command.Parameters.AddWithValue("@gender", dto.Gender);
                    command.Parameters.AddWithValue("@Address", dto.Address);
                    command.Parameters.AddWithValue("@Phone", dto.Phone);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(dto.Email) ? (object)DBNull.Value : dto.Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", dto.NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(dto.ImagePath) ? (object)DBNull.Value : dto.ImagePath);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        return await command.ExecuteNonQueryAsync().ConfigureAwait(false) > 0;
                    }
                    catch (Exception) { return false; }
                }
            }
        }

        public static async Task<DataTable> GetAllPeopleAsync()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, People.gender, CASE WHEN People.gender = 0 THEN 'Male' ELSE 'Female' END as genderCaption, People.Address, People.Phone, People.Email, People.NationalityCountryID, Countries.CountryName, People.ImagePath FROM People INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID ORDER BY People.FirstName";
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

        public static async Task<bool> DeletePersonAsync(int personID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"Delete People where PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        return await command.ExecuteNonQueryAsync().ConfigureAwait(false) > 0;
                    }
                    catch (Exception) { return false; }
                }
            }
        }

        public static async Task<bool> IsPersonExistAsync(int personID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM People WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        return await command.ExecuteScalarAsync().ConfigureAwait(false) != null;
                    }
                    catch (Exception) { return false; }
                }
            }
        }

        public static async Task<bool> IsPersonExistByNationalNoAsync(string nationalNo)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM People WHERE NationalNo = @NationalNo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", nationalNo);
                    try
                    {
                        await connection.OpenAsync().ConfigureAwait(false);
                        return await command.ExecuteScalarAsync().ConfigureAwait(false) != null;
                    }
                    catch (Exception) { return false; }
                }
            }
        }
    }
}
