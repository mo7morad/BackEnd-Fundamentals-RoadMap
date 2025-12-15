#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../core/clsCurrency.h"
#include "../../lib/clsInputValidation.h"
using namespace std;

class clsUpdateCurrencyRate : protected clsScreen
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

public:
    static void ShowUpdateCurrencyRateScreen()
    {
      // Check if the user has the right to update currency rate. if not, return.
      if (!CheckAccessRights(clsUser::enPermissions::ShowUpdateCurrencyRate))
        return;

      _DrawScreenHeader("\t  Update Currency Rate Screen");

      clsCurrency Currency = _FindCurrencyByCode();
      bool IsFound = _ShowResults(Currency);
      while(!IsFound)
      {
        Currency = _FindCurrencyByCode();
        IsFound = _ShowResults(Currency);
      }

      cout  << "\nAre you sure you want to update the rate? (Y/N): ";
      char Choice;
      cin >> Choice;

      if (toupper(Choice) == 'Y')
      {
        cout << "\n\nUpdate Currency Rate:";
        cout << "\n_____________________\n";
        cout << "\nEnter New Rate: ";
        float NewRate = clsInputValidation::ReadFloatNumber();
        if(NewRate == Currency.Rate())
        {
          cout << "\nNew Rate is same as old rate, Currency Rate is not updated!\n";
          return;
        }
        Currency.UpdateRate(NewRate);
        cout << "\nCurrency Rate updated successfully!\n";
        _PrintCurrency(Currency);
      }
      else
      {
        cout << "\nCurrency Rate is not updated!\n";
      }
    }
};