#include "../header/grille.hh"

Grille::Grille(){
    size = 5;
    tab.resize(size);
}

bool Grille::is_collumn_win(){
    for(int i=0;i<size;i++){
        int count =0;
        for(int j=0;j<size;j++){
            if(tab[j][i].second==0)break;
            else count++;

        }
        if(count == 5)return true;
    }
    return false;
}

bool Grille::is_row_win(){
    for(int i=0;i<size;i++){
        int count =0;
        for(int j=0;j<size;j++){
            if(tab[i][j].second==0)break;
            else count++;

        }
        if(count == 5)return true;
    }
    return false;
}

void Grille::mark_number(int val){
   for(int i=0;i<size;i++){
        for(int j=0;j<size;j++){
           if(tab[i][j].first==val)
           tab[i][j].second = 1; 

        }
        
    }
}

int Grille::sum_unmarked(){
    int res = 0;
    for(vector<pair<int,int>> a:tab){
        for(pair<int,int> b : a){
            if(b.second==0){
            res += b.first;
            }
        }
    }
    return res;
}

void Grille::print_(){
    for(vector<pair<int,int>> a : tab){
        for(pair<int,int> b : a){
            cout << "[" << b.first << "," << b.second << "]" << " ";
        }
        cout <<endl;
    }
}
