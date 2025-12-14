namespace DVLD_DataAccess
{
    /// <summary>
    /// Data Transfer Object for User data.
    /// </summary>
    public class UserDTO
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public UserDTO()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
        }

        public UserDTO(int userId, int personId, string userName, string password, bool isActive)
        {
            UserID = userId;
            PersonID = personId;
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }
    }
}
