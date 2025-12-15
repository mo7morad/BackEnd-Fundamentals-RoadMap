#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../lib/clsInputValidate.h"
#include "../../core/Car.h"
#include "../../Global.h"
using namespace std;

class ChangeWheelsScreen : protected clsScreen
{
private:
  static void _DrawChangeWheelsOptions()
  {
    clsScreen::_DrawScreenHeader("\t\tChange Wheels");
    cout << setw(40) << left << "" << "===================================\n";
    cout << setw(40) << left << "" << "Please Choose your wheels: \n";
    cout << setw(40) << left << "" << "===================================\n";
    cout << setw(40) << left << "" << "1. Racing Wheels\n";
    cout << setw(40) << left << "" << "2. Off-Road Wheels\n";
    cout << setw(40) << left << "" << "3. Family Wheels\n";
  }

  static Car::enWheelsType _ReadWheelsType()
  {
    cout << setw(40) << left << "" << "Enter the Wheels Type [1 to 3]? ";
    short Choice = clsInputValidate<short>::ReadNumberBetween(1, 3, "Enter Number between 1 to 3? ");
    return static_cast<Car::enWheelsType>(Choice);
  }

  static void _ChangeWheels()
  {
    Car::enWheelsType WheelsType = _ReadWheelsType();
    CurrentCar.SetWheelsType(WheelsType);
    cout << "\nWheels Type has been changed to " << CurrentCar.GetWheelsType() << " Wheels" << endl;
  }

public:
  static void ShowChangeWheelsScreen()
  {
    system("clear");
    _DrawChangeWheelsOptions();
    _ChangeWheels();
  }
};