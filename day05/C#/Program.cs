using System;
using System.IO;
using System.Collections;

namespace C_
{
    class Program
    {
        // public int osef { get; set; } = 42;
        public int osef = 42 ;
        public string fich = "input.txt";
        static void Main(string[] args){
            Program p =  new Program();

            ArrayList allVect = p.Init_ArrayList(p.fich);
            foreach(ArrayList Vect in allVect){
                foreach(int x in Vect){
                    Console.Write(" {0}",x);
                }
            }

       
        }   
        public int Test(int a){
            return a;
        }
        
        public ArrayList Init_ArrayList(string nomFich){
            int a = this.osef;
            ArrayList AllVector = new ArrayList();
            string[] lines = System.IO.File.ReadAllLines(nomFich);

            foreach (string line in lines){
                ArrayList aL = new ArrayList();
                string tmp ="";
                foreach(char c in line){
                    if(c!=','&&c!='='&&c!='>'&&c!=' '){
                        tmp += c;
                    }
                    else{
                        aL.Add(tmp);
                        tmp = "";
                    }
                }
                AllVector.Add(aL);
            }

            return AllVector;
        }
    }
}


 // Display the file contents by using a foreach loop.
        // System.Console.WriteLine("Contents of WriteLines2.txt = ");
        // foreach (string line in lines)
        // {
        //     // Use a tab to indent each line of the file.
        //     Console.WriteLine("\t" + line);
        // }



        // // Keep the console window open in debug mode.
        // Console.WriteLine("Press any key to exit.");
        // System.Console.ReadKey();