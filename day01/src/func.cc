#include "../header/func.hh"

double print_number_increased(string const nomFich){
//function to get the number of increase value from previous to current value 
  ifstream floux(nomFich.c_str()); // we open the file
  if(floux){    //we verify that the files exist and is open
    double test;
    double previous = -1;
    double count_increased = 0;
    while(floux >> test){   // we put a number from floux to test
      if(previous != -1){   //first init case
        if(test>previous){  // check the difference
          count_increased++;    //increase the count 
        }
      }
      previous = test;  // previous become current(test)
    }
    cout <<"number increased : " << count_increased << endl; //we print the final number before returning it 
    return count_increased;
  }
  else{
    cout << "ERROR: could not read the file" << endl;   //in case the file does not exist
      return -1;    //error return
  }

}

double sum_vect(vector<double> to_sum){
    //to make the sum of each element of a vector
    double sum = 0;
    for(double a: to_sum){
        sum+=a;
    }
    return sum;
}


double count_calender_day1(string const nomFich){
    //second part of the day
    ifstream floux(nomFich.c_str());    //read files
    ofstream flix("src/tmp.txt");       //write files 
    
    if(floux){  // check if it exist
        //init of vector 
        vector<double> A;
        vector<double> B;
        vector<double> C;
        vector<double> D;
        double inp; // input
        int count_read = 0; //count of elements read
        
        while(floux>>inp){
            switch (count_read % 4){    //we divide the code in 4 cases
                case 0:
                    A.push_back(inp);   //we push number read in A
                    if(count_read>2){   // for the init
                        C.push_back(inp);   
                        D.push_back(inp);
                        flix << sum_vect(C)<<endl;  //in this case C will be full so we make the sum of each elements of C and write it in a file
                        C.resize(0);    //we empty C 
                    }
                    count_read++;
                break;
                case 1: //as case 0
                    A.push_back(inp);
                    B.push_back(inp);
                    if(count_read>2){
                        D.push_back(inp);                       
                        flix << sum_vect(D)<<endl;
                        D.resize(0);
                    }
                    count_read++;
                break;
                case 2: //as case 0 whithout the init
                    A.push_back(inp);
                    B.push_back(inp);
                    C.push_back(inp);
                    flix <<  sum_vect(A)<<endl;
                    A.resize(0);
                    count_read++;
                break;
                case 3: //as case 0 whithout the init
                    B.push_back(inp);
                    C.push_back(inp);
                    D.push_back(inp);
                    flix << sum_vect(B)<<endl;
                    B.resize(0);
                    count_read++;
                break;
            }
        }
        return print_number_increased("src/tmp.txt");   //we use the previous programm with the new file created
    }
    else{
        cout << "ERROR: Could not read files" << endl;
        return -1;
    }
}
