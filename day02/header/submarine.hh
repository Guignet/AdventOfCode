#ifndef SUBMARINE_HH
#define SUBMARINE_HH

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

class Submarine { 
// class submarine 
private:
    // attributes
    int depth;
    int h_pos;
    int aim;

public:
    Submarine();

    //main function
    void forward(int val);
    void down(int val);
    void up(int val);
    
    //getters
    int get_depth();
    int get_h_pos();
};

#endif