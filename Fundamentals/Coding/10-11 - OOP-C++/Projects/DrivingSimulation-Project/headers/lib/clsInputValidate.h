// Input validation class using Template class

#pragma once
#include <iostream>
#include <string>
#include <limits>
#include "clsString.h"
#include "clsDate.h"

template <class T>
class clsInputValidate
{
public:
  static string ReadString()
  {
    std::string S1 = "";
    // Clear leading whitespace before reading
    getline(std::cin >> std::ws, S1);
    return S1;
  }

  static bool IsNumberBetween(const T &Number, const T &From, const T &To)
  {
    return (Number >= From && Number <= To);
  }

  static T ReadNumber(const std::string &ErrorMessage = "Invalid Number, Enter again\n")
  {
    T Number;
    while (!(std::cin >> Number))
    {
      std::cin.clear();
      std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
      std::cout << ErrorMessage;
    }
    return Number;
  }

  static T ReadNumberBetween(const T &From, const T &To, const std::string &ErrorMessage = "Number is not within range, Enter again:\n")
  {
    T Number = ReadNumber();
    while (!IsNumberBetween(Number, From, To))
    {
      std::cout << ErrorMessage;
      Number = ReadNumber();
    }
    return Number;
  }

  static bool IsDateBetween(const clsDate &Date, const clsDate &From, const clsDate &To)
  {
    // Check if Date is within range [From, To] or [To, From]
    if ((clsDate::IsDate1AfterDate2(Date, From) || clsDate::IsDate1EqualDate2(Date, From)) &&
        (clsDate::IsDate1BeforeDate2(Date, To) || clsDate::IsDate1EqualDate2(Date, To)))
    {
      return true;
    }

    if ((clsDate::IsDate1AfterDate2(Date, To) || clsDate::IsDate1EqualDate2(Date, To)) &&
        (clsDate::IsDate1BeforeDate2(Date, From) || clsDate::IsDate1EqualDate2(Date, From)))
    {
      return true;
    }

    return false;
  }

  static bool IsValideDate(const clsDate &Date)
  {
    return clsDate::IsValidDate(Date);
  }
};
