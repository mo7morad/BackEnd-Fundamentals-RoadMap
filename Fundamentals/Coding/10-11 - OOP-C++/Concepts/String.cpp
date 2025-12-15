// This file is ment to test the clsString class, with all its methods.

#include <iostream>
#include "headers/clsString.h"
using namespace std;

int main()

{
  clsString String1;

  clsString String2("Mohammed");

  String1.SetValue("Ali Ahmed");

  cout << "String1 = " << String1.GetValue() << endl;
  cout << "String2 = " << String2.GetValue() << endl;

  cout << "Number of words: " << String1.CountWords() << endl;

  cout << "Number of words: " << String1.CountWords("Fadi ahmed rateb omer") << endl;

  cout << "Number of words: " << clsString::CountWords("Mohammed Saqer Abu-Hadhoud") << endl;

  //----------------
  clsString String3("hi how are you?");

  cout << "String 3 = " << String3.GetValue() << endl;

  cout << "String Length = " << String3.Length() << endl;

  String3.UpperFirstLetterOfEachWord();
  cout << String3.GetValue() << endl;

  //----------------

  String3.LowerFirstLetterOfEachWord();
  cout << String3.GetValue() << endl;

  //----------------

  String3.UpperAllString();
  cout << String3.GetValue() << endl;

  //----------------

  String3.LowerAllString();
  cout << String3.GetValue() << endl;

  //----------------

  cout << "After inverting a : " << clsString::InvertLetterCase('a') << endl;

  //----------------

  String3.SetValue("AbCdEfg");

  String3.InvertAllLettersCase();
  cout << String3.GetValue() << endl;

  String3.InvertAllLettersCase();
  cout << String3.GetValue() << endl;

  //----------------

  cout << "Capital Letters count : " << clsString::CountLetters("Mohammed Abu-Hadhoud", clsString::CapitalLetters) << endl << endl;

  //----------------

  String3.SetValue("Welcome to Jordan");
  cout << String3.GetValue() << endl;

  cout << "Capital Letters count :" << String3.CountCapitalLetters() << endl;

  //----------------

  cout << "Small Letters count :" << String3.CountSmallLetters() << endl;

  //----------------

  cout << "vowels count :" << String3.CountVowels() << endl;

  //----------------

  cout << "letter E count :" << String3.CountSpecificLetter('E', false) << endl;

  //----------------

  cout << "is letter u vowel? " << clsString::IsVowel('a') << endl;

  //----------------

  cout << "Words Count" << String3.CountWords() << endl;

  //----------------

  vector<string> vString;

  vString = String3.Split(" ");

  cout << "\nTokens = " << vString.size() << endl;

  for (string &s : vString)
  {
    cout << s << endl;
  }

  //----------------

  // Tirms
  String3.SetValue("    Mohammed Abu-Hahdoud     ");
  cout << "\nString     = " << String3.GetValue();

  String3.SetValue("    Mohammed Abu-Hahdoud     ");
  String3.TrimLeft();
  cout << "\n\nTrim Left  = " << String3.GetValue();

  //----------------

  String3.SetValue("    Mohammed Abu-Hahdoud     ");
  String3.TrimRight();
  cout << "\nTrim Right = " << String3.GetValue();

  //----------------

  String3.SetValue("    Mohammed Abu-Hahdoud     ");
  String3.Trim();
  cout << "\nTrim       = " << String3.GetValue();

  //----------------

  // Joins
  vector<string> vString1 = {"Mohammed", "Faid", "Ali", "Maher"};

  cout << "\n\nJoin String From Vector: \n";
  cout << clsString::JoinString(vString1, " ");

  string arrString[] = {"Mohammed", "Faid", "Ali", "Maher"};

  cout << "\n\nJoin String From array: \n";
  cout << clsString::JoinString(arrString, 4, " ");

  //----------------

  String3.SetValue("Mohammed Saqer Abu-Hahdoud");
  cout << "\n\nString     = " << String3.GetValue();

  String3.ReverseWordsInString();
  cout << "\nReverse Words : " << String3.GetValue() << endl;

  //---------------

  String3.SetValue("Mohammed Saqer Abu-Hahdoud");
  cout << "\nReplace : " << String3.ReplaceWord("Mohammed", "Sari") << endl;

  //---------------

  String3.SetValue("This is: a sample text, with punctuations.");
  cout << "\n\nString     = " << String3.GetValue();

  String3.RemovePunctuations();
  cout << "\nRemove Punctuations : " << String3.GetValue() << endl;

  //---------------
  return 0;
};
