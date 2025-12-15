#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../lib/clsInputValidate.h"
#include "../../core/Car.h"
#include "../../Global.h"
using namespace std;

class ChooseTrackScreen : protected clsScreen
{
private:
  static void _DrawChooseTrackOptions()
  {
    clsScreen::_DrawScreenHeader("\t\tChoose Track");
    cout << setw(40) << left << "" << "===================================\n";
    cout << setw(40) << left << "" << "Please Choose your track: \n";
    cout << setw(40) << left << "" << "===================================\n";
    cout << setw(40) << left << "" << "1. Off-Road Track\n";
    cout << setw(40) << left << "" << "2. Asphalt Track 2\n";
  }

  static void _ReadTrack()
  {
    cout << setw(40) << left << "" << "Enter the Track Number [1 to 2]? ";
    short Choice = clsInputValidate<short>::ReadNumberBetween(1, 2, "Enter Number between 1 to 2? ");
    switch(Choice)
    {
      case 1:
        CurrentTrack = "Off-Road Track";
        break;
      case 2:
        CurrentTrack = "Asphalt Track";
        break;
    }
  }

  static void ReadTrackLength()
  {
    cout << setw(40) << left << "" << "Enter the Track Length (in k.m): ";
    TrackLength = clsInputValidate<float>::ReadNumberBetween(1, 999999, "Enter Track Length between 1 to 999999? ");
  }

public:
  static void ShowChooseTrackScreen()
  {
    system("clear");
    _DrawChooseTrackOptions();
    _ReadTrack();
    ReadTrackLength();
    cout << "\nThe chosen Track: " << CurrentTrack << " with " << TrackLength << " k.m length" << endl;
  }
};