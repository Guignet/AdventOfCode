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
            List<List<string>> res_inputp1 = new List<List<string>>();
            List<List<string>> res_inputp2 = new List<List<string>>();
            res_inputp1 = p.analyze_inputP1(args[0]);
            res_inputp2 = p.analyze_inputP2(args[0]);
            // p.print_res_input(res_inputp2);
            Console.WriteLine(p.part1_res(res_inputp1));
            Console.WriteLine(p.part2_res(res_inputp1,res_inputp2));
        }

        List<List<string>> analyze_inputP1(string nameFile){
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

        List<List<string>> analyze_inputP2(string nameFile){
            // init of each var including regex
            
            string[] lines = System.IO.File.ReadAllLines(nameFile);
            List<List<string>> res_input = new List<List<string>>();
            Regex rgx4String = new Regex(@"([a-g]*[ ])*[|]");
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

        int part2_res(List<List<string>> res_inputp1,List<List<string>> res_inputp2){
           int final =0;
            for(int u = 0; u<res_inputp2.Count;u++){
                List<string> line = new List<string>();
                List<string> number = new List<string>();
                List<string> tmp_6 = new List<string>();
                List<string> tmp_5 = new List<string>();
                string tmp;
                for(int i=0;i<7;i++){
                    line.Add("");
                }
                for(int i=0;i<10;i++){
                    number.Add("");
                }
                foreach(string str in res_inputp2[u]){//we start the first findout
                    switch (str.Length){
                        case 2:
                            number[1]=str;
                        break;
                        case 4:
                            number[4]=str;
                        break;
                        case 3:
                            number[7]=str;
                        break;
                        case 7:
                            number[8]=str;
                        break;
                        case 5:
                            tmp_5.Add(str);
                        break;
                        case 6 :
                            tmp_6.Add(str);
                        break;
                        default:break;
                    }
                }
                line[0] += compare_plus_one(number[7],number[1]);
                //searching for line 3 and number 9
                foreach(string str in tmp_6){
                    char c = compare_plus_one(str,number[4]+line[0]);
                    if(c!='?'){
                        number[9]=str;
                        line[3]+=c;
                        tmp_6.Remove(str);
                        break;
                    }
                }
                foreach(string str in tmp_5){
                    char c = compare_plus_one(str,number[7]+line[3]);
                    if(c!='?'){
                        number[3]=str;
                        line[6]+=c;
                        tmp_5.Remove(str);
                        break;
                    }
                }
                line[5]+= compare_plus_one(number[9],number[3]);
                foreach(string str in tmp_5){
                    char c = compare_plus_one(str,line[0]+line[3]+line[5]+line[6]);
                    if(c!='?'){
                        number[5]=str;
                        line[2]+=c;
                        tmp_5.Remove(str);
                        number[2] = tmp_5[0];
                        break;
                    }
                }
                foreach(string str in tmp_6){
                    char c = compare_plus_one(str,number[7]+line[3]+line[4]+line[5]);
                        if(c!='?'){
                            number[0]=str;
                            
                            tmp_6.Remove(str);
                            number[6] = tmp_6[0];
                            break;
                    }

                }
                    
                line[1]+=compare_plus_one(number[1],line[2]);
                line[4]+= compare_plus_one(number[2],line[0]+line[1]+line[6]+line[3]);
                // Console.WriteLine("Line" );
                // foreach(string num in line){
                // Console.WriteLine(num);
                // }
                // Console.WriteLine("number");
                // foreach(string num in number){
                // Console.WriteLine(num);
                // }
                int final_number = 0;
                foreach(string end in res_inputp1[u]){
                    foreach(string num in number){
                    int o = compare(num,end,number);
                    if(o!=-1)final_number = final_number*10+o;

                    }                    
                }
                final += final_number;

            }
            return final;
        }

        int compare(string a,string b,List<string> number){//a is in number
            int count = 0;
            if(a.Length==b.Length){
                foreach(char i in a){
                    foreach(char j in b){
                        if(i==j)count++;
                    }
                }
                if(count == a.Length){
                    for(int i=0;i<number.Count;i++){
                        if(a == number[i])return i;
                    }
                    return -1;
                }
                else return -1;
            }
            else return -1;
        }

        char compare_plus_one(string a,string b){//to extract the plus one char
            int count =0;
            char tmp = new char() ;
            if(a.Length == b.Length +1){
                
                foreach(char i in a){
                    int flag =0;
                    foreach(char j in b){
                        if(i==j){
                            flag = 1;
                            break;
                        }
                    }
                    if(flag == 0){
                        tmp = i;
                        count++;
                    }
                }

            }
            if(count != 1){
                Console.WriteLine("Problem no plus one !");
                return '?';
            }
            else return tmp;
        }
    }
}
