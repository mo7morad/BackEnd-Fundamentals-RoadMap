#include <iostream>
using namespace std;

template <typename T1, typename T2>
auto MyMax(T1 number1, T2 number2)
{
  return (number1 > number2) ? number1 : number2;
}


int main()
{
  cout << "Max of 3, 4 is: " << MyMax(3, 4) << endl;
  cout << "Max of 3.5 and 4.5 is: " << MyMax(3.5, 4.5) << endl;
  cout << "Max of 3.5 and 4 is: " << MyMax(3.5, 4) << endl;
  cout << "Max of 3 and 4.5 is: " << MyMax(3, 4.5) << endl;
  return 0;
}