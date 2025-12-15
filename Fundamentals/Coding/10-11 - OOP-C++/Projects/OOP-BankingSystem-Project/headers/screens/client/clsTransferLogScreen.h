#pragma once

#include <iostream>
#include <iomanip>
#include <fstream>
#include "../clsScreen.h"
#include "../../core/clsBankClient.h"

class clsTransferLogScreen : protected clsScreen
{

private:
  static void PrintTransferLogRecordLine(clsBankClient::stTransferLogRecord TransferLogRecord)
  {
    cout << setw(8) << left << "" << "| " << setw(23) << left << TransferLogRecord.DateTime;
    cout << "| " << setw(8) << left << TransferLogRecord.SourceAccountNumber;
    cout << "| " << setw(8) << left << TransferLogRecord.DestinationAccountNumber;
    cout << "| " << setw(8) << left << TransferLogRecord.Amount;
    cout << "| " << setw(12) << left << TransferLogRecord.srcBalanceAfter;
    cout << "| " << setw(12) << left << TransferLogRecord.destBalanceAfter;
    cout << "| " << setw(8) << left << TransferLogRecord.UserName;
  }

public:
  static void ShowTransferLogScreen()
  {
    vector<clsBankClient::stTransferLogRecord> vTransferLogRecord = clsBankClient::GetTransfersLogList();

    string Title = "\tTransfer Log List Screen";
    string SubTitle = "\t    (" + to_string(vTransferLogRecord.size()) + ") Record(s).";

    _DrawScreenHeader(Title, SubTitle);

    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;

    cout << setw(8) << left << "" << "| " << left << setw(23) << "Date/Time";
    cout << "| " << left << setw(8) << "Src.Acc";
    cout << "| " << left << setw(8) << "Dst.Acc";
    cout << "| " << left << setw(8) << "Amount";
    cout << "| " << left << setw(12) << "Src.Balance";
    cout << "| " << left << setw(12) << "Dst.Balance";
    cout << "| " << left << setw(8) << "User";

    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;

    if (vTransferLogRecord.size() == 0)
      cout << "\t\t\t\tNo Transfers Available In the System!";
    else

      for (clsBankClient::stTransferLogRecord Record : vTransferLogRecord)
      {
        PrintTransferLogRecordLine(Record);
        cout << endl;
      }
    cout << setw(8) << left << "" << "\n\t_______________________________________________________";
    cout << "_________________________________________\n" << endl;
  }
};
