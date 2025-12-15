#include <iostream>
using namespace std;

template <class T>
class Calculator
{
private:
  T _number1, _number2;

public:
  Calculator(T number1, T number2)
  {
    _number1 = number1;
    _number2 = number2;
  }

  void print()
  {
    cout << "Numbers  : " << _number1 << " And " << _number2 << endl;
    cout << _number1 << " + " << _number2 << " = " << add() << endl;
    cout << _number1 << " - " << _number2 << " = " << subtract() << endl;
    cout << _number1 << " / " << _number2 << " = " << divide() << endl;
    cout << _number1 << " * " << _number2 << " = " << multiply() << endl;
  }

  T add()
  {
    return _number1 + _number2;
  }

  T subtract()
  {
    return _number1 - _number2;
  }

  T divide()
  {
    return _number1 / _number2;
  }

  T multiply()
  {
    return _number1 * _number2;
  }
};

int main()
{

  Calculator<int> integerCalc(10, 20);

  cout << "Intger Template Generic Results :  \n";
  integerCalc.print();

  Calculator<float> floatCalc(10.5, 20.8);

  cout << "\n\nFloat Template Generic Results :  \n";
  floatCalc.print();

  system("pause > 0");

  return 0;
}