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
            // Console.WriteLine("Hello World!");
            Console.Write("Part I : {0}\n",p.number_fish("input.txt",80));
        }

        int number_fish(string nomFich,int nb_jours){
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
            for(int i=0;i<nb_jours;i++){
                int tmp = fishes.Count;
                for(int j=0;j<tmp;j++){
                    if(fishes[j]==0){
                        fishes.Add(8);
                        fishes[j]=6;
                    }
                    else fishes[j]--;

                }
                // Console.Write("day {0} :",i+1);
                // foreach(int a in fishes){
                //     Console.Write(" {0}",a);
                // }
                // Console.Write("\n");
            }
            return fishes.Count;
        }
    }
}
