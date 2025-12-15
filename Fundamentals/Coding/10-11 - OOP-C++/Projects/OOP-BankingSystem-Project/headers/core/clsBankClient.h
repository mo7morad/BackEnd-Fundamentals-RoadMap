#pragma once
#include <iostream>
#include <string>
#include "clsPerson.h"
#include "../lib/clsString.h"
#include "../lib/clsDate.h"
#include "../Global.h"
#include <vector>
#include <fstream>

using namespace std;

class clsBankClient : public clsPerson
{
private:

    enum enMode 
    { 
        EmptyMode = 0,
        UpdateMode = 1,
        AddNewMode = 2,
    };

    enMode _Mode;
    bool _MarkedForDelete = false;
    string _AccountNumber;
    string _PinCode;
    float _AccountBalance;

    static clsBankClient _ConvertLinetoClientObject(string Line, string Seperator = "#//#")
    {
        vector<string> vClientData;
        vClientData = clsString::Split(Line, Seperator);

        return clsBankClient(enMode::UpdateMode, vClientData[0], vClientData[1], vClientData[2],
            vClientData[3], vClientData[4], vClientData[5], stod(vClientData[6]));
    }

    static clsBankClient _GetEmptyClientObject()
    {
        return clsBankClient(enMode::EmptyMode, "", "", "", "", "", "", 0);
    }

public:
    struct stTransferLogRecord
    {
        string DateTime;
        string SourceAccountNumber;
        string DestinationAccountNumber;
        float Amount;
        float srcBalanceAfter;
        float destBalanceAfter;
        string UserName;
    };

    clsBankClient(enMode Mode, string FirstName, string LastName,
        string Email, string Phone, string AccountNumber, string PinCode,
        float AccountBalance) :
        clsPerson(FirstName, LastName, Email, Phone)
    {
        _Mode = Mode;
        _AccountNumber = AccountNumber;
        _PinCode = PinCode;
        _AccountBalance = AccountBalance;
    }

    bool IsEmpty()
    {
        return (_Mode == enMode::EmptyMode);
    }

    bool MarkedForDelete()
    {
        return _MarkedForDelete;
    }

    string GetAccountNumber()
    {
        return _AccountNumber;
    }

    void SetPinCode(string PinCode)
    {
        _PinCode = PinCode;
    }

    string GetPinCode()
    {
        return _PinCode;
    }

    void SetAccountBalance(float AccountBalance)
    {
        _AccountBalance = AccountBalance;
    }

    float GetAccountBalance()
    {
        return _AccountBalance;
    }

    private:
    static string _ConvertClientObjectToLine(clsBankClient Client, string Seperator = "#//#")
    {
        string stClientRecord = "";
        stClientRecord += Client.GetFirstName() + Seperator;
        stClientRecord += Client.GetLastName() + Seperator;
        stClientRecord += Client.GetEmail() + Seperator;
        stClientRecord += Client.GetPhone() + Seperator;
        stClientRecord += Client.GetAccountNumber() + Seperator;
        stClientRecord += Client.GetPinCode() + Seperator;
        stClientRecord += to_string(Client.GetAccountBalance());

        return stClientRecord;
    }

    static  vector<clsBankClient> _LoadClientsDataFromFile()
    {
        vector <clsBankClient> vClients;
        fstream MyFile;
        MyFile.open("Clients.txt", ios::in);//read Mode

        if (MyFile.is_open())
        {
            string Line;
            while (getline(MyFile, Line))
            {
                clsBankClient Client = _ConvertLinetoClientObject(Line);
                vClients.push_back(Client);
            }
            MyFile.close();
        }
        return vClients;
    }

    static void _SaveClientsDataToFile(vector<clsBankClient> vClients)
    {
        fstream MyFile;
        MyFile.open("Clients.txt", ios::out); // overwrite
        string DataLine;

        if (MyFile.is_open())
        {
            for (clsBankClient C : vClients)
            {
                if (C.MarkedForDelete() == false)
                {
                    // we only write records that are not marked for delete.
                    DataLine = _ConvertClientObjectToLine(C);
                    MyFile << DataLine << endl;
                }
            }
            MyFile.close();
        }
    }

