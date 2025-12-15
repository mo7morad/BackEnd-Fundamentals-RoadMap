#pragma once
#include <iostream>
#include <string>
#include "clsPerson.h"
#include "../lib/clsDate.h"
#include "../lib/clsString.h"
#include "../lib/clsUtil.h"
#include <vector>
#include <fstream>

using namespace std;
class clsUser : public clsPerson
{
public:
    struct stLogRecord;

private:

        enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2 };
        enMode _Mode;
        string _UserName;
        string _Password;
        short _Permissions;
        bool _MarkedForDelete = false;

        static stLogRecord _ConvertLogLineToRecord(string Line, string Seperator = "#//#")
        {
            stLogRecord LogRecord;

            vector<string> LogDataLine = clsString::Split(Line, Seperator);
            LogRecord.DateTime = LogDataLine[0];
            LogRecord.UserName = LogDataLine[1];
            LogRecord.Password = clsUtil::DecryptText(LogDataLine[2]);
            LogRecord.Permissions = stoi(LogDataLine[3]);

            return LogRecord;
        }

        string _PrepareLogInRecord(string Seperator = "#//#")
        {
            string LoginRecord = "";
            LoginRecord += clsDate::GetSystemDateTimeString() + Seperator;
            LoginRecord += GetUserName() + Seperator;
            LoginRecord += clsUtil::EncryptText(GetPassword()) + Seperator;
            LoginRecord += to_string(GetPermissions());
            return LoginRecord;
        }

        static clsUser _ConvertLinetoUserObject(string Line, string Seperator = "#//#")
        {
            vector<string> vUserData;
            vUserData = clsString::Split(Line, Seperator);

            return clsUser(enMode::UpdateMode, vUserData[0], vUserData[1], vUserData[2],
                vUserData[3], vUserData[4], clsUtil::DecryptText(vUserData[5]), stoi(vUserData[6]));
        }

        static string _ConverUserObjectToLine(clsUser User, string Seperator = "#//#")
        {
            string UserRecord = "";
            UserRecord += User.GetLastName() + Seperator;
            UserRecord += User.GetFirstName() + Seperator;
            UserRecord += User.GetEmail() + Seperator;
            UserRecord += User.GetPhone() + Seperator;
            UserRecord += User.GetUserName() + Seperator;
            UserRecord += clsUtil::EncryptText(User.GetPassword())+ Seperator;
            UserRecord += to_string(User.GetPermissions());


            return UserRecord;
        }

        static  vector <clsUser> _LoadUsersDataFromFile()
        {
            vector <clsUser> vUsers;
            fstream MyFile;
            MyFile.open("Users.txt", ios::in);//read Mode

            if (MyFile.is_open())
            {
                string Line;
                while (getline(MyFile, Line))
                {
                    clsUser User = _ConvertLinetoUserObject(Line);
                    vUsers.push_back(User);
                }
                MyFile.close();
            }
            return vUsers;
        }

        static void _SaveUsersDataToFile(vector <clsUser> vUsers)
        {
            fstream MyFile;
            MyFile.open("Users.txt", ios::out);//overwrite
            string DataLine;

            if (MyFile.is_open())
            {
                for (clsUser U : vUsers)
                {
                    if (U.MarkedForDelete() == false)
                    {
                        //we only write records that are not marked for delete.  
                        DataLine = _ConverUserObjectToLine(U);
                        MyFile << DataLine << endl;
                    }
                }
                MyFile.close();
            }
        }

        void _Update()
        {
            vector <clsUser> _vUsers;
            _vUsers = _LoadUsersDataFromFile();

            for (clsUser& U : _vUsers)
            {
                if (U.GetUserName() == _UserName)
                {
                    U = *this;
                    break;
                }
            }
            _SaveUsersDataToFile(_vUsers);
        }

        void _AddNew()
        {
            _AddDataLineToFile(_ConverUserObjectToLine(*this));
        }

        void _AddDataLineToFile(string  stDataLine)
        {
            fstream MyFile;
            MyFile.open("Users.txt", ios::out | ios::app);

            if (MyFile.is_open())
            {
                MyFile << stDataLine << endl;
                MyFile.close();
            }
        }

        static clsUser _GetEmptyUserObject()
        {
            return clsUser(enMode::EmptyMode, "", "", "", "", "", "", 0);
        }

