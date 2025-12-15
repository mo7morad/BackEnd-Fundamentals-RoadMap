#pragma once
#include <iostream>
#include <iomanip>
#include "../clsScreen.h"
#include "../../lib/clsInputValidate.h"
#include "../../core/Car.h"
#include "../../Global.h"
using namespace std;

class StartRacingScreen : protected clsScreen
{
private:
  static void _ShowSimulationData()
  {
    cout << setw(40) << left << "" << "===================================\n";
    cout << setw(40) << left << "" << "\t  Simulation Data\n";
    cout << setw(40) << left << "" << "===================================\n";
    cout << setw(40) << left << "" << CurrentCar.GetCarType() << " Car with " <<  CurrentCar.GetWheelsType() << " Wheels\n";
    cout << setw(40) << left << "" << "Track: " << CurrentTrack << endl;
    cout << setw(40) << left << "" << "Track Length: " << TrackLength << " k.m" << endl;
  }

  static float _ReadSpeed()
  {
    cout << setw(40) << left << "" << "Enter the Speed (in k.m/h): ";
    return clsInputValidate<float>::ReadNumberBetween(10, 1000, "Enter Speed between 1 to 1000? ");
  }

  static void _HourlySimulation(float Speed)
  {
    float Time = TrackLength / Speed;
    cout << setw(40) << left << "" << "Time to complete the track: " << Time << " hours" << endl;
    for(int i = 1; i <= Time; i++)
    {
      cout << "The car has driven " << i * Speed << " k.m in " << i << " hours" << endl;
    }
  }

  static bool IsValidSimulation()
  {
    if(CurrentTrack == "")
    {
      cout << "Please choose the track first\n";
      return false;
    }
    if (TrackLength == 0)
    {
      cout << "Please choose the track length first\n";
      return false;
    }
    return true;
  }

public:
  static void ShowStartRacingScreen()
  {
    system("clear");
    if(IsValidSimulation())
    {
      _DrawScreenHeader("\t\tStart Racing");
      _ShowSimulationData();
      float Speed = _ReadSpeed();
      _HourlySimulation(Speed);
    }
  }
};