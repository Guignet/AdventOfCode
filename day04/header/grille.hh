#include <string>
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

class Grille {
    public:
    vector<vector<pair<int,int>>> tab;
    //constructor
    Grille();
    void is_collumn_win();
    void is_row_win();

};

