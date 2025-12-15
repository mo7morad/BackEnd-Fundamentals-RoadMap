#include <iostream>
#include "headers/screens/user/clsLoginScreen.h"

int main()

{
  // prompt the login screen after every logout.
  while (true)
  {
    if(!clsLoginScreen::ShowLoginScreen())
      break;
  }
  return 0;
}