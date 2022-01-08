#include "../header/func.hh"

vector<int> file_to_list_number(string const nomFich){
    //We copy keep into tmp
    string syst = "cp " ;
    syst += nomFich;
    syst += " src/tmp.txt" ;
    system(syst.c_str());
    ifstream flux("src/tmp.txt");
    if(flux){
        string line ;
        string tmp;
        vector<int> res;
        getline(flux,line);
        for(int i=0; i<(int)line.size()+1;i++){//we parse bingo's numbers
            if((line[i]!= ',')&&(line[i]!='\0')){//while there is no ,
                tmp+=line[i]; // we add char to a string
            }
            else{//end of number
                
                res.push_back(atoi(tmp.c_str()));// we push the integers value of the string 
                tmp.clear(); //we clear the string
            }
        }
        ofstream flix("src/tmp.txt");

        while(getline(flux,line)){//here we clear the first line and rewrite on tmp
            flix << line << endl;
        }
        return res;
    }
    else{
        cout << "ERROR could not open file" << endl;
        return {-1};
    }
}

Grille create_Grille(){
    ifstream flux("src/tmp.txt");
    Grille res;
    int tmp;
    if(flux){
        for(int i=0;i<res.size;i++){
            for(int j=0;j<res.size;j++){
                flux >> tmp;    
                res.tab[i].push_back({tmp,0});
            }
        }
        system("cp src/tmp.txt src/tmp1.txt");
        ofstream floux("src/tmp1.txt");
        string line;
        while(getline(flux,line)){
            floux << line << endl;
        }
        system("cp src/tmp1.txt src/tmp.txt");
        system("rm -f src/tmp1.txt");
        return res;
    }
    else {
        cout << "ERORR could not read file/file does not exist"<< endl;
    return res;
    }
}

int Part1_res(string const nomFich){//to get Part 1 answer
    vector<int> LoN = file_to_list_number(nomFich);//we create a vector of bingo's number
    vector<Grille> AllGrille ;
    for(int i=0;i<100;i++){//we create 100 Grille
        AllGrille.push_back(create_Grille());
    } 

    for(int a:LoN){//for each numbers
        for(int i=0;i<(int)AllGrille.size();i++){//for each Grille we mark it with the number
            AllGrille[i].mark_number(a);
        }
        for(int i=0;i<(int)AllGrille.size();i++){
            if(AllGrille[i].is_collumn_win()||AllGrille[i].is_row_win()){//if a Grille win
                return a*AllGrille[i].sum_unmarked();//we return what we need
            }
        }
    }
  return 0;
}


int Part2_res(string const nomFich){
    vector<int> LoN = file_to_list_number(nomFich);
    vector<Grille> AllGrille ;
    for(int i=0;i<100;i++){
        AllGrille.push_back(create_Grille());
    } 
   
    int count=0;
    for(int a = 0;a<(int)LoN.size();a++){
        for(int i=0;i<(int)AllGrille.size();i++){
            AllGrille[i].mark_number(LoN[a]);
        }
        for(int i=0;i<(int)AllGrille.size();i++){
            if(AllGrille[i].win == 0){
                if(AllGrille[i].is_collumn_win()||AllGrille[i].is_row_win()){
                    count++;
                    if(count==(int)AllGrille.size()-1){
                        for(int o=0;o<(int)AllGrille.size();o++){
                            if(AllGrille[o].win ==0){
                                AllGrille[o].mark_number(LoN[a+1]);//we mark the last winners Grille with his last number
                            }
                        }
                        return LoN[a+1]*verif_last_Grille(AllGrille);
                    }
                }
            }
        }
    }
    return -1;
}

int verif_last_Grille(vector<Grille> AllGrille){
   
    for(Grille G : AllGrille){
        if(G.win==0){//we search the only non-winner Grille

            //------to debug-----
            // G.print_();
            // cout << G.sum_unmarked() << endl;
            //---------------------

            return G.sum_unmarked();
        }
    }
    return -1;
}
