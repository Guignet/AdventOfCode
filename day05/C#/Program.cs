using System;

using System.Collections;
using System.Text.RegularExpressions;

namespace C_
{
    class Program
    {
        // public int osef { get; set; } = 42;
        public int osef = 42 ;
        public string fich = "input2.txt";
        public bool debug = true;
        public int size = 10;
        static void Main(string[] args){
            Program p =  new Program();

            ArrayList allVect = p.Init_ArrayList(p.fich);
            //just to check that it work 
            if(p.debug)
            foreach(ArrayList Vect in allVect){
                foreach(int x in Vect){
                    Console.Write("{0} ",x);
                }
                Console.Write("\n");
            }

            Console.WriteLine("Part I : {0}",p.Result_Part1(p.size,allVect));
       
        }   
        public int Test(int a){
            return a;
        }
        //read files and transform it into an array[number of row][4]
        public ArrayList Init_ArrayList(string nomFich){
            int a = this.osef;
            ArrayList AllVector = new ArrayList();
            string[] lines = System.IO.File.ReadAllLines(nomFich);
            Regex rgxDigit = new Regex(@"\d+");
             
            foreach (string line in lines){
                ArrayList aL = new ArrayList();
                string tmp = line;
                for(int i=0;i<4;i++){
                    string digitString = rgxDigit.Match(tmp).Value;
                    aL.Add(Int32.Parse(digitString));
                    tmp = Regex.Replace(tmp,@"^[,]*[ ]*[-]*[>]*[ ]*\d+","");
                    // Console.WriteLine(tmp);
                }
                
                AllVector.Add(aL);
            }


            return AllVector;
        }
        public int Result_Part1(int size,ArrayList allVect){
            ArrayList Diagram = new ArrayList();
            
            for(int i=0;i<size;i++){//init of Diagram
                ArrayList tmp = new ArrayList();
                for(int j=0;j<p.size;j++){
                    tmp.Add(0);
                }
                Diagram.Add(tmp);
            }
            foreach(ArrayList vect in allVect){
                
                if(vect[0]==vect[2]){
                    if(vect[1]==vect[3]){
                        Diagram[vect[0]][vect[1]]++;
                    }
                    else if(vect[1]<vect[3]){
                        for(int i=vect[1];i<vect[3];i++){
                            Diagram[vect[0]][i]++;
                        }
                    }
                    else{
                        for(int i=vect[3];i<vect[1];i++){
                            Diagram[vect[0]][i]++;
                        }
                    }
                }
                else if(vect[1]==vect[3]){

                }
            }
            return 0;
        }


    }
}
