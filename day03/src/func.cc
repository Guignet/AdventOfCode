#include "../header/func.hh"

string inv_bin(string const inp){
    for(int i)
}
float bin_to_int(string const bin){
    float res=0;
    for(int i=0;i<=bin.length();i++){
        if(bin[i]=='1')
        res= res + pow(2.0,float(bin.length()-i));
        cout << bin[i] << endl;
    }
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
        float gamma = bin_to_int(res);
        float epsilon = pow(2,res.length())-gamma;
        return int(gamma*epsilon);
    }
    else{
        cout << "ERROR : could not find files" << endl;
        return -1;
    }
    
}