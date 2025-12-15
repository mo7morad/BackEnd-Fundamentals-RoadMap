#pragma once
#include <iostream>
#include "../clsScreen.h"
#include "../../core/clsBankClient.h"
#include "../../core/clsUser.h"
#include "../../lib/clsInputValidation.h"

class clsDeleteClientScreen : protected clsScreen
{
private:
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
  static void ShowDeleteClientScreen()
  {
    if (!CheckAccessRights(clsUser::enPermissions::DeleteClient))
      return;
    _DrawScreenHeader("\tDelete Client Screen");
    string AccountNumber = "";
    cout << "\nPlease Enter Account Number: ";
    AccountNumber = clsInputValidation::ReadString();
    while (!clsBankClient::IsClientExist(AccountNumber))
    {
        cout << "\nAccount number is not found, choose another one: ";
        AccountNumber = clsInputValidation::ReadString();
    }

    clsBankClient Client1 = clsBankClient::Find(AccountNumber);
    _PrintClient(Client1);
    cout << "\nAre you sure you want to delete this client y/n? ";
    char Answer = 'n';
    cin >> Answer;
    if (Answer == 'y' || Answer == 'Y')
    {
      if (Client1.Delete())
      {
          cout << "\nClient Deleted Successfully :-)\n";
          _PrintClient(Client1);
      }
      else
      {
          cout << "\nError Client Was not Deleted\n";
      }
    }
}
};