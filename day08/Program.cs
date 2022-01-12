using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            List<List<string>> res_input = new List<List<string>>();
            res_input = p.analyze_input(args[0]);
            //p.print_res_input(res_input);
            Console.WriteLine(p.part1_res(res_input));
        }

        List<List<string>> analyze_input(string nameFile){
            // init of each var including regex
            
            string[] lines = System.IO.File.ReadAllLines(nameFile);
            List<List<string>> res_input = new List<List<string>>();
            Regex rgx4String = new Regex(@"[|]([ ][a-g]*)*");
            Regex rgxString = new Regex(@"[a-g]*");
            
            //----------------------------------

            foreach(string line in lines){
                MatchCollection matches = rgx4String.Matches(line);
                List<string> tmp= new List<string>();
                foreach(Match match in matches){
                    MatchCollection ms = rgxString.Matches(match.Value);
                    foreach(Match m in ms){
                        tmp.Add(m.Value);
                    }
                    // Console.WriteLine("coucou {0} ",match.Value);
                }
                res_input.Add(tmp);

            }

            return res_input;
            
        }

        void print_res_input(List<List<string>> res_input){
            foreach(List<string> g in res_input){
                foreach(string s in g){
                    Console.Write(" {0}",s);
                }
                Console.Write("\n");
            }
        }

        int part1_res(List<List<string>> res_input){
            int count = 0;
            foreach(List<string> g in res_input){
                foreach(string s in g){
                    switch(s.Length){
                        case 2://digit 1
                            count++;break;
                        case 4://digit 4
                            count++;break;
                        case 3://digit 7
                            count++;break;
                        case 7://digit 8
                            count++;break;
                        default:break;
                    }
                }
            }
            return count;
        }
    }
}
