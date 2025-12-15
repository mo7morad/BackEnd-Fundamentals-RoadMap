#include <iostream>
#include "headers/core/clsBankClient.h"
#include "headers/lib/clsInputValidation.h"

using namespace std;

// Function to read client information from user input
void ReadClientInfo(clsBankClient &Client)
{
    cout << "\nEnter First Name: ";
    Client.SetFirstName(clsInputValidation::ReadString());

    cout << "\nEnter Last Name: ";
    Client.SetLastName(clsInputValidation::ReadString());

    cout << "\nEnter Email: ";
    Client.SetEmail(clsInputValidation::ReadString());

    cout << "\nEnter Phone: ";
    Client.SetPhone(clsInputValidation::ReadString());

    cout << "\nEnter Pin Code: ";
    Client.SetPinCode(clsInputValidation::ReadString());

    cout << "\nEnter Account Balance: ";
    Client.SetAccountBalance(clsInputValidation::ReadDoubleNumber()); // Use ReadDoubleNumber for balance
}

// Function to update client information
void UpdateClient()
{
    string AccountNumber;

    cout << "\nPlease Enter Client Account Number: ";
    AccountNumber = clsInputValidation::ReadString();

    // Check if the client exists
    while (!clsBankClient::IsClientExist(AccountNumber))
    {
        cout << "\nAccount number is not found, please choose another one: ";
        AccountNumber = clsInputValidation::ReadString();
    }

    // Find the client and print their information
    clsBankClient Client1 = clsBankClient::Find(AccountNumber);
    Client1.Print();

    cout << "\n\nUpdate Client Info:";
    cout << "\n____________________\n";

    // Read new client information
    ReadClientInfo(Client1);

    // Save the updated client information
    clsBankClient::enSaveResults SaveResult = Client1.Save();

    // Handle the result of the save operation
    switch (SaveResult)
    {
    case clsBankClient::enSaveResults::svSucceeded:
        cout << "\nAccount Updated Successfully :-)\n";
        Client1.Print();
        break;

    case clsBankClient::enSaveResults::svFaildEmptyObject:
        cout << "\nError: Account was not saved because it's empty.";
        break;

    case clsBankClient::enSaveResults::svFaildAccountNumberExists:
        cout << "\nError: Account number already exists.";
        break;
    }
}

// Main function
int main()
{
    UpdateClient();
    return 0;
}