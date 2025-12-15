#include <iostream>
#include "headers/clsPerson.h";
#include "headers/clsEmployee.h";

using namespace std;

int main()

{

    clsEmployee Employee1(10, "Mohammed", "Abu-Hadhoud", 
        "A@a.com", "8298982", "CEO", "ProgrammingAdvices", 5000);

    Employee1.Print();

    system("pause>0");
    return 0;
}
