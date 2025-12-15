#pragma once
#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include <algorithm>

using namespace std;

class clsUtil {
public:
    enum enCharType {
        SmallLetter = 1, CapitalLetter = 2,
        Digit = 3, MixChars = 4, SpecialCharacter = 5
    };

    static void Srand() {
        srand(static_cast<unsigned>(time(nullptr)));
    }

    static int RandomNumber(int From, int To) {
        return rand() % (To - From + 1) + From;
    }

    static char GetRandomCharacter(enCharType CharType) {
        if (CharType == MixChars) {
            CharType = static_cast<enCharType>(RandomNumber(1, 3));
        }

        switch (CharType) {
        case SmallLetter: return static_cast<char>(RandomNumber(97, 122));
        case CapitalLetter: return static_cast<char>(RandomNumber(65, 90));
        case SpecialCharacter: return static_cast<char>(RandomNumber(33, 47));
        case Digit: return static_cast<char>(RandomNumber(48, 57));
        default: return static_cast<char>(RandomNumber(65, 90)); // Default to capital letter
        }
    }

    static string GenerateWord(enCharType CharType, short Length) {
        string Word;
        Word.reserve(Length);
        for (int i = 0; i < Length; ++i) {
            Word += GetRandomCharacter(CharType);
        }
        return Word;
    }

    static string GenerateKey(enCharType CharType = CapitalLetter) {
        return GenerateWord(CharType, 4) + "-" + GenerateWord(CharType, 4) + "-" +
               GenerateWord(CharType, 4) + "-" + GenerateWord(CharType, 4);
    }

    static void GenerateKeys(short NumberOfKeys, enCharType CharType) {
        for (int i = 1; i <= NumberOfKeys; ++i) {
            cout << "Key [" << i << "] : " << GenerateKey(CharType) << endl;
        }
    }

    template <typename T>
    static void ShuffleArray(vector<T>& arr) {
        for (size_t i = 0; i < arr.size(); ++i) {
            swap(arr[RandomNumber(0, arr.size() - 1)], arr[RandomNumber(0, arr.size() - 1)]);
        }
    }

    static string Tabs(short NumberOfTabs) {
        return string(NumberOfTabs, '\t');
    }

    static string EncryptText(string Text, short EncryptionKey = 2) {
        for (char& ch : Text) {
            ch = static_cast<char>(ch + EncryptionKey);
        }
        return Text;
    }

    static string DecryptText(string Text, short EncryptionKey = 2) {
        for (char& ch : Text) {
            ch = static_cast<char>(ch - EncryptionKey);
        }
        return Text;
    }

    static string NumberToText(int Number) {
        if (Number == 0) return "Zero";
        static const string Units[] = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven",
                                        "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen",
                                        "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static const string Tens[] = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        string result;
        if (Number >= 1000) {
            result += Units[Number / 1000] + " Thousand ";
            Number %= 1000;
        }
        if (Number >= 100) {
            result += Units[Number / 100] + " Hundred ";
            Number %= 100;
        }
        if (Number >= 20) {
            result += Tens[Number / 10] + " ";
            Number %= 10;
        }
        if (Number > 0) {
            result += Units[Number] + " ";
        }
        return result;
    }
};
