#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../core/clsContact.h"
#include "../../lib/clsInputValidate.h"
using namespace std;

class clsAddNewContactScreen : protected clsScreen
{
private:
  static void _ReadNewContactInfo(clsContact &Contact)
  {
    do{
      cout << "\nEnter Contact's Phone Number: ";
      Contact.SetPhoneNumber(clsInputValidate<string>::ReadString());
      if (Contact.IsContactExists(Contact.GetPhoneNumber()))
      {
        cout << "\nContact with this Phone Number already exists!";
        return;
      }
      }while (Contact.IsContactExists(Contact.GetPhoneNumber()));

    cout << "\nEnter Contact's First Name: ";
    Contact.SetFirstName(clsInputValidate<string>::ReadString());

    cout << "\nEnter Contact's Last Name: ";
    Contact.SetLastName(clsInputValidate<string>::ReadString());

    cout << "\nEnter Contact's Email: ";
    Contact.SetEmail(clsInputValidate<string>::ReadString());

    Contact.SetContactId(clsContact::GetNextContactId());
  }

public:
  static void ShowAddNewContactScreen()
  {
    system("clear");
    string Title = "\t  Add New Contact Screen";
    clsContact NewContact = clsContact::GetAddNewContactObject();

    _DrawScreenHeader(Title);
    _ReadNewContactInfo(NewContact);

    clsContact::enSaveResult SaveResult = NewContact.Save();
    if (SaveResult == clsContact::svSucceeded)
    {
      cout << "\nContact Added Successfully!";
      NewContact.PrintContactCard();
    }
    else if (SaveResult == clsContact::svFaildPhoneNumberExists)
    {
      cout << "\nSave Failed!";
    }
    else
    {
      cout << "\nFailed to Add Contact!";
    }
  }
};