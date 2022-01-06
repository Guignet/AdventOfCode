#include <string>
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

class Grille {
    public:
        int size;
        vector<vector<pair<int,int>>> tab;
        //constructor
        Grille();
        bool is_collumn_win();
        bool is_row_win();
        void mark_number(int val);
        int sum_unmarked();
        void print_();
};

