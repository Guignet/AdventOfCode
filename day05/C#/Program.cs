using System;

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace C_
{
    class Program
    {
        // public int osef { get; set; } = 42;
        public int osef = 42 ;
        public string fich = "input2.txt";
        public bool debug = true;
        public int size = 1000;
        static void Main(string[] args){
            Program p =  new Program();

            List<List<int>> allVect = p.Init_ArrayList(p.fich);
            //just to check that it work 
            // if(p.debug)
            // foreach(List<int> Vect in allVect){
            //     foreach(int x in Vect){
            //         Console.Write("{0} ",x);
            //     }
            //     Console.Write("\n");
            // }

            Console.WriteLine("Part I : {0}",p.Result_Part1(p.size,allVect));
            Console.WriteLine("Part II : {0}",p.Result_Part2(p.size,allVect));
            
        }   
        public int Test(int a){
            return a;
        }
        //read files and transform it into an array[number of row][4]
        public List<List<int>> Init_ArrayList(string nomFich){
            int a = this.osef;
            List<List<int>> AllVector = new List<List<int>>();
            string[] lines = System.IO.File.ReadAllLines(nomFich);
            Regex rgxDigit = new Regex(@"\d+");
             
            foreach (string line in lines){
                List<int> aL = new List<int>();
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
        public int Result_Part1(int size,List<List<int>> allVect){
            List<List<int>> Diagram = new List<List<int>>();
            
            for(int i=0;i<size;i++){//init of Diagram
                List<int> tmp = new List<int>();
                for(int j=0;j<size;j++){
                    tmp.Add(0);
                }
                Diagram.Add(tmp);
            }
            int x1,x2,y1,y2;
            foreach(List<int> vect in allVect){
                x1=(int)vect[0];
                x2=(int)vect[2];
                y1=(int)vect[1];
                y2=(int)vect[3];


                if(x1==x2){
                    if(y1==y2){
                        Diagram[x1][y1]++;
                    }
                    else if(y1<y2){
                        for(int i=y1;i<=y2;i++){
                            Diagram[x1][i]++;
                        }
                    }
                    else{
                        for(int i=y2;i<=y1;i++){
                            Diagram[x1][i]++;
                        }
                    }
                }
                else if(y1==y2){
                    if(x1==x2){
                        Diagram[x1][y1]++;
                    }
                    else if(x1<x2){
                        for(int i=x1;i<=x2;i++){
                            Diagram[i][y1]++;
                        }
                    }
                    else{
                        for(int i=x2;i<=x1;i++){
                            Diagram[i][y1]++;
                        }
                    }

                }
            }
            int count =0;
            foreach(List<int> lol in Diagram){
                foreach(int a in lol){
                    if(a>=2)
                    count++;
                    
                   // Console.Write(" {0}",a);
                }
               // Console.Write("\n");
            }

            return count;
        }

        public int Result_Part2(int size,List<List<int>> allVect){
            List<List<int>> Diagram = new List<List<int>>();
            
            for(int i=0;i<size;i++){//init of Diagram
                List<int> tmp = new List<int>();
                for(int j=0;j<size;j++){
                    tmp.Add(0);
                }
                Diagram.Add(tmp);
            }
            int x1,x2,y1,y2;
            int deb =1;
            foreach(List<int> vect in allVect){
                x1=(int)vect[0];
                x2=(int)vect[2];
                y1=(int)vect[1];
                y2=(int)vect[3];
                //Console.WriteLine(deb);

                if(x1==x2){
                    if(y1==y2){
                        Diagram[x1][y1]++;
                    }
                    else if(y1<y2){
                        for(int i=y1;i<=y2;i++){
                            Diagram[x1][i]++;
                        }
                    }
                    else{
                        for(int i=y2;i<=y1;i++){
                            Diagram[x1][i]++;
                        }
                    }
                }
                else if(y1==y2){
                    if(x1==x2){
                        Diagram[x1][y1]++;
                    }
                    else if(x1<x2){
                        for(int i=x1;i<=x2;i++){
                            Diagram[i][y1]++;
                        }
                    }
                    else{
                        for(int i=x2;i<=x1;i++){
                            Diagram[i][y1]++;
                        }
                    }

                }
                else {
                    if(x1<x2&&y1>y2){
                       for(int i=0;i<=x2-x1;i++){
                            Diagram[x1+i][y1-i]++;
                        } 
                    }
                    else if(x1<x2&&y1<y2){
                       for(int i=0;i<=x2-x1;i++){
                            Diagram[x1+i][y1+i]++;
                        }  
                    }
                    else if(x1>x2&&y1<y2){
                       for(int i=0;i<=x1-x2;i++){
                            Diagram[x1-i][y1+i]++;
                        }  
                    }
                    else if(x1>x2&&y1>y2){
                       for(int i=0;i<=x1-x2;i++){
                            Diagram[x1-i][y1-i]++;
                        }  
                    }
                }deb++;
            }
            int count =0;
            foreach(List<int> lol in Diagram){
                foreach(int a in lol){
                    if(a>=2)
                    count++;
                    
                   // Console.Write(" {0}",a);
                }
               // Console.Write("\n");
            }

            return count;
        }

    }
}

/*

*/