using System;
using System.Collections.Generic;


class PalindromeChecker
{
    static bool IsPalindrome(string input)
    {
        Stack<char> stack = new Stack<char>(input);

        // Check if the string reads the same forward and backward
        foreach (char c in input)
        {
            if (stack.Pop() != c)
            {
                return false; // If any character doesn't match, it's not a palindrome
            }
        }

        return true;
    }


    static void Main()
    {
        string input = "madam";
        Console.WriteLine($"Is \"{input}\" a palindrome? {IsPalindrome(input)}");

        input = "hello";
        Console.WriteLine($"Is \"{input}\" a palindrome? {IsPalindrome(input)}");


        input = "noon";
        Console.WriteLine($"Is \"{input}\" a palindrome? {IsPalindrome(input)}");
    }
}
