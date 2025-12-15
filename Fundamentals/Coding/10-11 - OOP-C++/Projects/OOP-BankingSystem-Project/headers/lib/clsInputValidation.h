#pragma once
#include <iostream>
#include <string>
#include <limits>
#include "clsString.h"
#include "clsDate.h"

class clsInputValidation
{

public:

  static string ReadString()
  {
    string S1 = "";
    // Usage of std::ws will extract allthe whitespace character
    getline(cin >> ws, S1);
    return S1;
  }

  static bool IsNumberBetween(int Number, int From, int To)
  {
    return(Number >= From && Number <= To);
  }

  static bool IsDateBetween(clsDate Date, clsDate From, clsDate To)
  {
    // Date>=From && Date<=To
    if ((clsDate::IsDate1AfterDate2(Date, From) || clsDate::IsDate1EqualDate2(Date, From)) &&
        (clsDate::IsDate1BeforeDate2(Date, To) || clsDate::IsDate1EqualDate2(Date, To)))
    {
      return true;
    }

    // Date>=To && Date<=From
    if ((clsDate::IsDate1AfterDate2(Date, To) || clsDate::IsDate1EqualDate2(Date, To)) &&
        (clsDate::IsDate1BeforeDate2(Date, From) || clsDate::IsDate1EqualDate2(Date, From)))
    {
      return true;
    }

    return false;
  }

  static short ReadShortNumber(string ErrorMessage = "Invalid Number, Enter again\n")
  {
    short Number;
    while (!(cin >> Number))
    {
      cin.clear();
      cin.ignore(numeric_limits<streamsize>::max(), '\n');
      cout << ErrorMessage;
    }
    return Number;
  }

  static short ReadShortNumberBetween(short From, short To, string ErrorMessage = "Number is not within range, Enter again:\n")
  {
    int Number = ReadShortNumber();
    while (!IsNumberBetween(Number, From, To))
    {
      cout << ErrorMessage;
      Number = ReadShortNumber();
    }
    return Number;
  }

  static int ReadIntNumber(string ErrorMessage = "Invalid Number, Enter again\n")
  {
    int Number;
    while (!(cin >> Number))
    {
      cin.clear();
      cin.ignore(numeric_limits<streamsize>::max(), '\n');
      cout << ErrorMessage;
    }
    return Number;
  }

  static int ReadIntNumberBetween(int From, int To, string ErrorMessage = "Number is not within range, Enter again:\n")
  {
    int Number = ReadIntNumber();

    while (!IsNumberBetween(Number, From, To))
    {
      cout << ErrorMessage;
      Number = ReadIntNumber();
    }
    return Number;
  }

  static float ReadFloatNumber(string ErrorMessage = "Invalid Number, Enter again\n")
  {
    float Number;
    while (!(cin >> Number))
    {
      cin.clear();
      cin.ignore(numeric_limits<streamsize>::max(), '\n');
      cout << ErrorMessage;
    }
    return Number;
  }

  static float ReadFloatNumberBetween(float From, float To, string ErrorMessage = "Number is not within range, Enter again:\n")
  {
    float Number = ReadFloatNumber();

    while (!IsNumberBetween(Number, From, To))
    {
      cout << ErrorMessage;
      Number = ReadFloatNumber();
    }
    return Number;
  }

  static double ReadDoubleNumber(string ErrorMessage = "Invalid Number, Enter again\n")
  {
    double Number;
    while (!(cin >> Number))
    {
      cin.clear();
      cin.ignore(numeric_limits<streamsize>::max(), '\n');
      cout << ErrorMessage;
    }
    return Number;
  }

  static double ReadDoubleNumberBetween(double From, double To, string ErrorMessage = "Number is not within range, Enter again:\n")
  {
    double Number = ReadDoubleNumber();

    while (!IsNumberBetween(Number, From, To))
    {
      cout << ErrorMessage;
      Number = ReadDoubleNumber();
    }
    return Number;
  }

  static bool IsValideDate(clsDate Date)
  {
    return clsDate::IsValidDate(Date);
  }
};
