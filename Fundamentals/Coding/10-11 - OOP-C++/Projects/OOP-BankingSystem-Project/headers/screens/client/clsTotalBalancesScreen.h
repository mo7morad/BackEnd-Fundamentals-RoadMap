#pragma once
#include <iostream>
#include "../clsScreen.h"
#include "../../core/clsBankClient.h"
#include "../../lib/clsUtil.h"
#include <iomanip>

class clsTotalBalancesScreen : protected clsScreen
{

private:
  static void _PrintClientRecordBalanceLine(clsBankClient Client)
  {
    cout << setw(25) << left << "" << "| " << setw(15) << left << Client.GetAccountNumber();
    cout << "| " << setw(40) << left << Client.GetFullName();
    cout << "| " << setw(12) << left << Client.GetAccountBalance();
  }

public:
  static void ShowTotalBalancesScreen()
  {
    vector<clsBankClient> vClients = clsBankClient::GetClientsList();
    string Title = "\t  Balances List Screen";
    string SubTitle = "\t    (" + to_string(vClients.size()) + ") Client(s).";

    _DrawScreenHeader(Title, SubTitle);

    cout << setw(25) << left << "" << "\n\t\t_______________________________________________________";
    cout << "__________________________\n" << endl;
    cout << setw(25) << left << "" << "| " << left << setw(15) << "Accout Number";
    cout << "| " << left << setw(40) << "Client Name";
    cout << "| " << left << setw(12) << "Balance";
    cout << setw(25) << left << "" << "\n\t\t_______________________________________________________";
    cout << "__________________________\n" << endl;

    double TotalBalances = clsBankClient::GetTotalBalances();

    if (vClients.size() == 0)
      cout << "\t\t\t\tNo Clients Available In the System!";
    else
      for (clsBankClient Client : vClients)
      {
        _PrintClientRecordBalanceLine(Client);
        cout << endl;
      }
    cout << setw(25) << left << "" << "\n\t\t_______________________________________________________";
    cout << "__________________________\n" << endl;
    cout << setw(8) << left << "" << "\t\t\t\t\tTotal Balances = " << TotalBalances << endl;
    cout << setw(8) << left << "" << "\t\t\t\t( " << clsUtil::NumberToText(TotalBalances) << ")";
  }
};