        void _Update()
        {
            fstream MyFile;
            MyFile.open("Clients.txt", ios::in); // Open file in read mode
            vector<clsBankClient> _vClients;

            if (MyFile.is_open())
            {
                string Line;
                while (getline(MyFile, Line))
                {
                    clsBankClient Client = _ConvertLinetoClientObject(Line);
                    if (Client.GetAccountNumber() == GetAccountNumber())
                    {
                        Client = *this; // Update the client with the current object's data
                    }
                    _vClients.push_back(Client); // Add the client to the vector
                }
                MyFile.close();
            }

            // Save the updated client data back to the file
            _SaveClientsDataToFile(_vClients);
        }

        void _AddDataLineToFile(string stDataLine)
        {
            fstream MyFile;
            MyFile.open("Clients.txt", ios::out | ios::app);

            if (MyFile.is_open())
            {
                MyFile << stDataLine << endl;
                MyFile.close();
            }
        }

        void _AddNewClientToFile()
        {
            string DataLine = _ConvertClientObjectToLine(*this);
            _AddDataLineToFile(DataLine);
        }

        string _PrepareTransferLogRecord(float Amount, clsBankClient DestinationClient,
                                            string UserName, string Seperator = "#//#")
        {
            string TransferLogRecord = "";
            TransferLogRecord += clsDate::GetSystemDateTimeString() + Seperator;
            TransferLogRecord += GetAccountNumber() + Seperator;
            TransferLogRecord += DestinationClient.GetAccountNumber() + Seperator;
            TransferLogRecord += to_string(Amount) + Seperator;
            TransferLogRecord += to_string(GetAccountBalance()) + Seperator;
            TransferLogRecord += to_string(DestinationClient.GetAccountBalance()) + Seperator;
            TransferLogRecord += UserName;
            return TransferLogRecord;
        }

        void _RegisterTransferLog(float Amount, clsBankClient DestinationClient, string UserName)
        {

            string DataLine = _PrepareTransferLogRecord(Amount, DestinationClient, UserName);

            fstream MyFile;
            MyFile.open("TransferLogs.txt", ios::out | ios::app);

            if (MyFile.is_open())
            {
                MyFile << DataLine << endl;
                MyFile.close();
            }
        }

        static stTransferLogRecord _ConvertTransferLogLineToRecord(string Line, string Seperator = "#//#")
        {
            stTransferLogRecord TransferLogRecord;

            vector<string> vTrnsferLogRecordLine = clsString::Split(Line, Seperator);
            TransferLogRecord.DateTime = vTrnsferLogRecordLine[0];
            TransferLogRecord.SourceAccountNumber = vTrnsferLogRecordLine[1];
            TransferLogRecord.DestinationAccountNumber = vTrnsferLogRecordLine[2];
            TransferLogRecord.Amount = stod(vTrnsferLogRecordLine[3]);
            TransferLogRecord.srcBalanceAfter = stod(vTrnsferLogRecordLine[4]);
            TransferLogRecord.destBalanceAfter = stod(vTrnsferLogRecordLine[5]);
            TransferLogRecord.UserName = vTrnsferLogRecordLine[6];

            return TransferLogRecord;
        }

    public:
    static clsBankClient Find(string AccountNumber)
    {
        fstream MyFile;
        MyFile.open("Clients.txt", ios::in);//read Mode

        if (MyFile.is_open())
        {
            string Line;
            while (getline(MyFile, Line))
            {
                clsBankClient Client = _ConvertLinetoClientObject(Line);
                if (Client.GetAccountNumber() == AccountNumber)
                {
                    MyFile.close();
                    return Client;
                }
            }
            MyFile.close();
        }
        return _GetEmptyClientObject();
    }

