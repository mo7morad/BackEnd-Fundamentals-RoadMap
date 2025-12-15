#pragma once
#include <iostream>
#include <iomanip>
#include "clsScreen.h"
#include "../lib/clsInputValidate.h"
#include "settings/ChangeCarScreen.h"
#include "settings/ChangeWheelsScreen.h"
#include "settings/ChooseTrackScreen.h"
#include "settings/StartRacingScreen.h"
using namespace std;

class clsMainScreen : protected clsScreen
{
private:

  enum enMainMenuOptions 
  {
    ChangeCar = 1,
    ChangeWheels = 2,
    ChooseTrack = 3,
    StartRacing = 4,
    Exit = 5
  };

  static short _ReadMainMenuOption()
  {
    cout << setw(37) << left << "" << "Choose what do you want to do? [1 to 5]? ";
    short Choice = clsInputValidate<short>::ReadNumberBetween(1, 5, "Enter Number between 1 to 5? ");
    return Choice;
  }

  static void _GoBackToMainMenu()
  {
    cout << setw(37) << left << "" << "\n\tPress any key to go back to Main Menu...\n";
    cin.ignore();
    cin.get();
    ShowMainMenu();
  }

  static void _ChangeTheCar()
  {
    ChangeCarScreen::ShowChangeCarScreen();
  }

  static void _ChangeTheWheels()
  {
    ChangeWheelsScreen::ShowChangeWheelsScreen();
  }

  static void _ChooseTheTrack()
  {
    ChooseTrackScreen::ShowChooseTrackScreen();
  }

  static void _StartRacing()
  {
    StartRacingScreen::ShowStartRacingScreen();
  }

  static void _PerfromMainMenu(enMainMenuOptions MainMenuOption)
  {
    switch(MainMenuOption)
    {
      case ChangeCar:
        _ChangeTheCar();
        break;
      case ChangeWheels:
        _ChangeTheWheels();
        break;
      case ChooseTrack:
        _ChooseTheTrack();
        break;
      case StartRacing:
        _StartRacing();
        break;
      case Exit:
        cout << setw(37) << left << "" << "Exiting the Simulation...\n";
        cout << setw(37) << left << "" << "Thank you for using the Driving Simulation.\n";
        exit(0);
        break;
    }
    _GoBackToMainMenu();
  }

public:

  static void ShowMainMenu()
  {
    system("clear");
    _DrawScreenHeader("\t  Driving Simulation");
    cout << setw(37) << left << "" << "===========================================\n";
    cout << setw(37) << left << "" << "\t\t\tMain Menu\n";
    cout << setw(37) << left << "" << "===========================================\n";
    cout << setw(37) << left << "" << "\t[1] Change The Car.\n";
    cout << setw(37) << left << "" << "\t[2] Change The Wheels.\n";
    cout << setw(37) << left << "" << "\t[3] Choose The Track.\n";
    cout << setw(37) << left << "" << "\t[4] Start The Racing.\n";
    cout << setw(37) << left << "" << "\t[5] Exit.\n";
    cout << setw(37) << left << "" << "===========================================\n";
    _PerfromMainMenu((enMainMenuOptions)_ReadMainMenuOption());
  }
};
