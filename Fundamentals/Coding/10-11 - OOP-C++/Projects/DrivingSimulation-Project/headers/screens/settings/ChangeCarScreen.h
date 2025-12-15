#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../lib/clsInputValidate.h"
#include "../../core/Car.h"
#include "../../Global.h"
using namespace std;

class ChangeCarScreen : protected clsScreen
{
private:
  static void _DrawChangeCarOptions()
  {
    clsScreen::_DrawScreenHeader("\t\tChange Car");
    cout << setw(40) << left << "" << "Note: The Default Car is Racing Car\n";
    cout << setw(40) << left << "" << "===================================\n";
    cout << setw(40) << left << "" << "Please Choose your car: \n";
    cout << setw(40) << left << "" << "===================================\n";
    cout << setw(40) << left << "" << "1. Racing Car\n";
    cout << setw(40) << left << "" << "2. Off-Road Car\n";
    cout << setw(40) << left << "" << "3. Family Car\n";
  }

  static Car::enCarType _ReadCarType()
  {
    cout << setw(40) << left << "" << "Enter the Car Type [1 to 3]? ";
    short Choice = clsInputValidate<short>::ReadNumberBetween(1, 3, "Enter Number between 1 to 3? ");
    return static_cast<Car::enCarType>(Choice);
  }

  static void _ChangeCar()
  {
    Car::enCarType CarType = _ReadCarType();
    CurrentCar.SetCarType(CarType);
    cout << "\nCar Type has been changed to " << CurrentCar.GetCarType() << " Car" << endl;
  }

public:
  static void ShowChangeCarScreen()
  {
    system("clear");
    _DrawChangeCarOptions();
    _ChangeCar();
  }
};