    static clsBankClient Find(string AccountNumber, string PinCode)
    {
        fstream MyFile;
        MyFile.open("Clients.txt", ios::in);//read Mode

        if (MyFile.is_open())
        {
            string Line;
            while (getline(MyFile, Line))
            {
                clsBankClient Client = _ConvertLinetoClientObject(Line);
                if (Client.GetAccountNumber() == AccountNumber && Client.GetPinCode() == PinCode)
                {
                    MyFile.close();
                    return Client;
                }
            }
            MyFile.close();
        }
        return _GetEmptyClientObject();
    }

    enum enSaveResults
    { svFaildEmptyObject = 0, svSucceeded = 1, svFaildAccountNumberExists = 2, };

    enSaveResults Save()
    {
        switch (_Mode)
        {
        case EmptyMode:
        {
            if (IsEmpty())
            {
                return svFaildEmptyObject;
            }
        }

        case enMode::UpdateMode:
        {
            _Update();
            return svSucceeded;
            break;
        }
        // This will add new record to file or database
        case enMode::AddNewMode:
        {
            // Check if account number is already exists
            if (IsClientExist(_AccountNumber))
            {
                return svFaildAccountNumberExists;
            }
            else
            {
                _AddNewClientToFile();
                _Mode = UpdateMode; // We need to set the mode to update after add new client
                return svSucceeded;
            }
            break;
        }
        }
    return svFaildEmptyObject;
    }

    bool Delete()
    {
        vector<clsBankClient> vClient;
        vClient = _LoadClientsDataFromFile();

        for (clsBankClient &C : vClient)
        {
            if (C._AccountNumber == _AccountNumber)
            {
                C._MarkedForDelete = true;
                _SaveClientsDataToFile(vClient);
                *this = _GetEmptyClientObject();
                return true;
            }
        }
        return false;
    }

    static bool IsClientExist(string AccountNumber)
    {
        clsBankClient Client1 = clsBankClient::Find(AccountNumber);
        return (!Client1.IsEmpty());
    }

    static clsBankClient GetAddNewClientObject(string AccountNumber)
    {
        return clsBankClient(enMode::AddNewMode, "", "", "", "", AccountNumber, "", 0);
    }

    static vector<clsBankClient> GetClientsList()
    {
        return _LoadClientsDataFromFile();
    }

    void Deposit(double Amount)
    {
        _AccountBalance += Amount;
        Save();
    }

    bool Withdraw(double Amount)
    {
        if (Amount > _AccountBalance)
        {
            return false;
        }
        else
        {
            _AccountBalance -= Amount;
            Save();
            return true;
        }
    }

    bool Transfer(float Amount, clsBankClient &DestinationClient)
    {
        if (Amount > GetAccountBalance())
        {
            return false;
        }

        Withdraw(Amount);
        DestinationClient.Deposit(Amount);
        _RegisterTransferLog(Amount, DestinationClient, CurrentUser.GetUserName());
        return true;
    }

    static float GetTotalBalances()
    {
        vector<clsBankClient> vClients = clsBankClient::GetClientsList();
        double TotalBalances = 0;

        for (clsBankClient Client : vClients)
        {
            TotalBalances += Client.GetAccountBalance();
        }
        return TotalBalances;
    }

    static vector<stTransferLogRecord> GetTransfersLogList()
    {
        vector<stTransferLogRecord> vTransferLogRecord;

        fstream MyFile;
        MyFile.open("TransferLogs.txt", ios::in); // read Mode

        if (MyFile.is_open())
        {
            string Line;
            stTransferLogRecord TransferRecord;
            while (getline(MyFile, Line))
            {
                TransferRecord = _ConvertTransferLogLineToRecord(Line);
                vTransferLogRecord.push_back(TransferRecord);
            }
            MyFile.close();
        }
        return vTransferLogRecord;
    }
};
