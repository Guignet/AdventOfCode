#include "../header/func.hh"

//just an enum 
enum Input_str{
    FORWARD,
    DOWN,
    UP
};

int str_to_enum(string const inp){  //to handle the enum
    //cout to debug
    // cout << inp << endl;
    if(inp == "forward" )
    return FORWARD;
    if(inp == "down" )
    return DOWN;
    if(inp == "up" )
    return UP;
    return -1;
}

int handle_files(string const nomFich){
    ifstream flux(nomFich.c_str());// open files
    if(flux){
        // init var
        Submarine sub;
        string move ;
        int val = 0;
        while(flux>>move){//while we have a string 
            
            switch (str_to_enum(move))  //switch to each enum
            {
            case FORWARD:
                flux>>val;
                sub.forward(val);
            break;
            
            case DOWN:
                flux>>val;
                sub.down(val);

            break;
            case UP:
                flux>>val;
                sub.up(val);
            break;

            default:
                flux>>val;
            break;
            }
        }
        // cout to debug
        // cout << sub.get_depth() << endl;
        // cout << sub.get_h_pos() << endl;
    return sub.get_depth()*sub.get_h_pos();
    }
    else{
        cout << "ERROR : could not read files" << endl;
    }
}
