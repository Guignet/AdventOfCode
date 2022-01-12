using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace day07
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            List<int> crabs = p.analyze_files(args[0]);
            Console.WriteLine("Part I MIN {0} is {1}",args[0],p.part1_res(crabs));
            Console.WriteLine("Part 2 MIN {0} is {1}",args[0],p.part2_res(crabs));
        }

        List<int> analyze_files(string nameFile){
            string[] lines = System.IO.File.ReadAllLines(nameFile);
            List<int> crabs = new List<int>();
            Regex rgxDigit = new Regex(@"\d+");
            MatchCollection matches = rgxDigit.Matches(lines[0]);
            foreach(Match m in matches){
                crabs.Add(Int32.Parse(m.Value));
            }
            Console.WriteLine("first {0} last {1}",crabs[0],crabs[crabs.Count-1]);
            return crabs;
        }

        long part1_res(List<int> crabs){
            int MAX = crabs[0];
            List<int> calc_res = new List<int>();
            for(int i=0;i<crabs.Count;i++){
                if(crabs[i]>MAX)MAX = crabs[i];
            }
            for(int i=0;i<MAX;i++){
                calc_res.Add(0);
            }
            for(int i=0;i<calc_res.Count;i++){
                foreach(int crab in crabs){
                    if(crab<i)calc_res[i]+= i-crab;
                    else calc_res[i]+=crab-i;
                }
            }
            int MIN=MAX*crabs.Count;
            foreach(int res in calc_res){
                if(res<MIN)MIN=res;
            }
            return MIN;
        }

         long part2_res(List<int> crabs){
            int MAX = crabs[0];
            List<int> calc_res = new List<int>();
            for(int i=0;i<crabs.Count;i++){
                if(crabs[i]>MAX)MAX = crabs[i];
            }
            for(int i=0;i<MAX;i++){
                calc_res.Add(0);
            }
            for(int i=0;i<calc_res.Count;i++){
                foreach(int crab in crabs){
                    if(crab<i){
                        int n = i-crab;
                        calc_res[i]+=(n*(n+1))/2;

                    }
                    else {
                        int n = crab-i;
                        calc_res[i]+=(n*(n+1))/2;
                    
                    }
                }
            }
            int MIN=int.MaxValue;
            int pos=-1; 
            // foreach(int res in calc_res){
            //     if(res<MIN)MIN=res;
            // }
            for(int i =0;i<calc_res.Count;i++){
                if(calc_res[i]<MIN){
                    MIN=calc_res[i];
                    pos = i;
                }
            }
            Console.WriteLine(" pos {0}",pos);
            return MIN;
        }

    }
}
