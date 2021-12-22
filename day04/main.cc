#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "header/func.hh"

using namespace std;
int main(){
  vector<int> LoN = file_to_list_number("src/keep2.txt");
  vector<Grille> AllGrille ;
  AllGrille.push_back(create_Grille("osef"));
  for(int a : LoN){
    cout << a << endl;
  }


  return 0;
}
