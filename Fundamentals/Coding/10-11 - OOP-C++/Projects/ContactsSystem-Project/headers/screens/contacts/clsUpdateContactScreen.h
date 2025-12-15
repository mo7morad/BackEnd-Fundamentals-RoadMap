#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../core/clsContact.h"
#include "../../lib/clsInputValidate.h"
#include "clsFindContactScreen.h"
using namespace std;

class clsUpdateContactScreen : protected clsScreen
{
private:

  enum enUpdateOption 
  {
    PhoneNumber = 1,
    FullName = 2,
    Email = 3
  };

  static void _ShowUpdateScreen()
  {
    cout << setw(37) << left << "" << "\n\tPress any key to go back to Update Menu Screen...\n";
    cin.ignore();
    cin.get();
    clsUpdateContactScreen::ShowUpdateContactScreen();
  }

  static void _DrawUpdateOptions()
  {
    cout << "\nWhat do you want to update? " << endl;
    cout << "1. Phone Number" << endl;
    cout << "2. Full Name" << endl;
    cout << "3. Email" << endl;
    cout << "4. Go Back To Main Menu" << endl;
  }

  static int _ReadContactID()
  {
    int ID = 0;
    cout << "\nPlease enter the contact ID that you want to edit: " << endl;
    cin >> ID;
    return ID;
  }

  static bool IsContactIDFound(int ID)
  {
    clsContact Contact = clsContact::SearchContact(clsContact::enSearchBy::Id, to_string(ID));
    if(Contact.IsEmpty())
      return false;

    return true;
  }

  static void _PerformUpdateOption(clsContact &Contact)
  {
    _DrawUpdateOptions();
    int option = clsInputValidate<int>::ReadNumberBetween(1,4);

    switch(enUpdateOption(option))
    {
    case PhoneNumber:
    {
      string Phone;
      cout << "Please Enter the new phone number: ";
      cin >> Phone;
      Contact.SetPhoneNumber(Phone);
      clsContact::enSaveResult SaveResult = Contact.Save();
      if (SaveResult == clsContact::enSaveResult::svSucceeded)
      {
        cout << "\nPhone Number Updated Successfully!";
        Contact.PrintContactCard();
        return;
      }
      else
      {
        cout << "\nFailed to update Phone Number!";
        Contact.PrintContactCard();
        return;
      }
    }
    case Email:
    {
      string Email;
      cout << "Please Enter the new email: ";
      cin >> Email;
      Contact.SetEmail(Email);
      clsContact::enSaveResult SaveResult = Contact.Save();
      if (SaveResult == clsContact::enSaveResult::svSucceeded)
      {
        cout << "\nEmail Updated Successfully!";
        Contact.PrintContactCard();
        return;
      }
      else
      {
        cout << "\nFailed to update Email!";
        Contact.PrintContactCard();
        return;
      }
    }
    case FullName:
    {
      string FirstName, LastName;
      cout << "Please Enter the new First Name: ";
      cin >> FirstName;
      cout << "Please Enter the new Last Name: ";
      cin >> LastName;
      Contact.SetFirstName(FirstName);
      Contact.SetLastName(LastName);
      clsContact::enSaveResult SaveResult = Contact.Save();
      if (SaveResult == clsContact::enSaveResult::svSucceeded)
      {
        cout << "\nFull Name Updated Successfully!";
        Contact.PrintContactCard();
        return;
      }
      else
      {
        cout << "\nFailed to update Full Name!";
        Contact.PrintContactCard();
        return;
      }
    }
    case 4:
    {
      return;
    }
    }
  }

public:

  static void ShowUpdateContactScreen()
  {
    system("clear");
    string Title = "\t  Edit Contact Screen";
    _DrawScreenHeader(Title);

    int ID = _ReadContactID();
    while (!IsContactIDFound(ID))
    {
      cout << "\nSorry ID is not found! ID(s) are from 0:" << clsContact::GetLatestContactId() << endl;
      ID = _ReadContactID();
    }
    clsContact Contact = clsContact::SearchContact(clsContact::enSearchBy::Id, to_string(ID));
    Contact.PrintContactCard();

    cout << "\nAre you sure you want to edit this contact y/n? ";
    char answer = 'n';
    cin >> answer;

    if (answer == 'y')
    {
      _PerformUpdateOption(Contact);
    }
    else
    {
      cout << "\nContact not updated!";
      _ShowUpdateScreen();
    }
  }
};