#pragma once
#include <iostream>
#include "../clsScreen.h"
#include "../../core/clsBankClient.h"
#include "../../lib/clsInputValidation.h"
#include <iomanip>
using namespace std;

class clsTransferScreen : protected clsScreen
{
private:
  static void _PrintTransferClientCard(clsBankClient Client)
  {
    cout << "\nClient Card:";
    cout << "\n___________________";
    cout << "\nFull Name   : " << Client.GetFullName();
    cout << "\nAcc. Number : " << Client.GetAccountNumber();
    cout << "\nBalance     : " << Client.GetAccountBalance();
    cout << "\n___________________\n";
  }

  static string _ReadAccountNumber(string Destination)
  {
    string AccountNumber;
    cout << "\nPlease Enter Account Number to Transfer " << Destination << " : ";
    AccountNumber = clsInputValidation::ReadString();
    while (!clsBankClient::IsClientExist(AccountNumber))
    {
      cout << "\nAccount number is not found, choose another one: ";
      AccountNumber = clsInputValidation::ReadString();
    }
    return AccountNumber;
  }

  static float _ReadAmount(clsBankClient SourceClient)
  {
    float Amount;
    cout << "\nEnter Transfer Amount? ";
    Amount = clsInputValidation::ReadFloatNumber();

    while (Amount > SourceClient.GetAccountBalance())
    {
      cout << "\nAmount Exceeds the available Balance, Enter another Amount ? ";
      Amount = clsInputValidation::ReadFloatNumber();
    }
    return Amount;
  }

  static void _ShowTransferScreen()
  {
    _DrawScreenHeader("\tTransfer Screen");

    clsBankClient SourceClient = clsBankClient::Find(_ReadAccountNumber("From"));
    _PrintTransferClientCard(SourceClient);

    clsBankClient DestinationClient = clsBankClient::Find(_ReadAccountNumber("To"));
    while (SourceClient.GetAccountNumber() == DestinationClient.GetAccountNumber())
    {
      cout << "\nYou can't transfer to the same account\n";
      DestinationClient = clsBankClient::Find(_ReadAccountNumber("To"));
    }
    _PrintTransferClientCard(DestinationClient);

    float Amount = _ReadAmount(SourceClient);

    cout << "\nAre you sure you want to perform this operation? y/n? ";
    char Answer = 'n';
    cin >> Answer;
    if (Answer == 'Y' || Answer == 'y')
    {
      if (SourceClient.Transfer(Amount, DestinationClient))
      {
        cout << "\nTransfer done successfully\n";
      }
      else
      {
        cout << "\nTransfer Faild \n";
      }
    }

    _PrintTransferClientCard(SourceClient);
    _PrintTransferClientCard(DestinationClient);
  }

public:
  static void ShowTransferScreen()
  {
    _ShowTransferScreen();
  }
};