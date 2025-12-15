#pragma once
#include <iostream>
using namespace std;

class Car
{
private: 
  string CarType = "Racing";
  string WheelsType = "Racing Wheels";

public:
  enum enCarType {Racing = 1, OffRoad = 2, Family = 3};
  enum enWheelsType {RacingWheels = 1, OffRoadWheels = 2, NormalWheels = 3};

  void SetCarType(enCarType type)
  {
    switch(type)
    {
      case Racing:
        CarType = "Racing";
        WheelsType = "Racing Wheels";
        break;
      case OffRoad:
        CarType = "Off-Road";
        WheelsType = "Off-Road Wheels";
        break;
      case Family:
        CarType = "Family";
        WheelsType = "Normal Wheels";
        break;
    }
  }

  virtual const char *GetCarType()
  {
    return CarType.c_str();
  }

  virtual const char *GetWheelsType()
  {
    return WheelsType.c_str();
  }

  void SetWheelsType(enWheelsType type)
  {
    switch(type)
    {
      case RacingWheels:
        WheelsType = "Racing Wheels";
        break;
      case OffRoadWheels:
        WheelsType = "Off-Road Wheels";
        break;
      case NormalWheels:
        WheelsType = "Normal Wheels";
        break;
    }
  }


  void RotateWheels()
  {
    cout << GetWheelsType() << "is Rotating" << endl;
  }

  void StartEngine()
  {
    cout << "Engine Started!" << endl;
    cout << GetCarType() << " Car with "; RotateWheels();
  }

  void StopEngine()
  {
    cout << "Engine Stopped!" << endl;
    cout << GetCarType() << " Car with " << GetWheelsType() << " Stopped Rotating!" << endl;
  }
};