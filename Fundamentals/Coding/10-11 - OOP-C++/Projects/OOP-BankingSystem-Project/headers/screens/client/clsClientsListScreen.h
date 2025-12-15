#pragma once
#include <iostream>
#include "../clsScreen.h"
#include "../../core/clsBankClient.h"
#include <iomanip>

class clsClientsListScreen : protected clsScreen
{

private:
  static void _PrintClientRecordLine(clsBankClient Client)
  {

    cout << setw(8) << left << "" << "| " << setw(15) << left << Client.GetAccountNumber();
    cout << "| " << setw(20) << left << Client.GetFullName();
    cout << "| " << setw(12) << left << Client.GetPhone();
    cout << "| " << setw(20) << left << Client.GetEmail();
    cout << "| " << setw(10) << left << Client.GetPinCode();
    cout << "| " << setw(12) << left << Client.GetAccountBalance();
  }

public:
  static void ShowClientsList()
  {
    // Check if the user has the right to show the clients list. if not, return.
    if(!CheckAccessRights(clsUser::enPermissions::ShowClientsList))
      return;

    vector<clsBankClient> vClients = clsBankClient::GetClientsList();
    string Title = "\t  Client List Screen";
    string SubTitle = "\t    (" + to_string(vClients.size()) + ") Client(s).";

    _DrawScreenHeader(Title, SubTitle);
    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;

    cout << setw(8) << left << "" << "| " << left << setw(15) << "Accout Number";
    cout << "| " << left << setw(20) << "Client Name";
    cout << "| " << left << setw(12) << "Phone";
    cout << "| " << left << setw(20) << "Email";
    cout << "| " << left << setw(10) << "Pin Code";
    cout << "| " << left << setw(12) << "Balance";
    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;

    if (vClients.size() == 0)
      cout << "\t\t\t\tNo Clients Available In the System!";
    else
      for (clsBankClient Client : vClients)
      {
        _PrintClientRecordLine(Client);
        cout << endl;
      }
    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;
  }
};
