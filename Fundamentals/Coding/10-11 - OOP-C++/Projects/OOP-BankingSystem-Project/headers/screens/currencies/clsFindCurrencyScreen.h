#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../core/clsCurrency.h"
#include "../../lib/clsInputValidation.h"

class clsFindCurrencyScreen : protected clsScreen
{
private:
  static void _PrintCurrency(clsCurrency Currency)
  {
    cout << "\nCurrency Card:\n";
    cout << "_____________________________\n";
    cout << "\nCountry    : " << Currency.Country();
    cout << "\nCode       : " << Currency.CurrencyCode();
    cout << "\nName       : " << Currency.CurrencyName();
    cout << "\nRate(1$) = : " << Currency.Rate();
    cout << "\n_____________________________\n";
  }

  static bool _ShowResults(clsCurrency Currency)
  {
    if (!Currency.IsEmpty())
    {
      cout << "\nCurrency Found :-)\n";
      _PrintCurrency(Currency);
      return true;
    }
    else
    {
      cout << "\nCurrency Was not Found :-(\n";
      cout << "Please enter correct Currency Code or Country Name\n";
      return false;
    }
  }

  static clsCurrency _FindCurrencyByCode()
  {
    string CurrencyCode;
    cout << "\nPlease Enter Currency Code: ";
    CurrencyCode = clsInputValidation::ReadString();
    clsCurrency Currency = clsCurrency::FindByCode(CurrencyCode);
    return Currency;
  }

  static clsCurrency _FindCurrencyByCountry()
  {
    string Country;
    cout << "\nPlease Enter Country Name: ";
    Country = clsInputValidation::ReadString();
    clsCurrency Currency = clsCurrency::FindByCountry(Country);
    return Currency;
  }

public:
  static void ShowFindCurrencyScreen()
  {
    _DrawScreenHeader("\t  Find Currency Screen");

    cout << setw(37) << left << "" << "===========================================\n";
    cout << setw(37) << left << "" << "\t\tFind Currency By\n";
    cout << setw(37) << left << "" << "===========================================\n";
    cout << setw(37) << left << "" << "[1] Currency Code\n";
    cout << setw(37) << left << "" << "[2] Country Name\n";
    cout << setw(37) << left << "" << "[3] Return to Currency Exchange Menu\n";
    cout << setw(37) << left << "" << "===========================================\n";
    
    cout << "\nPlease Enter Your Choice: ";
    short Choice = clsInputValidation::ReadShortNumberBetween(1, 3, "Enter Number between 1 to 3? ");

    switch (Choice)
    {
    case 1:
      while(!_ShowResults(_FindCurrencyByCode()));
      break;
    case 2:
      while(!_ShowResults(_FindCurrencyByCountry()));
      break;
    case 3:
      break;
    }
  }
};
