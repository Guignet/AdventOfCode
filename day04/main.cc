#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "header/func.hh"

using namespace std;
int main(){
  vector<int> LoN = file_to_list_number("src/keep2.txt");
  vector<Grille> AllGrille ;
  AllGrille.push_back(create_Grille());
  // for(int a : LoN){
  //   cout << a << endl;
  // }
  // for(vector<pair<int,int>> a : AllGrille[0].tab){
  //   for(pair<int,int> b : a){
  //     cout << b.first << " ";

  //   }
  //   cout <<endl;

  // }

  cout << Part1_res("src/keep.txt") << endl ;

  return 0;
}
