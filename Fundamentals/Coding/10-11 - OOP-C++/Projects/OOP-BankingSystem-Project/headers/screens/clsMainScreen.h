#pragma once
#include <iostream>
#include "clsScreen.h"
#include "../lib/clsInputValidation.h"
#include "client/clsClientsListScreen.h"
#include "client/clsAddNewClientScreen.h"
#include "client/clsDeleteClientScreen.h"
#include "client/clsUpdateClientScreen.h"
#include "client/clsFindClientScreen.h"
#include "client/clsTransactionsScreen.h"
#include "user/clsManageUsersScreen.h"
#include "user/clsLoginLogsScreen.h"
#include "currencies/clsCurrencyExchangeScreen.h"
#include "../Global.h"
#include <iomanip>
using namespace std;

class clsMainScreen : protected clsScreen
{
private:

  enum enMainMenuOptions 
  {
      ListClients = 1, AddNewClient = 2, DeleteClient = 3,
      UpdateClient = 4, FindClient = 5, ShowTransactionsMenu = 6,
      ManageUsers = 7, LoginLogs = 8 , CurrencyExchange = 9, Exit = 10
  };

  static short _ReadMainMenuOption()
  {
    cout << setw(37) << left << "" << "Choose what do you want to do? [1 to 10]? ";
    short Choice = clsInputValidation::ReadShortNumberBetween(1, 10, "Enter Number between 1 to 10? ");
    return Choice;
  }

  static void _GoBackToMainMenu()
  {
    cout << setw(37) << left << "" << "\n\tPress any key to go back to Main Menu...\n";
    cin.ignore();
    cin.get();
    ShowMainMenu();
  }

  static void _ShowAllClientsScreen()
  {
    clsClientsListScreen::ShowClientsList();
  }

  static void _ShowAddNewClientsScreen()
  {
    clsAddNewClient::ShowAddNewClientScreen();
  }

  static void _ShowDeleteClientScreen()
  {
    clsDeleteClientScreen::ShowDeleteClientScreen();
  }

  static void _ShowUpdateClientScreen()
  {
    clsUpdateClientScreen::ShowUpdateClientScreen();
  }

  static void _ShowFindClientScreen()
  {
    clsFindClientScreen::ShowFindClientScreen();
  }

  static void _ShowTransactionsMenu()
  {
    clsTransactionsScreen::ShowTransactionsMenu();
  }

  static void _ShowManageUsersMenu()
  {
    clsManageUsersScreen::ShowManageUsersMenu();
  }

  static void _ShowLoginLogs()
  {
    clsLoginLogsScreen::ShowLoginLogsScreen();
  }

  static void _ShowCurrencyExchange()
  {
    clsCurrencyExchangeScreen::ShowCurrencyExchangeScreen();
  }

  static void _Logout()
  {
    CurrentUser = clsUser::Find("", "");
    // then it'll go to main function.
  }



  static void _PerfromMainMenu(enMainMenuOptions MainMenuOption)
  {
    switch (MainMenuOption)
    {
    case ListClients:
    {
      system("clear");
      _ShowAllClientsScreen();
      _GoBackToMainMenu();
      break;
    }
    case AddNewClient:
      system("clear");
      _ShowAddNewClientsScreen();
      _GoBackToMainMenu();
      break;

    case DeleteClient:
      system("clear");
      _ShowDeleteClientScreen();
      _GoBackToMainMenu();
      break;

    case UpdateClient:
      system("clear");
      _ShowUpdateClientScreen();
      _GoBackToMainMenu();
      break;

    case FindClient:
      system("clear");
      _ShowFindClientScreen();
      _GoBackToMainMenu();
      break;

    case ShowTransactionsMenu:
      system("clear");
      _ShowTransactionsMenu();
      _GoBackToMainMenu();
      break;

    case ManageUsers:
      system("clear");
      _ShowManageUsersMenu();
      _GoBackToMainMenu();
      break;

    case LoginLogs:
      system("clear");
      _ShowLoginLogs();
      _GoBackToMainMenu();
      break;

    case CurrencyExchange:
      system("clear");
      _ShowCurrencyExchange();
      _GoBackToMainMenu();
      break;

    case Exit:
      system("clear");
      _Logout();
      break;
    }
  }

public:

  static void ShowMainMenu()
  {
    system("clear");
    _DrawScreenHeader("\t\tMain Screen");

    cout << setw(37) << left << "" << "===========================================\n";
    cout << setw(37) << left << "" << "\t\t\tMain Menu\n";
    cout << setw(37) << left << "" << "===========================================\n";
    cout << setw(37) << left << "" << "\t[1] Show Client List.\n";
    cout << setw(37) << left << "" << "\t[2] Add New Client.\n";
    cout << setw(37) << left << "" << "\t[3] Delete Client.\n";
    cout << setw(37) << left << "" << "\t[4] Update Client Info.\n";
    cout << setw(37) << left << "" << "\t[5] Find Client.\n";
    cout << setw(37) << left << "" << "\t[6] Transactions.\n";
    cout << setw(37) << left << "" << "\t[7] Manage Users.\n";
    cout << setw(37) << left << "" << "\t[8] Show Login Logs.\n";
    cout << setw(37) << left << "" << "\t[9] Currency Exchange.\n";
    cout << setw(37) << left << "" << "\t[10] Logout.\n";
    cout << setw(37) << left << "" << "===========================================\n";
    _PerfromMainMenu((enMainMenuOptions)_ReadMainMenuOption());
  }
};
