/*
Password Strength Checker
Task: Use a BitArray to track whether a password has an uppercase letter,
a lowercase letter, a digit, and a special character.
*/


using System;

// 1. Define the Enum with the [Flags] attribute
[Flags]
enum PasswordCriteria
{
    None = 0,           // 0000
    Uppercase = 1,      // 0001
    Lowercase = 2,      // 0010
    Digit = 4,          // 0100
    Special = 8,        // 1000
    All = Uppercase | Lowercase | Digit | Special 
}

class Program
{
    static bool IsStrongPassword(string password)
    {
        PasswordCriteria status = PasswordCriteria.None;

        foreach (char c in password)
        {
            // Bitwise OR (|) acts as a switch to Turn ON the specific bit
            if (char.IsUpper(c))
            {
                status |= PasswordCriteria.Uppercase;
            }
            else if (char.IsLower(c))
            {
                status |= PasswordCriteria.Lowercase;
            }
            else if (char.IsDigit(c))
            {
                status |= PasswordCriteria.Digit;
            }
            else
            {
                status |= PasswordCriteria.Special;
            }

            if (status == PasswordCriteria.All) return true;
        }

        // Final check: Does status contain ALL the required bits?
        return status == PasswordCriteria.All;
    }

    static void Main()
    {
        string pass1 = "Mohamed123";      // Weak
        string pass2 = "Mo@123";          // Strong
        
        Console.WriteLine($"Pass1 Strong? {IsStrongPassword(pass1)}"); 
        Console.WriteLine($"Pass2 Strong? {IsStrongPassword(pass2)}"); 

        PasswordCriteria partial = PasswordCriteria.Uppercase | PasswordCriteria.Digit;
        Console.WriteLine($"Partial Status: {partial}");
        
        Console.ReadKey();
    }
}