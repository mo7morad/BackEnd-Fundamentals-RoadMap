#include <iostream>
#include "headers/core/clsPerson.h"
#include "headers/core/clsBankClient.h"
#include "headers/lib/clsInputValidation.h"

void DeleteClient()
{
    string AccountNumber = "";

    cout << "\nPlease Enter Account Number: ";
    AccountNumber = clsInputValidation::ReadString();
    while (!clsBankClient::IsClientExist(AccountNumber))
    {
        cout << "\nAccount number is not found, choose another one: ";
        AccountNumber = clsInputValidation::ReadString();
    }

    clsBankClient Client1 = clsBankClient::Find(AccountNumber);
    Client1.Print();

    cout << "\nAre you sure you want to delete this client y/n? ";
    
    char Answer = 'n';
    cin >> Answer;

    if (tolower(Answer) == 'y')
    {
        if (Client1.Delete())
        {
            cout << "\nClient Deleted Successfully :-)\n";
            Client1.Print();
        }
        else
        {
            cout << "\nError Client Was not Deleted!\n";
        }
    }
}

int main()

{
    DeleteClient();
    return 0;
}