public:

    enum enPermissions
    {
        None = 0,                 // 00000000 >> 0
        ShowClientsList = 1 << 0, // 00000001 >> 1
        AddClient = 1 << 1,       // 00000010 >> 2 
        DeleteClient = 1 << 2,    // 00000100 >> 4
        UpdateClient = 1 << 3,    // 00001000 >> 8
        FindClient = 1 << 4,      // 00010000 >> 16
        Transactions = 1 << 5,    // 00100000 >> 32
        ManageUsers = 1 << 6,     // 01000000 >> 64
        ShowLoginLogs = 1 << 7,        // 10000000 >> 128
        ShowUpdateCurrencyRate = 1 << 8, // 100000000 >> 256
        AllPermissions = ~0       // 11111111 (enables all bits)
    };

    struct stLogRecord
    {
        string DateTime;
        string UserName;
        string Password;
        int Permissions;
    };

    clsUser(enMode Mode, string FirstName, string LastName,
        string Email, string Phone, string UserName, string Password,
        int Permissions) :
        clsPerson(FirstName, LastName, Email, Phone)
    {
        _Mode = Mode;
        _UserName = UserName;
        _Password = Password;
        _Permissions = Permissions;
    }

    bool IsEmpty()
    {
        return (_Mode == enMode::EmptyMode);
    }

    bool MarkedForDelete()
    {
        return _MarkedForDelete;
    }

    string GetUserName()
    {
        return _UserName;
    }

    void SetUserName(string UserName)
    {
        _UserName = UserName;
    }

    void SetPassword(string Password)
    {
        _Password = Password;
    }

    string GetPassword()
    {
        return _Password;
    }

    void SetPermissions(short Permissions)
    {
        _Permissions = Permissions;
    }

    short GetPermissions()
    {
        return _Permissions;
    }

    static clsUser Find(string UserName)
    {
        fstream MyFile;
        MyFile.open("Users.txt", ios::in);//read Mode

        if (MyFile.is_open())
        {
            string Line;
            while (getline(MyFile, Line))
            {
                clsUser User = _ConvertLinetoUserObject(Line);
                if (User.GetUserName() == UserName)
                {
                    MyFile.close();
                    return User;
                }
            }
            MyFile.close();
        }
        return _GetEmptyUserObject();
    }

    static clsUser Find(string UserName, string Password)
    {
        fstream MyFile;
        MyFile.open("Users.txt", ios::in);//read Mode

        if (MyFile.is_open())
        {
            string Line;
            while (getline(MyFile, Line))
            {
                clsUser User = _ConvertLinetoUserObject(Line);
                if (User.GetUserName() == UserName && User.GetPassword() == Password)
                {
                    MyFile.close();
                    return User;
                }
            }
            MyFile.close();
        }
        return _GetEmptyUserObject();
    }

    enum enSaveResults { svFaildEmptyObject = 0, svSucceeded = 1, svFaildUserExists = 2 };

    enSaveResults Save()
    {
        switch (_Mode)
        {
        case enMode::EmptyMode:
        {
            if (IsEmpty())
            {
                return enSaveResults::svFaildEmptyObject;
            }
        }

        case enMode::UpdateMode:
        {
            _Update();
            return enSaveResults::svSucceeded;

            break;
        }

        case enMode::AddNewMode:
        {
            //This will add new record to file or database
            if (clsUser::IsUserExist(_UserName))
            {
                return enSaveResults::svFaildUserExists;
            }
            else
            {
                _AddNew();
                //We need to set the mode to update after add new
                _Mode = enMode::UpdateMode;
                return enSaveResults::svSucceeded;
            }
            break;
        }
        }
        return svFaildEmptyObject;
    }

    static bool IsUserExist(string UserName)
    {
        clsUser User = clsUser::Find(UserName);
        return (!User.IsEmpty());
    }

    bool Delete()
    {
        vector <clsUser> _vUsers;
        _vUsers = _LoadUsersDataFromFile();

        for (clsUser& U : _vUsers)
        {
            if (U.GetUserName() == _UserName)
            {
                U._MarkedForDelete = true;
                break;
            }
        }
        _SaveUsersDataToFile(_vUsers);
        *this = _GetEmptyUserObject();
        return true;
    }

    static clsUser GetAddNewUserObject(string UserName)
    {
        return clsUser(enMode::AddNewMode, "", "", "", "", UserName, "", 0);
    }

    static vector <clsUser> GetUsersList()
    {
        return _LoadUsersDataFromFile();
    }

    bool CheckAccessPermission(enPermissions Permission)
    {
        return ((enPermissions(this->_Permissions) & Permission));
    }

    void RegisterLogIn()
    {
        string DataLine = _PrepareLogInRecord();

        fstream MyFile;
        MyFile.open("LoginLogs.txt", ios::out | ios::app);

        if (MyFile.is_open())
        {
            MyFile << DataLine << endl;
            MyFile.close();
        }
    }

    static vector<stLogRecord> GetLoginLogsList()
    {
        vector<stLogRecord> vLogsRecords;

        fstream MyFile;
        MyFile.open("LoginLogs.txt", ios::in); // read Mode

        if (MyFile.is_open())
        {
            string Line;
            stLogRecord LogRecord;

            while (getline(MyFile, Line))
            {
                LogRecord = _ConvertLogLineToRecord(Line);
                vLogsRecords.push_back(LogRecord);
            }

            MyFile.close();
        }
        return vLogsRecords;
    }
};

