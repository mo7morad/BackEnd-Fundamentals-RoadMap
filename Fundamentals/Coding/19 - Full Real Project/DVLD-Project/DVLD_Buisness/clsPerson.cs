using System;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName => FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        public string NationalNo { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public clsCountry CountryInfo;
        public string ImagePath { set; get; }

        public clsPerson()
        {
            PersonID = -1; FirstName = ""; SecondName = ""; ThirdName = ""; LastName = ""; DateOfBirth = DateTime.Now; Address = ""; Phone = ""; Email = ""; NationalityCountryID = -1; ImagePath = ""; Mode = enMode.AddNew;
        }

        private clsPerson(int personID, string firstName, string secondName, string thirdName, string lastName, string nationalNo, DateTime dateOfBirth, short genderVal, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID; FirstName = firstName; SecondName = secondName; ThirdName = thirdName; LastName = lastName; NationalNo = nationalNo; DateOfBirth = dateOfBirth; gender = genderVal; Address = address; Phone = phone; Email = email; NationalityCountryID = nationalityCountryID; ImagePath = imagePath; Mode = enMode.Update;
        }

        private PersonDTO ToDTO() => new PersonDTO(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, gender, Address, Phone, Email, NationalityCountryID, ImagePath);

        private static clsPerson FromDTO(PersonDTO dto)
        {
            if (dto == null) return null;
            return new clsPerson(dto.PersonID, dto.FirstName, dto.SecondName, dto.ThirdName, dto.LastName, dto.NationalNo, dto.DateOfBirth, dto.Gender, dto.Address, dto.Phone, dto.Email, dto.NationalityCountryID, dto.ImagePath);
        }

        private async Task _LoadCountryInfoAsync() { CountryInfo = await clsCountry.FindAsync(NationalityCountryID).ConfigureAwait(false); }

        private async Task<bool> _AddNewPersonAsync() { PersonID = await clsPersonData.AddNewPersonAsync(ToDTO()).ConfigureAwait(false); return PersonID != -1; }

        private async Task<bool> _UpdatePersonAsync() => await clsPersonData.UpdatePersonAsync(ToDTO()).ConfigureAwait(false);

        // Async methods
        public static async Task<clsPerson> FindAsync(int PersonID)
        {
            PersonDTO dto = await clsPersonData.GetPersonInfoByIDAsync(PersonID).ConfigureAwait(false);
            if (dto == null) return null;
            var person = FromDTO(dto);
            await person._LoadCountryInfoAsync().ConfigureAwait(false);
            return person;
        }

        public static async Task<clsPerson> FindByNationalNoAsync(string NationalNo)
        {
            PersonDTO dto = await clsPersonData.GetPersonInfoByNationalNoAsync(NationalNo).ConfigureAwait(false);
            if (dto == null) return null;
            var person = FromDTO(dto);
            await person._LoadCountryInfoAsync().ConfigureAwait(false);
            return person;
        }

        public async Task<bool> SaveAsync()
        {
            switch (Mode)
            {
                case enMode.AddNew: if (await _AddNewPersonAsync().ConfigureAwait(false)) { Mode = enMode.Update; return true; } return false;
                case enMode.Update: return await _UpdatePersonAsync().ConfigureAwait(false);
            }
            return false;
        }

        public static async Task<DataTable> GetAllPeopleAsync() => await clsPersonData.GetAllPeopleAsync().ConfigureAwait(false);
        public static async Task<bool> DeletePersonAsync(int ID) => await clsPersonData.DeletePersonAsync(ID).ConfigureAwait(false);
        public static async Task<bool> IsPersonExistAsync(int ID) => await clsPersonData.IsPersonExistAsync(ID).ConfigureAwait(false);
        public static async Task<bool> IsPersonExistAsync(string NationalNo) => await clsPersonData.IsPersonExistByNationalNoAsync(NationalNo).ConfigureAwait(false);

        // Sync wrappers for backward compatibility
        public static clsPerson Find(int PersonID) => FindAsync(PersonID).GetAwaiter().GetResult();
        public static clsPerson Find(string NationalNo) => FindByNationalNoAsync(NationalNo).GetAwaiter().GetResult();
        public bool Save() => SaveAsync().GetAwaiter().GetResult();
        public static DataTable GetAllPeople() => GetAllPeopleAsync().GetAwaiter().GetResult();
        public static bool DeletePerson(int ID) => DeletePersonAsync(ID).GetAwaiter().GetResult();
        public static bool isPersonExist(int ID) => IsPersonExistAsync(ID).GetAwaiter().GetResult();
        public static bool isPersonExist(string NationalNo) => IsPersonExistAsync(NationalNo).GetAwaiter().GetResult();
    }
}
