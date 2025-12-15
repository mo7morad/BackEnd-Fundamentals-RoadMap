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
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }

        private UserDTO ToDTO()
        {
            return new UserDTO(UserID, PersonID, UserName, Password, IsActive);
        }

        private static clsUser FromDTO(UserDTO dto)
        {
            if (dto == null) return null;
            return new clsUser(dto.UserID, dto.PersonID, dto.UserName, dto.Password, dto.IsActive);
        }

        private async Task _LoadPersonInfoAsync()
        {
            this.PersonInfo = await clsPerson.FindAsync(PersonID).ConfigureAwait(false);
        }

        private async Task<bool> _AddNewUserAsync()
        {
            var dto = ToDTO();
            this.UserID = await clsUserData.AddNewUserAsync(dto).ConfigureAwait(false);
            return (this.UserID != -1);
        }

        private async Task<bool> _UpdateUserAsync()
        {
            return await clsUserData.UpdateUserAsync(ToDTO()).ConfigureAwait(false);
        }

        public static async Task<clsUser> FindByUserIDAsync(int UserID)
        {
            UserDTO dto = await clsUserData.GetUserInfoByUserIDAsync(UserID).ConfigureAwait(false);
            if (dto == null) return null;
            var user = FromDTO(dto);
            await user._LoadPersonInfoAsync().ConfigureAwait(false);
            return user;
        }

        public static async Task<clsUser> FindByPersonIDAsync(int PersonID)
        {
            UserDTO dto = await clsUserData.GetUserInfoByPersonIDAsync(PersonID).ConfigureAwait(false);
            if (dto == null) return null;
            var user = FromDTO(dto);
            await user._LoadPersonInfoAsync().ConfigureAwait(false);
            return user;
        }

        public static async Task<clsUser> FindByUsernameAndPasswordAsync(string UserName, string Password)
        {
            UserDTO dto = await clsUserData.GetUserInfoByUsernameAndPasswordAsync(UserName, Password).ConfigureAwait(false);
            if (dto == null) return null;
            var user = FromDTO(dto);
            await user._LoadPersonInfoAsync().ConfigureAwait(false);
            return user;
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (await _AddNewUserAsync().ConfigureAwait(false))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return await _UpdateUserAsync().ConfigureAwait(false);
            }
            return false;
        }

        public static async Task<DataTable> GetAllUsersAsync()
        {
            return await clsUserData.GetAllUsersAsync().ConfigureAwait(false);
        }

        public static async Task<bool> DeleteUserAsync(int UserID)
        {
            return await clsUserData.DeleteUserAsync(UserID).ConfigureAwait(false);
        }

        public static async Task<bool> IsUserExistAsync(int UserID)
        {
            return await clsUserData.IsUserExistAsync(UserID).ConfigureAwait(false);
        }

        public static async Task<bool> IsUserExistAsync(string UserName)
        {
            return await clsUserData.IsUserExistByUsernameAsync(UserName).ConfigureAwait(false);
        }

        public static async Task<bool> IsUserExistForPersonIDAsync(int PersonID)
        {
            return await clsUserData.IsUserExistForPersonIDAsync(PersonID).ConfigureAwait(false);
        }

        public static async Task<bool> ChangePasswordAsync(int UserID, string NewPassword)
        {
            return await clsUserData.ChangePasswordAsync(UserID, NewPassword).ConfigureAwait(false);
        }

        // Sync wrappers for backward compatibility
        public static clsUser FindByUserID(int UserID) => FindByUserIDAsync(UserID).GetAwaiter().GetResult();
        public static clsUser FindByPersonID(int PersonID) => FindByPersonIDAsync(PersonID).GetAwaiter().GetResult();
        public static clsUser FindByUsernameAndPassword(string UserName, string Password) => FindByUsernameAndPasswordAsync(UserName, Password).GetAwaiter().GetResult();
        public bool Save() => SaveAsync().GetAwaiter().GetResult();
        public static DataTable GetAllUsers() => GetAllUsersAsync().GetAwaiter().GetResult();
        public static bool DeleteUser(int UserID) => DeleteUserAsync(UserID).GetAwaiter().GetResult();
        public static bool isUserExist(int UserID) => IsUserExistAsync(UserID).GetAwaiter().GetResult();
        public static bool isUserExist(string UserName) => IsUserExistAsync(UserName).GetAwaiter().GetResult();
        public static bool isUserExistForPersonID(int PersonID) => IsUserExistForPersonIDAsync(PersonID).GetAwaiter().GetResult();
        public static bool ChangePassword(int UserID, string NewPassword) => ChangePasswordAsync(UserID, NewPassword).GetAwaiter().GetResult();
    }
}
