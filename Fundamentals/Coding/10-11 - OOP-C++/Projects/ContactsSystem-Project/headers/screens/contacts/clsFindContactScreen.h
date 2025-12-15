#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../core/clsContact.h"
#include "../../lib/clsInputValidate.h"
using namespace std;

class clsFindContactScreen : protected clsScreen
{
private:
  static void _DrawSearchOptions()
  {
    cout << "\nChoose Searching Option: " << endl;
    cout << "1. Search by Contact ID" << endl;
    cout << "2. Search by Full Name" << endl;
    cout << "3. Search by Email" << endl;
    cout << "4. Search by Phone Number" << endl;
    cout << "5. Go Back To Main Menu" << endl;
  }

  static void _ShowFindContactScreen()
  {
    cout << setw(37) << left << "" << "\n\tPress any key to go back to Find Menu Screen...\n";
    cin.ignore();
    cin.get();
    clsFindContactScreen::ShowFindContactScreen();
  }

  static clsContact _ReadSearchOption()
  {
    _DrawSearchOptions();
    clsContact Contact = clsContact::GetDeleteContactObject();
    short Choice = clsInputValidate<short>::ReadNumberBetween(1, 5, "Enter Number between 1 to 5? ");
    switch (Choice)
    {
    case clsContact::enSearchBy::Id:
    {
      do
      {
        cout << "\nEnter Contact ID to Search: ";
        string ContactId = clsInputValidate<string>::ReadString();
        Contact = clsContact::SearchContact(clsContact::enSearchBy::Id, ContactId);
        if (Contact.IsEmpty())
        {
          cout << "\nContact Not Found!";
        }
      } while (Contact.IsEmpty());
      return Contact;
    }
    case clsContact::enSearchBy::FullName:
    {
      do
      {
        cout << "\nEnter Full Name to Search: ";
        string FullName = clsInputValidate<string>::ReadString();
        Contact = clsContact::SearchContact(clsContact::enSearchBy::FullName, FullName);
        if (Contact.IsEmpty())
        {
          cout << "\nContact Not Found!";
        }
      } while (Contact.IsEmpty());
      return Contact;
    }
    case clsContact::enSearchBy::Email:
    {
      do
      {
        cout << "\nEnter Email to Search: ";
        string Email = clsInputValidate<string>::ReadString();
        Contact = clsContact::SearchContact(clsContact::enSearchBy::Email, Email);
        if (Contact.IsEmpty())
        {
          cout << "\nContact Not Found!";
        }
      } while (Contact.IsEmpty());
      return Contact;
    }
    case clsContact::enSearchBy::Phone:
    {
      do
      {
        cout << "\nEnter Phone Number to Search: ";
        string Phone = clsInputValidate<string>::ReadString();
        Contact = clsContact::SearchContact(clsContact::enSearchBy::Phone, Phone);
        if (Contact.IsEmpty())
        {
          cout << "\nContact Not Found!";
        }
      } while (Contact.IsEmpty());
      return Contact;
    }
    case 5:
    {
      break;
    }
    default:
      break;
    }
    return Contact;
  }

public:
  static void ShowFindContactScreen()
  {
    system("clear");
    string Title = "\t  Find Contact Screen";
    _DrawScreenHeader(Title);

    clsContact Contact = _ReadSearchOption();
    if(!Contact.IsEmpty())
    {
      Contact.PrintContactCard();
      _ShowFindContactScreen();
    }
  }
};