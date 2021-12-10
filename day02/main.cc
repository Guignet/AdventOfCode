#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "header/func.hh"
#include "header/submarine.hh"

using namespace std;

int main(){
  cout << "depth times pos = " << handle_files("src/keep.txt") << endl;
  return 0;
}
