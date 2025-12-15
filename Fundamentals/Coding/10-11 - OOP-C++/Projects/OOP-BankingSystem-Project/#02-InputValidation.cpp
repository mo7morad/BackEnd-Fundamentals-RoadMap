#include <iostream>
#include "headers/lib/clsInputValidation.h"

int main()

{
  cout << clsInputValidation::IsNumberBetween(5, 1, 10) << endl;
  cout << clsInputValidation::IsNumberBetween(5.5, 1.3, 10.8) << endl;

  cout << clsInputValidation::IsDateBetween(clsDate(),
                                          clsDate(8, 12, 2022),
                                          clsDate(31, 12, 2022))
                                          << endl;

  cout << clsInputValidation::IsDateBetween(clsDate(),
                                          clsDate(31, 12, 2022),
                                          clsDate(8, 12, 2022))
                                          << endl;

  cout << "\nPlease Enter a Number:\n";
  int x = clsInputValidation::ReadIntNumber("Invalid Number, Enter again:\n");
  cout << "x=" << x;

  cout << "\nPlease Enter a Number between 1 and 5:\n";
  int y = clsInputValidation::ReadIntNumberBetween(1, 5, "Number is not within range, enter again:\n");
  cout << "y=" << y;

  cout << "\nPlease Enter a Double Number:\n";
  double a = clsInputValidation::ReadDoubleNumber("Invalid Number, Enter again:\n");
  cout << "a=" << a;

  cout << "\nPlease Enter a Double Number between 1 and 5:\n";
  double b = clsInputValidation::ReadDoubleNumberBetween(1, 5, "Number is not within range, enter again:\n");
  cout << "b=" << b;

  cout << endl << clsInputValidation::IsValideDate(clsDate(35, 12, 2022)) << endl;
  
  return 0;
}