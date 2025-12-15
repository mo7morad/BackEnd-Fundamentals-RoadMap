#pragma once
#include <iostream>
#include <iomanip>
#include "clsScreen.h"
#include "../lib/clsInputValidate.h"
#include "contacts/clsContactsListScreen.h"
#include "contacts/clsAddNewContactScreen.h"
#include "contacts/clsDeleteContactScreen.h"
#include "contacts/clsFindContactScreen.h"
#include "contacts/clsUpdateContactScreen.h"
using namespace std;

class clsMainScreen : protected clsScreen
{
private:

  enum enMainMenuOptions 
  {
    ListContacts = 1,
    AddNewContact = 2,
    DeleteContact = 3,
    EditContact = 4,
    FindContact = 5,
    Exit = 6
  };

  static short _ReadMainMenuOption()
  {
    cout << setw(37) << left << "" << "Choose what do you want to do? [1 to 6]? ";
    short Choice = clsInputValidate<short>::ReadNumberBetween(1, 6, "Enter Number between 1 to 6? ");
    return Choice;
  }

  static void _GoBackToMainMenu()
  {
    cout << setw(37) << left << "" << "\n\tPress any key to go back to Main Menu...\n";
    cin.ignore();
    cin.get();
    ShowMainMenu();
  }

  static void _ShowAllContactsScreen()
  {
    clsContactsListScreen::ShowContactsList();
  }

  static void _ShowAddNewContactScreen()
  {
    clsAddNewContactScreen::ShowAddNewContactScreen();
  }

  static void _ShowDeleteClientScreen()
  {
    clsDeleteContactScreen::ShowDeleteContactScreen();
  }

  static void _ShowUpdateClientScreen()
  {
    clsUpdateContactScreen::ShowUpdateContactScreen();
  }

  static void _ShowFindClientScreen()
  {
    clsFindContactScreen::ShowFindContactScreen();
  }

  static void _PerfromMainMenu(enMainMenuOptions MainMenuOption)
  {
    switch (MainMenuOption)
    {
    case ListContacts:
    {
      _ShowAllContactsScreen();
      _GoBackToMainMenu();
      break;
    }
    case AddNewContact:
    {
      _ShowAddNewContactScreen();
      _GoBackToMainMenu();
      break;
    }
    case DeleteContact:
    {
      _ShowDeleteClientScreen();
      _GoBackToMainMenu();
      break;
    }
    case EditContact:
      _ShowUpdateClientScreen();
      break;
    case FindContact:
      _ShowFindClientScreen();
      break;
    case Exit:
      exit(0);
      break;
    default:
      break;
    }
    _GoBackToMainMenu();
  }

public:

  static void ShowMainMenu()
  {
    system("clear");
    _DrawScreenHeader("\t\tMain Screen");
    cout << setw(37) << left << "" << "===========================================\n";
    cout << setw(37) << left << "" << "\t\t\tMain Menu\n";
    cout << setw(37) << left << "" << "===========================================\n";
    cout << setw(37) << left << "" << "\t[1] Show Contacts List.\n";
    cout << setw(37) << left << "" << "\t[2] Add New Contact.\n";
    cout << setw(37) << left << "" << "\t[3] Delete Contact.\n";
    cout << setw(37) << left << "" << "\t[4] Update Contact Info.\n";
    cout << setw(37) << left << "" << "\t[5] Find Contact.\n";
    cout << setw(37) << left << "" << "\t[6] Exit.\n";
    cout << setw(37) << left << "" << "===========================================\n";
    _PerfromMainMenu((enMainMenuOptions)_ReadMainMenuOption());
  }
};
