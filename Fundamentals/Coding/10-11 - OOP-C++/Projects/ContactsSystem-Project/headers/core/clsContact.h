#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include "clsPerson.h"
#include "../lib/clsString.h"
using namespace std;

class clsContact : public clsPerson
{
private:
  enum enMode
  {
    EmptyMode = 0,
    UpdateMode = 1,
    AddNewMode = 2,
  };

  enMode _Mode;
  bool MarkedForDeletion = false;
  int _ContactId;

  static string _ConvertContactObjectToLine(clsContact Contact, string Separator = ",")
  {
    string DataLine;
    DataLine += to_string(Contact.GetContactId()) + Separator;
    DataLine += Contact.GetFirstName() + Separator;
    DataLine += Contact.GetLastName() + Separator;
    DataLine += clsString::LowerAllString(Contact.GetEmail()) + Separator;
    DataLine += Contact.GetPhoneNumber();
    return DataLine;
    // or
    // return to_string(Contact.GetContactId()) + Separator + Contact.GetFirstName() + Separator + Contact.GetLastName() + Separator + Contact.GetEmail() + Separator + Contact.GetPhoneNumber();
  }

  static clsContact _ConvertLineToContactObject(string Line, string Separator = ",")
  {
    vector<string> Tokens = clsString::Split(Line, Separator);
    return clsContact(UpdateMode, stoi(Tokens[0]), Tokens[1], Tokens[2], Tokens[3], Tokens[4]);
  }

  static vector<clsContact> _LoadContactsFromFile()
  {
    vector<clsContact> vContacts;
    string Line;
    fstream File;
    File.open("contacts.txt", ios::in);

    if (File.is_open())
    {
      while (getline(File, Line))
      {
        vContacts.push_back(_ConvertLineToContactObject(Line));
      }
      File.close();
    }

    return vContacts;
  }

  static void _SaveContactsToFile(vector<clsContact> vContacts)
  {
    fstream File;
    File.open("contacts.txt", ios::out);

    if (File.is_open())
    {
      for (clsContact &Contact : vContacts)
      {
        if (Contact.MarkedForDeletion == false)
          File << _ConvertContactObjectToLine(Contact) << endl;
      }
      File.close();
    }
  }

  void _AddDataLineToFile(string DataLine)
  {
    fstream MyFile;
    MyFile.open("contacts.txt", ios::out | ios::app);

    if (MyFile.is_open())
    {
      MyFile << DataLine << endl;
      MyFile.close();
    }
  }

  void _AddNewContactToFile()
  {
    _AddDataLineToFile(_ConvertContactObjectToLine(*this));
  }

  static int _GetLatestContactId()
  {
    vector<clsContact> vContacts = _LoadContactsFromFile();
    int LatestContactId = vContacts.back().GetContactId();

    return LatestContactId;
  }

  static clsContact _GetContactById(int ContactId)
  {
    fstream MyFile;
    MyFile.open("contacts.txt", ios::in); // Open file in read mode
    vector<clsContact> vContacts;

    if (MyFile.is_open())
    {
      string Line;
      while (getline(MyFile, Line))
      {
        clsContact Contact = _ConvertLineToContactObject(Line);
        if (Contact.GetContactId() == ContactId)
        {
          return Contact;
        }
      }
      MyFile.close();
    }
    return clsContact(EmptyMode, 0, "", "", "", "");
  }

  static clsContact _GetContactByFullName(string FullName)
  {
    fstream MyFile;
    MyFile.open("contacts.txt", ios::in); // Open file in read mode
    vector<clsContact> vContacts;

    if (MyFile.is_open())
    {
      string Line;
      while (getline(MyFile, Line))
      {
        clsContact Contact = _ConvertLineToContactObject(Line);
        if (Contact.GetFullName() == FullName)
        {
          return Contact;
        }
      }
      MyFile.close();
    }
    return clsContact(EmptyMode, 0, "", "", "", "");
  }

  static clsContact _GetContactByEmail(string Email)
  {
    fstream MyFile;
    MyFile.open("contacts.txt", ios::in); // Open file in read mode
    vector<clsContact> vContacts;

    if (MyFile.is_open())
    {
      string Line;
      while (getline(MyFile, Line))
      {
        clsContact Contact = _ConvertLineToContactObject(Line);
        if (Contact.GetEmail() == Email)
        {
          return Contact;
        }
      }
      MyFile.close();
    }
    return clsContact(EmptyMode, 0, "", "", "", "");
  }

