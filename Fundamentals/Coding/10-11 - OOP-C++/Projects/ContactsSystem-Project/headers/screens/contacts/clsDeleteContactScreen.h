#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../core/clsContact.h"
#include "../../lib/clsInputValidate.h"
using namespace std;

class clsDeleteContactScreen : protected clsScreen
{
private:
  enum enDeleteContactOptions
  {
    DeleteById = 1,
    DeleteByFullName = 2,
    DeleteByEmail = 3,
    DeleteByPhoneNumber = 4,
    GoBackToMainMenu = 5
  };

  static void _ShowDeleteContactScreen()
  {
    cout << setw(37) << left << "" << "\n\tPress any key to go back to Delete Menu Screen...\n";
    cin.ignore();
    cin.get();
    clsDeleteContactScreen::ShowDeleteContactScreen();
  }

  static void _DrawDeleteOptions()
  {
    cout << "\nChoose Deletion Option: " << endl;
    cout << "1. Delete by Contact ID" << endl;
    cout << "2. Delete by Full Name" << endl;
    cout << "3. Delete by Email" << endl;
    cout << "4. Delete by Phone Number" << endl;
    cout << "5. Go Back To Main Menu" << endl;
  }

  static clsContact _ReadDeletionOption()
  {
    _DrawDeleteOptions();
    clsContact Contact = clsContact::GetDeleteContactObject();
    short Choice = clsInputValidate<short>::ReadNumberBetween(1, 5, "Enter Number between 1 to 5? ");
    switch (Choice)
    {
    case DeleteById:
    {
      do
      {
        cout << "\nEnter Contact ID to Delete: ";
        string ContactId = clsInputValidate<string>::ReadString();
        Contact = clsContact::SearchContact(clsContact::enSearchBy::Id, ContactId);
        if (Contact.IsEmpty())
        {
          cout << "\nContact Not Found!";
        }
      } while (Contact.IsEmpty());
      return Contact;
    }
    case DeleteByFullName:
    {
      do
      {
        cout << "\nEnter Full Name to Delete: ";
        string FullName = clsInputValidate<string>::ReadString();
        Contact = clsContact::SearchContact(clsContact::enSearchBy::FullName, FullName);
        if (Contact.IsEmpty())
        {
          cout << "\nContact Not Found!";
        }
      } while (Contact.IsEmpty());
      return Contact;
    }
    case DeleteByEmail:
    {
      do
      {
        cout << "\nEnter Email to Delete: ";
        string Email = clsInputValidate<string>::ReadString();
        Contact = clsContact::SearchContact(clsContact::enSearchBy::Email, Email);
        if (Contact.IsEmpty())
        {
          cout << "\nContact Not Found!";
        }
      } while (Contact.IsEmpty());
      return Contact;
    }
    case DeleteByPhoneNumber:
    {
      do
      {
        cout << "\nEnter Phone Number to Delete: ";
        string Phone = clsInputValidate<string>::ReadString();
        Contact = clsContact::SearchContact(clsContact::enSearchBy::Phone, Phone);
        if (Contact.IsEmpty())
        {
          cout << "\nContact Not Found!";
        }
      } while (Contact.IsEmpty());
      return Contact;
    }
    case GoBackToMainMenu:
    {
      break;
    }
    default:
      return Contact;
    }
    return Contact;
  }

public:
  static void ShowDeleteContactScreen()
  {
    system("clear");
    string Title = "\t  Delete Contact Screen";
    _DrawScreenHeader(Title);

    clsContact Contact = _ReadDeletionOption();
    if(!Contact.IsEmpty())
    {
      Contact.PrintContactCard();
      cout << "Are you sure you want to delete this contact? (Y/N): ";
      char Answer = 'n';
      cin >> Answer;
      if (Answer == 'y' || Answer == 'Y')
      {
        if (Contact.Delete())
        {
          cout << "\nContact Deleted Successfully!\n";
          _ShowDeleteContactScreen();
        }
        else
        {
          cout << "\nError happend contact is not Deleted!\n";
          _ShowDeleteContactScreen();
        }
      }
      else
      {
        cout << "\nAborted! Contact Is Not Deleted!";
        _ShowDeleteContactScreen();
      }
    }
  }
};