#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../clsMainScreen.h"
#include "../../core/clsUser.h"
#include "../../Global.h"

class clsLoginScreen :protected clsScreen
{

private :

    static bool _Login()
    {
        bool LoginFaild = false;
        short LoginAttempts = 3;
        string Username, Password;
        do
        {
            if (LoginFaild)
            {
                LoginAttempts--;
                cout << "\nInvlaid Username/Password!\n\n";
                cout << "You have " << LoginAttempts << " attempts left.\n\n";
                if (LoginAttempts == 0)
                {
                    cout << "You have exceeded the number of login attempts.\n";
                    return false;
                }
            }

            cout << "Enter Username? ";
            cin >> Username;

            cout << "Enter Password? ";
            cin >> Password;

            CurrentUser = clsUser::Find(Username, Password);
            LoginFaild = CurrentUser.IsEmpty();
            
        } while (LoginFaild);
        
        CurrentUser.RegisterLogIn();
        clsMainScreen::ShowMainMenu();
        return true;
    }

public:


    static bool ShowLoginScreen()
    {
        system("clear");
        _DrawScreenHeader("\t  Login Screen");
        return _Login();
    }
};

