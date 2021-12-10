#include "../header/submarine.hh"

 Submarine::Submarine(){    //constructor
     depth =0;
     h_pos = 0;
     aim = 0;
 }

void Submarine::forward(int val){h_pos+=val;depth+=aim*val;}
void Submarine::down(int val){aim+=val;}
void Submarine::up(int val){aim-=val;}


int Submarine::get_depth(){return depth;}
int Submarine::get_h_pos(){return h_pos;}