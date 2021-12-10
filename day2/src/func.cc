#include "../header/func.hh"

double print_number_increased(string const nomFich){
    // ofstream flux(nomFich.c_str());
  ifstream floux(nomFich.c_str());
  // if(flux){
  //   flux << "YO idc " << endl;
  //   flux << 26.42 << endl ;
  //   int a = 42;
  //   flux << "OMG y'a "<< a << endl;
  // }
  // else{
  //   cout << "ERROR: could not open file" << endl;
  // }
  if(floux){
    double test;
    double previous = -1;
    double count_increased = 0;
    while(floux >> test){
      // cout << test << endl;
      if(previous != -1){
        if(test>previous){
          count_increased++;
        }

        

      }
      previous = test;
    }
    cout <<"number increased : " << count_increased << endl;
    return count_increased;
  }
  else{
    cout << "ERROR: could not read the file" << endl;
      return -1;
  }

}

double sum_vect(vector<double> to_sum){
    double sum = 0;
    for(double a: to_sum){
        sum+=a;
    }
    return sum;
}

int increased_counter(double previous, double current){
    if(current > previous)
    return 1;
    return 0;
}

double count_calender_day1(string const nomFich){
    ifstream floux(nomFich.c_str());
    ofstream flix("src/tmp.txt");
    if(flix)
        if(floux){
            vector<double> A;
            vector<double> B;
            vector<double> C;
            vector<double> D;
            double inp;
            double previous = 0;
            double current = 0;
            double count_increased = 0;
            int count_read;
            while(floux>>inp){
                switch (count_read % 4){
                    case 0:
                        /* code */
                        A.push_back(inp);
                        if(count_read>2){
                            C.push_back(inp);
                            D.push_back(inp);
                            current = sum_vect(C);
                            C.resize(0);
                            count_increased += increased_counter(previous,current);
                            previous = current;
                        }

                        count_read++;
                    break;
                    case 1:
                        A.push_back(inp);
                        B.push_back(inp);
                        if(count_read>2){
                            D.push_back(inp);
                            
                            current = sum_vect(D);
                            D.resize(0);
                            count_increased += increased_counter(previous,current);

                            previous = current;
                        }
                        count_read++;
                    break;
                    case 2:
                        A.push_back(inp);
                        B.push_back(inp);
                        C.push_back(inp);
                        current = sum_vect(A);
                        A.resize(0);
                        if(previous!=0)
                        count_increased += increased_counter(previous,current);
                        previous = current;
                        
                        count_read++;
                    break;
                    case 3:
                        B.push_back(inp);
                        C.push_back(inp);
                        D.push_back(inp);
                        
                        current = sum_vect(B);
                        D.resize(0);
                        count_increased += increased_counter(previous,current);
                        previous = current;
                        
                        count_read++;
                    break;
                }
            }

            return count_increased;
        }
        else{
            cout << "ERROR: Could not read files" << endl;
            return -1;
        }
        else{
        cout << "ERROR: Could not read files" << endl;
        return -1;

        }

}

double count_calender_day1V2(string const nomFich){
    ifstream floux(nomFich.c_str());
    ofstream flix("src/tmp.txt");
    
    if(floux){
        vector<double> A;
        vector<double> B;
        vector<double> C;
        vector<double> D;
        double inp;
        int count_read = 0;
        while(floux>>inp){
            switch (count_read % 4){
                case 0:
                    /* code */
                    A.push_back(inp);
                    if(count_read>2){
                        C.push_back(inp);
                        D.push_back(inp);
                        flix << sum_vect(C)<<endl;
                        C.resize(0);
                    }
                    count_read++;
                break;
                case 1:
                    A.push_back(inp);
                    B.push_back(inp);
                    if(count_read>2){
                        D.push_back(inp);
                        
                        flix << sum_vect(D)<<endl;
                        D.resize(0);

                    }
                    count_read++;
                break;
                case 2:
                    A.push_back(inp);
                    B.push_back(inp);
                    C.push_back(inp);
                    flix <<  sum_vect(A)<<endl;
                    A.resize(0);
                    
                    count_read++;
                break;
                case 3:
                    B.push_back(inp);
                    C.push_back(inp);
                    D.push_back(inp);
                    
                    flix << sum_vect(B)<<endl;
                    B.resize(0);
                    
                    count_read++;
                break;
            }
        }

        return print_number_increased("src/tmp.txt");
    }
    else{
        cout << "ERROR: Could not read files" << endl;
        return -1;
    }
    
    

}
