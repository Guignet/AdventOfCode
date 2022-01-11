using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace day06
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Hello World! {0} ",args[0]);
            // 
            Console.Write("Number of fishes for {1} days : {0}\n",p.number_fishV2(p.List_of_Fish("input.txt"),Int32.Parse(args[0])),args[0]);
        }

        List<int> List_of_Fish(string nomFich){
            string[] lines = System.IO.File.ReadAllLines(nomFich);
            List<int> fishes = new List<int>();

            Regex rgxDigit = new Regex(@"\d+");
            MatchCollection matches = rgxDigit.Matches(lines[0]);
            foreach(Match m in matches){
                fishes.Add(Int32.Parse(m.Value));
            }
            return fishes;

        }
        int number_fishV1(string nomFich,int nb_jours){
            string[] lines = System.IO.File.ReadAllLines(nomFich);
            List<int> fishes = new List<int>();

            Regex rgxDigit = new Regex(@"\d+");
            MatchCollection matches = rgxDigit.Matches(lines[0]);
            foreach(Match m in matches){
                fishes.Add(Int32.Parse(m.Value));
            }
            
            // initial day
            Console.Write("Initial day :");
            foreach(int a in fishes){
                Console.Write(" {0}",a);
            }
            Console.Write("\n");
            Console.WriteLine("Fishes numbers : {0}",fishes.Count);
            //---------------
            for(int i=0;i<nb_jours;i++){
                int tmp = fishes.Count;
                for(int j=0;j<tmp;j++){
                    if(fishes[j]==0){
                        fishes.Add(8);
                        fishes[j]=6;
                    }
                    else fishes[j]--;

                }

                 Console.WriteLine("day {0} :",i+1);
                 Console.WriteLine("Number of fish {0}",fishes.Count);
                // foreach(int a in fishes){
                //     Console.Write(" {0}",a);
                // }
                // Console.Write("\n");
            }
            return fishes.Count;
        }
        long number_fishV2(List<int> fishes,int nb_jours){
            List<long> fishesByDay = new List<long>();
            for(int i=0;i<9;i++){
                fishesByDay.Add(0);
            }
            foreach(int fish in fishes){
                fishesByDay[fish]++;
            }
            foreach(long day in fishesByDay){
                Console.WriteLine(day);
            }
            // initial day
            Console.Write("Initial day ");
            long count = 0;
            foreach(long day in fishesByDay){
                count+=day;
            }
            //Console.Write("\n");
            Console.WriteLine("Fishes numbers : {0}",count);
            //---------------

            // starting program 
            
            for(int j=0;j<nb_jours;j++){
                List<long> tmp = new List<long>();
                foreach(long day in fishesByDay){
                    tmp.Add(day);
                    //Console.WriteLine("going in days {0}",day);
                }
                for(int i=0;i<9;i++){
                    switch (i){
                        case 0 :
                            fishesByDay[6]=tmp[i];
                            fishesByDay[8]=tmp[i];
                        break;
                        case 7:
                            fishesByDay[i-1]+=tmp[i];
                        break;
                        default :
                            fishesByDay[i-1]=tmp[i];
                        break;
                    }
                }
                    
            }
            // End of program
            count=0;
            foreach(long number in fishesByDay){
                count+=number;
            }
            
            return count;
        }

    }
}
