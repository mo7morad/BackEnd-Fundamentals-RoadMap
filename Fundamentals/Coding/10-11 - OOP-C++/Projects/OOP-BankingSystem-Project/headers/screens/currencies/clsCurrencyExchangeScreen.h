#pragma once
#include <iostream>
#include <string>
#include "../clsScreen.h"
#include "../../lib/clsString.h"
#include "clsCurenciesListScreen.h"
#include "clsFindCurrencyScreen.h"
#include "clsUpdateCurrencyRate.h"
#include "clsCurrencyCalculator.h"
#include <vector>
#include <fstream>
using namespace std;

class clsCurrencyExchangeScreen : protected clsScreen
{
private:
    enum enCurrencyExchangeOptions
    {
        ListCurrencies = 1, FindCurrency = 2, UpdateRate = 3, CurrencyCalculator = 4, ReturnToMainMenu = 5
    };

    static short _ReadCurrencyExchangeOption()
    {
        cout << setw(37) << left << "" << "Choose what do you want to do? [1 to 5]? ";
        short Choice = clsInputValidation::ReadShortNumberBetween(1, 5, "Enter Number between 1 to 5? ");
        return Choice;
    }

    static void _GoBackToCurrencyExchangeMenu()
    {
        cout << setw(37) << left << "" << "\n\tPress any key to go back to Currency Exchange Menu...\n";
        cin.ignore();
        cin.get();
        ShowCurrencyExchangeScreen();
    }

    static void _ShowAllCurrenciesScreen()
    {
        clsCurrenciesListScreen::ShowCurrenciesListScreen();
    }

    static void _ShowFindCurrencyScreen()
    {
        clsFindCurrencyScreen::ShowFindCurrencyScreen();
    }

    static void _ShowUpdateRateScreen()
    {
        clsUpdateCurrencyRate::ShowUpdateCurrencyRateScreen();
    }

    static void _ShowCurrencyCalculatorScreen()
    {
        clsCurrencyCalculator::ShowCurrencyCalculatorScreen();
    }

    static void _PerformCurrencyExchangeOption(enCurrencyExchangeOptions Option)
    {
        switch (Option)
        {
        case ListCurrencies:
            system("clear");
            _ShowAllCurrenciesScreen();
            _GoBackToCurrencyExchangeMenu();
            break;
        case FindCurrency:
            system("clear");
            _ShowFindCurrencyScreen();
            _GoBackToCurrencyExchangeMenu();
            break;
        case UpdateRate:
            system("clear");
            _ShowUpdateRateScreen();
            _GoBackToCurrencyExchangeMenu();
            break;
        case CurrencyCalculator:
            system("clear");
            _ShowCurrencyCalculatorScreen();
            _GoBackToCurrencyExchangeMenu();
            break;
        case ReturnToMainMenu:
            // do nothing here the main screen will handle it :-) ;
            break;
        }
    }

public:
    static void ShowCurrencyExchangeScreen()
    {
        system("clear");
        _DrawScreenHeader("\tCurrency Exchange Screen");
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "\t\tCurrency Exchange Menu\n";
        cout << setw(37) << left << "" << "===========================================\n";
        cout << setw(37) << left << "" << "[1] List Currencies\n";
        cout << setw(37) << left << "" << "[2] Find Currency\n";
        cout << setw(37) << left << "" << "[3] Update Rate\n";
        cout << setw(37) << left << "" << "[4] Currency Calculator\n";
        cout << setw(37) << left << "" << "[5] Main Menu\n";
        cout << setw(37) << left << "" << "===========================================\n";

        _PerformCurrencyExchangeOption(enCurrencyExchangeOptions(_ReadCurrencyExchangeOption()));
    }
};