  static clsContact _GetContactByPhone(string Phone)
  {
    fstream MyFile;
    MyFile.open("contacts.txt", ios::in); // Open file in read mode
    vector<clsContact> vContacts;

    if (MyFile.is_open())
    {
      string Line;
      while (getline(MyFile, Line))
      {
        clsContact Contact = _ConvertLineToContactObject(Line);
        if (Contact.GetPhoneNumber() == Phone)
        {
          return Contact;
        }
      }
      MyFile.close();
    }
    return clsContact(EmptyMode, 0, "", "", "", "");
  }

  void _Update()
  {
    fstream MyFile;
    MyFile.open("contacts.txt", ios::in); // Open file in read mode
    vector<clsContact> vContacts;

    if (MyFile.is_open())
    {
      string Line;
      while (getline(MyFile, Line))
      {
        clsContact Contact = _ConvertLineToContactObject(Line);
        if (Contact.GetContactId() == GetContactId())
        {
          Contact = *this; // Update the client with the current object's data
        }
        vContacts.push_back(Contact); // Add the client to the vector
      }
      MyFile.close();
    }

    // Save the updated client data back to the file
    _SaveContactsToFile(vContacts);
  }

public:
  clsContact(enMode Mode, int ContactId, string FirstName, string LastName, string Email, string Phone) : clsPerson(FirstName, LastName, Email, Phone)
  {
    _ContactId = ContactId;
    _Mode = Mode;
  }

  // Property Set
  void SetContactId(int ContactId)
  {
    _ContactId = ContactId;
  }

  // Property Get
  int GetContactId()
  {
    return _ContactId;
  }

  static int GetLatestContactId()
  {
    return _GetLatestContactId();
  }

  static int GetNextContactId()
  {
    return _GetLatestContactId() + 1;
  }

  // Property Set
  void SetMode(enMode Mode)
  {
    _Mode = Mode;
  }

  void SetForDeletion()
  {
    MarkedForDeletion = true;
  }

  // Property Get
  enMode GetMode()
  {
    return _Mode;
  }

  bool IsEmpty()
  {
    return _Mode == EmptyMode;
  }

  bool IsContactExists(string Phone)
  {
    return (SearchContact(enSearchBy::Phone, Phone).IsEmpty() == false);
  }

  void PrintContactCard()
  {
    cout << "\nContact Card:" << endl;
    cout << "___________________" << endl;
    cout << "Contact ID: " << _ContactId << endl;
    cout << "First Name: " << GetFirstName() << endl;
    cout << "Last Name: " << GetLastName() << endl;
    cout << "Email: " << GetEmail() << endl;
    cout << "Phone: " << GetPhoneNumber() << endl;
    cout << "___________________" << endl;
  }

  static vector<clsContact> GetAllContacts()
  {
    return _LoadContactsFromFile();
  }

  static clsContact GetAddNewContactObject()
  {
    return clsContact(AddNewMode, GetNextContactId(), "", "", "", "");
  }

  static clsContact GetDeleteContactObject()
  {
    return clsContact(EmptyMode, 0, "", "", "", "");
  }

  static clsContact GetUpdateContactObject(int ContactId)
  {
    return _GetContactById(ContactId);
  }

  enum enSaveResult
  {
    svFaildEmptyObject = 0,
    svSucceeded = 1,
    svFaildPhoneNumberExists = 2,
  };

  enSaveResult Save()
  {
    switch (_Mode)
    {
    case EmptyMode:
    {
      if (IsEmpty())
      {
        return svFaildEmptyObject;
      }
    }
    case UpdateMode:
    {
      _Update();
      return svSucceeded;
    }
    case AddNewMode:
    {
      if (IsContactExists(GetPhoneNumber()))
      {
        return svFaildPhoneNumberExists;
      }
      else
      {
        _AddNewContactToFile();
        return svSucceeded;
      }
    }
    default:
    {
      return svFaildEmptyObject;
    }
    }
    return svFaildEmptyObject;
  }

  bool Delete()
  {
    vector<clsContact> vContacts = _LoadContactsFromFile();

    for (clsContact &C : vContacts)
    {
      if (C.GetContactId() == this->GetContactId())
      {
        C.MarkedForDeletion = true;
        _SaveContactsToFile(vContacts);
        *this = GetDeleteContactObject();
        return true;
      }
    }
    return false;
  }

  enum enSearchBy
  {
    Id = 1,
    FullName = 2,
    Email = 3,
    Phone = 4,
  };
  static clsContact SearchContact(enSearchBy SearchBy, string SearchString)
  {
    switch (SearchBy)
    {
    case FullName:
      return _GetContactByFullName(SearchString);
      break;
    case Email:
      return _GetContactByEmail(SearchString);
      break;
    case Phone:
      return _GetContactByPhone(SearchString);
      break;
    case Id:
      return _GetContactById(stoi(SearchString));
      break;
    default:
      return GetDeleteContactObject();
      break;
    }
  }
};