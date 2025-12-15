#pragma once
#include <iostream>
#include "../clsScreen.h"
#include "../../core/clsPerson.h"
#include "../../core/clsBankClient.h"
#include "../../lib/clsInputValidation.h"

class clsFindClientScreen : protected clsScreen
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
  static void ShowFindClientScreen()
  {
    if (!CheckAccessRights(clsUser::enPermissions::FindClient))
      return;
    _DrawScreenHeader("\tFind Client Screen");
    string AccountNumber;
    cout << "\nPlease Enter Account Number: ";
    AccountNumber = clsInputValidation::ReadString();
    while (!clsBankClient::IsClientExist(AccountNumber))
    {
      cout << "\nAccount number is not found, choose another one: ";
      AccountNumber = clsInputValidation::ReadString();
    }

    clsBankClient Client1 = clsBankClient::Find(AccountNumber);

    if (Client1.IsEmpty())
    {
      cout << "\nClient Was not Found :-(\n";
    }
    else
    {
      cout << "\nClient Found Successfully :-)\n";
    }
    _PrintClient(Client1);
  }
};
