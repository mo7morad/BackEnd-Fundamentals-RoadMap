using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }
        public clsPerson PersonInfo;
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string Username, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        /// <summary>
        /// Converts the current user to a UserDTO.
        /// </summary>
        private UserDTO ToDTO()
        {
            return new UserDTO(UserID, PersonID, UserName, Password, IsActive);
        }

        /// <summary>
        /// Creates a clsUser from a UserDTO.
        /// </summary>
        private static clsUser FromDTO(UserDTO dto)
        {
            if (dto == null) return null;
            return new clsUser(dto.UserID, dto.PersonID, dto.UserName, dto.Password, dto.IsActive);
        }

        #region Async Methods

        private async Task<bool> _AddNewUserAsync()
        {
            var dto = ToDTO();
            this.UserID = await clsUserData.AddNewUserAsync(dto);
            return (this.UserID != -1);
        }

        private async Task<bool> _UpdateUserAsync()
        {
            return await clsUserData.UpdateUserAsync(ToDTO());
        }

        /// <summary>
        /// Finds a user by UserID asynchronously.
        /// </summary>
        public static async Task<clsUser> FindByUserIDAsync(int UserID)
        {
            UserDTO dto = await clsUserData.GetUserInfoByUserIDAsync(UserID);
            return FromDTO(dto);
        }

        /// <summary>
        /// Finds a user by PersonID asynchronously.
        /// </summary>
        public static async Task<clsUser> FindByPersonIDAsync(int PersonID)
        {
            UserDTO dto = await clsUserData.GetUserInfoByPersonIDAsync(PersonID);
            return FromDTO(dto);
        }

        /// <summary>
        /// Finds a user by username and password asynchronously.
        /// </summary>
        public static async Task<clsUser> FindByUsernameAndPasswordAsync(string UserName, string Password)
        {
            UserDTO dto = await clsUserData.GetUserInfoByUsernameAndPasswordAsync(UserName, Password);
            return FromDTO(dto);
        }

        /// <summary>
        /// Saves the user asynchronously (Add or Update).
        /// </summary>
        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewUserAsync())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateUserAsync();
            }
            return false;
        }

        /// <summary>
        /// Gets all users asynchronously.
        /// </summary>
        public static async Task<DataTable> GetAllUsersAsync()
        {
            return await clsUserData.GetAllUsersAsync();
        }

        /// <summary>
        /// Deletes a user asynchronously.
        /// </summary>
        public static async Task<bool> DeleteUserAsync(int UserID)
        {
            return await clsUserData.DeleteUserAsync(UserID);
        }

        /// <summary>
        /// Checks if a user exists by UserID asynchronously.
        /// </summary>
        public static async Task<bool> IsUserExistAsync(int UserID)
        {
            return await clsUserData.IsUserExistAsync(UserID);
        }

        /// <summary>
        /// Checks if a user exists by username asynchronously.
        /// </summary>
        public static async Task<bool> IsUserExistAsync(string UserName)
        {
            return await clsUserData.IsUserExistByUsernameAsync(UserName);
        }

        /// <summary>
        /// Checks if a user exists for a PersonID asynchronously.
        /// </summary>
        public static async Task<bool> IsUserExistForPersonIDAsync(int PersonID)
        {
            return await clsUserData.IsUserExistForPersonIDAsync(PersonID);
        }

        /// <summary>
        /// Changes the password asynchronously.
        /// </summary>
        public static async Task<bool> ChangePasswordAsync(int UserID, string NewPassword)
        {
            return await clsUserData.ChangePasswordAsync(UserID, NewPassword);
        }

        #endregion

        #region Synchronous Methods (for backward compatibility)

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName,
                this.Password, this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName,
                this.Password, this.IsActive);
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID
                                (UserID, ref PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByPersonID
                                (PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool isUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }

        #endregion
    }
}
