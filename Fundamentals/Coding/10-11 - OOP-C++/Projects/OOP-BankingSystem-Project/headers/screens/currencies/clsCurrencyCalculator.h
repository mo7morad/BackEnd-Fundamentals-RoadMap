#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../lib/clsInputValidation.h"
#include "../../core/clsCurrency.h"
using namespace std;


class clsCurrencyCalculator : protected clsScreen
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

    static clsCurrency _FindCurrencyByCode()
    {
      string CurrencyCode;
      cout << "\nPlease Enter Currency Code: ";
      CurrencyCode = clsInputValidation::ReadString();
      clsCurrency Currency = clsCurrency::FindByCode(CurrencyCode);
      return Currency;
    }

    static clsCurrency _GetFirstCurrency()
    {
      cout << "First Currency:"; 
      clsCurrency Currency1 = _FindCurrencyByCode();
      while (Currency1.IsEmpty())
      {
        cout << "Currency Was not Found :-(\n";
        cout << "Please enter correct Currency Code\n";
        Currency1 = _FindCurrencyByCode();
      }
      return Currency1;
    }

    static clsCurrency _GetSecondCurrency()
    {
      cout << "Second Currency:";
      clsCurrency Currency2 = _FindCurrencyByCode();
      while (Currency2.IsEmpty())
      {
        cout << "Currency Was not Found :-(\n";
        cout << "Please enter correct Currency Code\n";
        Currency2 = _FindCurrencyByCode();
      }
      return Currency2;
    }

    static void _CurrencyConvertResult (clsCurrency Currency1, clsCurrency Currency2)
    {
      cout << "\nPlease Enter Amount of " << Currency1.CurrencyCode() << " to convert to " << Currency2.CurrencyCode() << ": ";
      float Amount = clsInputValidation::ReadFloatNumber();
      
      if(Currency2.CurrencyCode() == "USD")
      {
        float Result = Currency1.ConvertToUsd(Amount);
        cout << fixed << setprecision(2) << Amount << " " << Currency1.CurrencyCode() << " = " << Result << " " << Currency2.CurrencyCode() << endl;
        return;
      }

      else
      {
        float AmountInUsd = Currency1.ConvertToUsd(Amount);
        float Result = Currency2.ConvertFromUsd(AmountInUsd);
        cout << fixed << setprecision(2) << Amount << " " << Currency1.CurrencyCode() << " = " << Result << " " << Currency2.CurrencyCode() << endl;
        return;
      }
    }

public:
    static void ShowCurrencyCalculatorScreen()
    {
      char Continue = 'Y';
      do
      {
        system("clear");
        _DrawScreenHeader("\t  Currency Calculator Screen");

        clsCurrency Currency1 = _GetFirstCurrency();
        cout << endl;
        clsCurrency Currency2 = _GetSecondCurrency();

        _PrintCurrency(Currency1);
        _CurrencyConvertResult(Currency1, Currency2);

        cout << "\nDo you want to convert another currency? (Y/N): ";
        cin >> Continue;
      }while((toupper(Continue) == 'Y'));
    }
};