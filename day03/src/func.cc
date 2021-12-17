#include "../header/func.hh"

string inv_bin(string const inp){
    string res;
    for(int i=0;i<inp.size();i++){
        if(inp[i]=='0')
        res+='1';
        else res += '0';
    }
    return res;
}
int bin_to_int(string const bin){
    int res=0;
    for(int i=0;i<bin.size();i++){
        res = (res << 1);
        cout << bin[i] << endl;
        if(bin[i]=='1')
        res++;
    }
    cout << bin << " " << res << endl;
    return res;
}

int gammaXepsilon(string const nomFich){
    ifstream flux(nomFich.c_str());
    if(flux){
        string inp;
        vector<int> val_bits;
        val_bits.resize(12);
        //count number of 1 in each collumn
        while(flux>>inp){
            
            int count=0;
            for(char a:inp){
                if (a == '1')
                val_bits[count]++;
                count++;
            }
        }
        string res;
        for(int c:val_bits){
            if(c>(1000/2))
            res+='1';
            else 
            res+='0';
        }
        
        int gamma = bin_to_int(res);
        
        int epsilon = bin_to_int(inv_bin(res));
        cout << "gamma = "<<gamma<<endl;
        return gamma*epsilon;
    }
    else{
        cout << "ERROR : could not find files" << endl;
        return -1;
    }
    
}

int filter_pos(string const nomFich,int pos,int sup){
     ifstream flux(nomFich.c_str());
     ofstream output0("src/tmpbin0.txt");
     ofstream output1("src/tmpbin1.txt");
    string inp;
    string res;
    int count=0;
    int all_count=0;
     cout << "pos = " <<pos << endl;
    while(flux>>inp){
        if(inp[pos]=='1'){
            output1 << inp << endl;
            count++;
        }
        else 
            output0 << inp << endl;
        
        all_count++;
    }
     cout << "count = " << count <<endl;
    if(all_count == 1){
        return -1;
    }

    if(sup == 1){
        if(count >= all_count/2+all_count%2){
            system("cp src/tmpbin1.txt src/output.txt");
            return 1;
        }
        else {
            system("cp src/tmpbin0.txt src/output.txt") ;
            return 0;

        }

    }
    else {
        if(count >= all_count/2+all_count%2){
            system("cp src/tmpbin0.txt src/output.txt");
            return 1;
        }
        else {
            system("cp src/tmpbin1.txt src/output.txt") ;
            return 0;

        }
    }
}

int oxygen_generator_rating(string const nomFich){
    ifstream flux(nomFich.c_str());
    string tmp;
    int ret_filt;
    flux >> tmp;
    int taille = tmp.size();
    system("cp src/keep.txt src/output.txt");
    //  sleep(2);
    for(int i=0;i<taille;i++){
        if(filter_pos("src/output.txt",i,1)==-1)
        break;
        //   sleep(2);
    }

    ifstream floux("src/output.txt");
    floux>>tmp;
    return bin_to_int(tmp);
    //  return 0;   
}

int CO2_scrubber_rating(string const nomFich){
    ifstream flux(nomFich.c_str());
    string tmp;
    int ret_filt;
    flux >> tmp;
    int taille = tmp.size();
    system("cp src/keep.txt src/output.txt");
    // sleep(2);
    for(int i=0;i<taille;i++){
        if(filter_pos("src/output.txt",i,0)==-1)
        break;
        //   sleep(2);
    }

    ifstream floux("src/output.txt");
    floux>>tmp;
    return bin_to_int(tmp);
    //  return 0;   
}