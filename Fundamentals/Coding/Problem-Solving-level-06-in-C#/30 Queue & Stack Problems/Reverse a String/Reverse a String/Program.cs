/*


Reverse a String
Problem: Reverse a given string using a stack.

Input: "hello"
Output: "olleh"
Key Idea: Push each character onto the stack, then pop them off to get the reversed string.

*/


using System.Text;

class ReverseString
{
    public static string MyReverseString(string text)
    {
        Stack<char> chars = new Stack<char>(text);
        return string.Join("", chars);
    }

    public static string ReverseFast(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }


    static void Main()
    {
        string input = "hello";
        Console.WriteLine($"Original: {input}");
        Console.WriteLine($"Reversed: {MyReverseString(input)}");
        Console.ReadKey();
    }
}


