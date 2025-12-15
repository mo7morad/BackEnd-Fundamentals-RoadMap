#pragma once
#include <iostream>
#include "../clsScreen.h"
#include "../../core/clsBankClient.h"
#include "../../lib/clsInputValidation.h"
#include <iomanip>
using namespace std;

class clsAddNewClient : protected clsScreen
{

private:

  static void _ReadClientInfo(clsBankClient &Client)
  {
    cout << "\nEnter First Name: ";
    Client.SetFirstName(clsInputValidation::ReadString());

    cout << "\nEnter Last Name: ";
    Client.SetLastName(clsInputValidation::ReadString());

    cout << "\nEnter Email: ";
    Client.SetEmail(clsInputValidation::ReadString());

    cout << "\nEnter Phone: ";
    Client.SetPhone(clsInputValidation::ReadString());

    cout << "\nEnter Pin Code: ";
    Client.SetPinCode(clsInputValidation::ReadString());

    cout << "\nEnter Account Balance: ";
    Client.SetAccountBalance(clsInputValidation::ReadDoubleNumber()); // Use ReadDoubleNumber for balance
  }

  static void _PrintClient(clsBankClient Client)
  {
    cout << "\nClient Card:";
    cout << "\n___________________";
    cout << "\nFirstName   : " << Client.GetFirstName();
    cout << "\nLastName    : " << Client.GetLastName();
    cout << "\nFull Name   : " << Client.GetFullName();
    cout << "\nEmail       : " << Client.GetEmail();
    cout << "\nPhone       : " << Client.GetPhone();
    cout << "\nAcc. Number : " << Client.GetAccountNumber();
    cout << "\nPassword    : " << Client.GetPinCode();
    cout << "\nBalance     : " << Client.GetAccountBalance();
    cout << "\n___________________\n";
  }

public:
  static void ShowAddNewClientScreen()
  {
    // Check if the user has the right to add a new client. if not, return.
    if(!CheckAccessRights(clsUser::enPermissions::AddClient))
      return;

    _DrawScreenHeader("\t  Add New Client Screen");
    string AccountNumber = "";
    cout << "\nPlease Enter Account Number: ";
    AccountNumber = clsInputValidation::ReadString();

    while (clsBankClient::IsClientExist(AccountNumber))
    {
      cout << "\nAccount Number Is Already Used, Choose another one: ";
      AccountNumber = clsInputValidation::ReadString();
    }

    clsBankClient NewClient = clsBankClient::GetAddNewClientObject(AccountNumber);
    _ReadClientInfo(NewClient);

    clsBankClient::enSaveResults SaveResult;
    SaveResult = NewClient.Save();
    switch (SaveResult)
    {
    case clsBankClient::enSaveResults::svSucceeded:
    {
      cout << "\nAccount Addeded Successfully :-)\n";
      _PrintClient(NewClient);
      break;
    }
    case clsBankClient::enSaveResults::svFaildEmptyObject:
    {
      cout << "\nError account was not saved because it's Empty";
      break;
    }
    case clsBankClient::enSaveResults::svFaildAccountNumberExists:
    {
      cout << "\nError account was not saved because account number is used!\n";
      break;
    }
    }
  }
};