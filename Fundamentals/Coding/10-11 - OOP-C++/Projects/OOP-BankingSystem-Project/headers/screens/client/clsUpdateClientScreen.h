#pragma once
#include <iostream>
#include "../clsScreen.h"
#include "../../core/clsBankClient.h"
#include "../../lib/clsInputValidation.h"
#include <iomanip>
using namespace std;

class clsUpdateClientScreen : protected clsScreen
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
  static void ShowUpdateClientScreen()
  {
    if (!CheckAccessRights(clsUser::enPermissions::UpdateClient))
      return;
    _DrawScreenHeader("\tUpdate Client Screen");
    string AccountNumber = "";
    cout << "\nPlease Enter client Account Number: ";
    AccountNumber = clsInputValidation::ReadString();

    while (!clsBankClient::IsClientExist(AccountNumber))
    {
      cout << "\nAccount number is not found, choose another one: ";
      AccountNumber = clsInputValidation::ReadString();
    }
    clsBankClient Client1 = clsBankClient::Find(AccountNumber);
    _PrintClient(Client1);
    cout << "\nAre you sure you want to update this client y/n? ";
    char Answer = 'n';
    cin >> Answer;
    if (Answer == 'y' || Answer == 'Y')
    {
      cout << "\n\nUpdate Client Info:";
      cout << "\n____________________\n";
      _ReadClientInfo(Client1);

      clsBankClient::enSaveResults SaveResult;
      SaveResult = Client1.Save();

      switch (SaveResult)
      {
      case clsBankClient::enSaveResults::svSucceeded:
      {
        cout << "\nAccount Updated Successfully :-)\n";
        _PrintClient(Client1);
        break;
      }
      case clsBankClient::enSaveResults::svFaildEmptyObject:
      {
        cout << "\nError account was not saved because it's Empty";
        break;
      }
      }
    }
  }
};