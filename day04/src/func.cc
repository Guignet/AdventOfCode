#include "../header/func.hh"

vector<int> file_to_list_number(string const nomFich){
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
        for(int i=0; i<line.size()+1;i++){
            if((line[i]!= ',')&&(line[i]!='\0')){
                tmp+=line[i];
            }
            else{
                
                res.push_back(atoi(tmp.c_str()));
                tmp.clear();
            }
        }
        ofstream flix("src/tmp.txt");

        while(getline(flux,line)){
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

int Part1_res(string const nomFich){
    vector<int> LoN = file_to_list_number(nomFich);
    vector<Grille> AllGrille ;
    for(int i=0;i<100;i++){
        AllGrille.push_back(create_Grille());
    } 

    for(int a:LoN){
        for(int i=0;i<AllGrille.size();i++){
            AllGrille[i].mark_number(a);
        }
        for(int i=0;i<AllGrille.size();i++){
            if(AllGrille[i].is_collumn_win()||AllGrille[i].is_row_win()){
                return a*AllGrille[i].sum_unmarked();
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

}
