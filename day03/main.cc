#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "header/func.hh"
int sbin_to_i(string const test){
  int res=0;
  for(int i=0;i<test.size();i++){
    res = (res << 1);
    if(test[i]=='1')
    res++;
  }
  return res ;
}
using namespace std;
int main(){
  cout << "part I : Gamma * Epsilon = " << gammaXepsilon("src/keep.txt") << endl;
  cout << "part II : " << oxygen_generator_rating("src/keep.txt")*CO2_scrubber_rating("src/keep.txt") << endl;
  return 0;
}
// Part I : 2954600 that's the right answers