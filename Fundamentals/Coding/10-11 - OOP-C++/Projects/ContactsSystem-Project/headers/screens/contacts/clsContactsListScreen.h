#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../core/clsContact.h"

class clsContactsListScreen : protected clsScreen
{

private:
  static void _PrintContactRecordLine(clsContact contact)
  {

    cout << setw(8) << left << "" << "| " << setw(15) << left << contact.GetContactId();
    cout << "| " << setw(20) << left << contact.GetFullName();
    cout << "| " << setw(20) << left << contact.GetPhoneNumber();
    cout << "| " << setw(20) << left << contact.GetEmail();
  }

public:
  static void ShowContactsList()
  {
    system("clear");
    vector<clsContact> vContacts = clsContact::GetAllContacts();
    string Title = "\t  Contacts List Screen";
    string SubTitle = "\t    (" + to_string(vContacts.size()) + ") Contact(s).";

    _DrawScreenHeader(Title, SubTitle);
    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;

    cout << setw(8) << left << "" << "| " << left << setw(15) << "Contact ID";
    cout << "| " << left << setw(20) << "Full Name";
    cout << "| " << left << setw(20) << "Phone Number";
    cout << "| " << left << setw(20) << "Email";
    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;

    if (vContacts.size() == 0)
      cout << "\t\t\t\tNo Clients Available In the System!";
    else
      for (clsContact Contact : vContacts)
      {
        _PrintContactRecordLine(Contact);
        cout << endl;
      }
    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;
  }
};
