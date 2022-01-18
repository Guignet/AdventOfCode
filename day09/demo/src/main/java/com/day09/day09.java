package com.day09;
import java.util.Scanner;
import java.io.*;
import java.util.*;

public class day09 {
    File file ;
    Scanner sc ;
    int MAX = Integer.MAX_VALUE;
    ArrayList<ArrayList<Integer>> tab;
    ArrayList<ArrayList<Integer>> basins;

    
    day09(String nameFile) throws Exception{
        file = new File(nameFile);
        sc = new Scanner(file);
        tab = fileToTab();
        basins = init_basins();
    }

    ArrayList<ArrayList<Integer>> fileToTab(){
        ArrayList<ArrayList<Integer>> res = new ArrayList<ArrayList<Integer>>();
        while(sc.hasNextLine()){
            String tmp = sc.nextLine();
            ArrayList<Integer> list = new ArrayList<Integer>();
            for(int i=0;i<tmp.length();i++){
                Integer a = Character.getNumericValue(tmp.charAt(i));
                list.add(a);
                //System.out.println(a);

            }
            res.add(list);
        }
        // sc.close();
        return res;

    }

    ArrayList<Integer> listOfSmaller(){
        ArrayList<Integer> res = new ArrayList<Integer>();
        for(int i=0;i<tab.size();i++){
            for(int j=0;j<tab.get(i).size();j++){
                int center = tab.get(i).get(j);
                if(i!=0&&i!=tab.size()-1){
                    if(j!=0&&j!=tab.get(i).size()-1){
                        int up = tab.get(i-1).get(j);
                        int left = tab.get(i).get(j-1);
                        int right = tab.get(i).get(j+1);
                        int down = tab.get(i+1).get(j);
                        if((up>center)&&(down>center)&&(left>center)&&(right>center)){res.add(center);}
                    }
                    else if(j==0){
                        int up = tab.get(i-1).get(j);
                        // int left = tab.get(i).get(j-1);
                        int right = tab.get(i).get(j+1);
                        int down = tab.get(i+1).get(j);
                        if((up>center)&&(down>center)&&(right>center)){res.add(center);}

                    }
                    else{
                        int up = tab.get(i-1).get(j);
                        int left = tab.get(i).get(j-1);
                        // int right = tab.get(i).get(j+1);
                        int down = tab.get(i+1).get(j);
                        if((up>center)&&(down>center)&&(left>center)){res.add(center);}


                    }
                } 
                else if(i==0){
                    if(j!=0&&j!=tab.get(i).size()-1){
                        // int up = tab.get(i-1).get(j);
                        int left = tab.get(i).get(j-1);
                        int right = tab.get(i).get(j+1);
                        int down = tab.get(i+1).get(j);
                        if((down>center)&&(left>center)&&(right>center)){res.add(center);}
                    }
                    else if(j==0){
                        // int up = tab.get(i-1).get(j);
                        // int left = tab.get(i).get(j-1);
                        int right = tab.get(i).get(j+1);
                        int down = tab.get(i+1).get(j);
                        if((down>center)&&(right>center)){res.add(center);}

                    }
                    else{
                        // int up = tab.get(i-1).get(j);
                        int left = tab.get(i).get(j-1);
                        // int right = tab.get(i).get(j+1);
                        int down = tab.get(i+1).get(j);
                        if((down>center)&&(left>center)){res.add(center);}


                    }

                } 
                else{
                    if(j!=0&&j!=tab.get(i).size()-1){
                        int up = tab.get(i-1).get(j);
                        int left = tab.get(i).get(j-1);
                        int right = tab.get(i).get(j+1);
                        // int down = tab.get(i+1).get(j);
                        if((up>center)&&(left>center)&&(right>center)){res.add(center);}
                    }
                    else if(j==0){
                        int up = tab.get(i-1).get(j);
                        // int left = tab.get(i).get(j-1);
                        int right = tab.get(i).get(j+1);
                        // int down = tab.get(i+1).get(j);
                        if((up>center)&&(right>center)){res.add(center);}

                    }
                    else{
                        int up = tab.get(i-1).get(j);
                        int left = tab.get(i).get(j-1);
                        // int right = tab.get(i).get(j+1);
                        // int down = tab.get(i+1).get(j);
                        if((up>center)&&(left>center)){res.add(center);}


                    }

                }  

            }
        }
        return res;
    }

    int calcRisk(ArrayList<Integer> Smaller){
        int res = 0;
        for (int a : Smaller) {
            res += a +1 ;
        }

        return res;
    }

    ArrayList<ArrayList<Integer>> init_basins(){
        ArrayList<ArrayList<Integer>> res = new ArrayList<ArrayList<Integer>>();
        for(ArrayList<Integer> line : tab ){
            ArrayList<Integer> tmp = new ArrayList<Integer>();
            for(int a : line){
                if(a==9)tmp.add(0);
                else tmp.add(1);
            }
            res.add(tmp);
        }  
        return res;
    }

    int res_PartII(){
        ArrayList<Integer> basinSize = new ArrayList<Integer>();
        for(int i=0;i<basins.size();i++){
            for(int j=0;j<basins.get(i).size();j++){
                basinSize.add(rec_basins(i, j));
            }
        }

        int first=0,second=0,third=0;
        for(int a : basinSize){
            if(a>=first){
                third = second;
                second = first;
                first = a;
            }else{
                if(a>=second){
                    third = second;
                    second = a;
                }
                else{
                    if(a>third)third=a;
                }
            }
        }

        return first*second*third;
    }

    int rec_basins(int i,int j){
        if(basins.get(i).get(j)==0){
            return 0;            
        }
        else{
            basins.get(i).set(j, 0);
            if(i!=0&&i!=basins.size()-1){
                if(j!=0&&j!=basins.get(i).size()-1){
                    return 1+rec_basins(i-1, j)+rec_basins(i+1, j)+ rec_basins(i, j-1)+rec_basins(i, j+1);
                }
                else if(j==0){
                    return 1+rec_basins(i-1, j)+rec_basins(i+1, j)+rec_basins(i, j+1);
                    

                }
                else{
                    return 1+rec_basins(i-1, j)+rec_basins(i+1, j)+ rec_basins(i, j-1);
                    


                }
            } 
            else if(i==0){
                if(j!=0&&j!=basins.get(i).size()-1){
                    return 1+rec_basins(i+1, j)+ rec_basins(i, j-1)+rec_basins(i, j+1);            
                }
                else if(j==0){
                    return 1+rec_basins(i+1, j)+rec_basins(i, j+1);
                }
                else{
                    return 1+rec_basins(i+1, j)+ rec_basins(i, j-1);
                }

            } 
            else{
                if(j!=0&&j!=tab.get(i).size()-1){
                    return 1+rec_basins(i-1, j)+ rec_basins(i, j-1)+rec_basins(i, j+1);
                    
                }
                else if(j==0){
                    return 1+rec_basins(i-1, j)+rec_basins(i, j+1);
                    

                }
                else{
                    return 1+rec_basins(i-1, j)+ rec_basins(i, j-1);
                }

            }
            
        }
    }
}
