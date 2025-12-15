#pragma once

#include <iostream>
#include <iomanip>
#include <fstream>
#include "../clsScreen.h"
#include "../../core/clsUser.h"

class clsLoginLogsScreen : protected clsScreen
{

private:
  static void _PrintLoginRegisterRecordLine(clsUser::stLogRecord LoginRecord)
  {
    cout << setw(8) << left << "" << "| " << setw(35) << left << LoginRecord.DateTime;
    cout << "| " << setw(20) << left << LoginRecord.UserName;
    cout << "| " << setw(20) << left << LoginRecord.Password;
    cout << "| " << setw(10) << left << LoginRecord.Permissions;
  }

public:
  static void ShowLoginLogsScreen()
  {
    if (!CheckAccessRights(clsUser::enPermissions::ShowLoginLogs))
      return;

    vector<clsUser::stLogRecord> vLogsRecords = clsUser::GetLoginLogsList();

    string Title = "\tLogin Register List Screen";
    string SubTitle = "\t\t(" + to_string(vLogsRecords.size()) + ") Record(s).";

    _DrawScreenHeader(Title, SubTitle);

    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;

    cout << setw(8) << left << "" << "| " << left << setw(35) << "Date/Time";
    cout << "| " << left << setw(20) << "UserName";
    cout << "| " << left << setw(20) << "Password";
    cout << "| " << left << setw(10) << "Permissions";
    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;

    if (vLogsRecords.size() == 0)
      cout << "\t\t\t\tNo Logins Available In the System!";
    else
      for (clsUser::stLogRecord Record : vLogsRecords)
      {
        _PrintLoginRegisterRecordLine(Record);
        cout << endl;
      }

    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;
  }
};
