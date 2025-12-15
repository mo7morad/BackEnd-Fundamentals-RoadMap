#pragma once
#include <iostream>
#include "../clsScreen.h"
#include "../../lib/clsInputValidation.h"
#include "clsListUsersScreen.h"
#include "clsAddNewUserScreen.h"
#include "clsDeleteUserScreen.h"
#include "clsUpdateUserScreen.h"
#include "clsFindUserScreen.h"
#include <iomanip>

using namespace std;

class clsManageUsersScreen :protected clsScreen
{

private:
    enum enManageUsersMenuOptions {
        ListUsers = 1, AddNewUser = 2, DeleteUser = 3,
        UpdateUser = 4, FindUser = 5, MainMenu = 6
    };

    static short _ReadManageUsersMenuOption()
    {
        cout << setw(37) << left << "" << "Choose what do you want to do? [1 to 6]? ";
        short Choice = clsInputValidation::ReadShortNumberBetween(1, 6, "Enter Number between 1 to 6? ");
        return Choice;
    }

    static void _GoBackToManageUsersMenu()
    {
        cout << "\n\nPress any key to go back to Manage Users Menu...";
        cin.ignore();
        cin.get();
        ShowManageUsersMenu();
    }

    static void _ShowListUsersScreen()
    {
        clsListUsersScreen::ShowUsersList();
    }

    static void _ShowAddNewUserScreen()
    {
        clsAddNewUserScreen::ShowAddNewUserScreen();
    }

    static void _ShowDeleteUserScreen()
    {
        clsDeleteUserScreen::ShowDeleteUserScreen();
    }

    static void _ShowUpdateUserScreen()
    {
        clsUpdateUserScreen::ShowUpdateUserScreen();
    }

    static void _ShowFindUserScreen()
    {
        clsFindUserScreen::ShowFindUserScreen();
    }


    static void _PerformManageUsersMenuOption(enManageUsersMenuOptions ManageUsersMenuOption)
    {
        switch (ManageUsersMenuOption)
        {
        case ListUsers:
        {
            system("clear");
            _ShowListUsersScreen();
            _GoBackToManageUsersMenu();
            break;
        }

        case AddNewUser:
        {
            system("clear");
            _ShowAddNewUserScreen();
            _GoBackToManageUsersMenu();
            break;
        }

        case DeleteUser:
        {
            system("clear");
            _ShowDeleteUserScreen();
            _GoBackToManageUsersMenu();
            break;
        }

        case UpdateUser:
        {
            system("clear");
            _ShowUpdateUserScreen();
            _GoBackToManageUsersMenu();
            break;
        }

        case FindUser:
        {
            system("clear");
            _ShowFindUserScreen();
            _GoBackToManageUsersMenu();
            break;
        }

        case MainMenu:
        {
            //do nothing here the main screen will handle it :-) ;
        }
        }
    }



public:


    static void ShowManageUsersMenu()
    {
        if (!CheckAccessRights(clsUser::enPermissions::ManageUsers))
            return;
            
        _DrawScreenHeader("\t Manage Users Screen");
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t\t  Manage Users Menu\n";
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t[1] List Users.\n";
        cout << setw(37) << left << "" << "\t[2] Add New User.\n";
        cout << setw(37) << left << "" << "\t[3] Delete User.\n";
        cout << setw(37) << left << "" << "\t[4] Update User.\n";
        cout << setw(37) << left << "" << "\t[5] Find User.\n";
        cout << setw(37) << left << "" << "\t[6] Main Menu.\n";
        cout << setw(37) << left << "" << "===========================================\n";
        _PerformManageUsersMenuOption((enManageUsersMenuOptions)_ReadManageUsersMenuOption());
    }
};

