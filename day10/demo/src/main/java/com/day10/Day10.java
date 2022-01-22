package com.day10;
import java.util.Scanner;
import java.io.*;
import java.util.*;

public class Day10 {
    File file ;
    Scanner sc;
    ArrayList<String> tab;

    Day10(String nameFile) throws Exception{
        file = new File(nameFile);
        sc = new Scanner(file);
        tab = new ArrayList<String>();
        while(sc.hasNextLine()){
            tab.add(sc.nextLine());
        }
    }
    // {1}(2)[3]<4>
    int resPartI(){
        ArrayList<Integer> listRes = new ArrayList<Integer>();
        for(String str : tab){

            ArrayList<Integer> gog = new ArrayList<Integer>();
            boolean flag = false;

            for(char c : str.toCharArray()){
                if(flag)break;
                int i = gog.size()-1;
                switch (c){
                    case '{':
                        gog.add(1);
                    break;
                    case '(':
                        gog.add(2);
                    break;
                    case '[':
                        gog.add(3);
                    break;
                    case '<':
                        gog.add(4);
                    break;
                    case '}':
                        if(gog.get(i)==1){
                            gog.remove(i);
                        }
                        else{
                            listRes.add(1197);
                            flag = true;
                        }
                    break;
                    case ')':
                        if(gog.get(i)==2){
                            gog.remove(i);
                        }
                        else {
                            listRes.add(3);
                            flag = true;
                        }
                    break;
                    case ']':
                        if(gog.get(i)==3){
                            gog.remove(i);
                        }
                        else{
                            listRes.add(57);
                            flag = true;
                        } 
                    break;
                    case '>':
                        if(gog.get(i)==4){
                            gog.remove(i);
                        }
                        else{
                            listRes.add(25137);
                            flag = true;
                        } 
                    break;
                    default:break;
                }
            }
            
        }
        int minal = 0;
        for(int i:listRes){
            minal += i;
        }
        return minal;
    }

    long resPartII(){ // use of long because int too short !!!
        ArrayList<Long> listRes = new ArrayList<Long>();
        for(String str : tab){
            ArrayList<Integer> listtmp = new ArrayList<Integer>();
            ArrayList<Integer> gog = new ArrayList<Integer>();
            boolean flag = false;

            for(char c : str.toCharArray()){
                if(flag)break;
                int i = gog.size()-1;
                switch (c){
                    case '(':
                    gog.add(1);
                    break;
                    case '[':
                    gog.add(2);
                    break;
                    case '{':
                        gog.add(3);
                    break;
                    case '<':
                        gog.add(4);
                    break;
                    case ')':
                    if(gog.get(i)==1){
                        gog.remove(i);
                    }
                    else{
                        flag = true;
                    }
                    break;
                    case ']':
                    if(gog.get(i)==2){
                        gog.remove(i);
                    }
                    else {
                        flag = true;
                    }
                    break;
                    case '}':
                        if(gog.get(i)==3){
                            gog.remove(i);
                        }
                        else{
                            flag = true;
                        } 
                    break;
                    case '>':
                        if(gog.get(i)==4){
                            gog.remove(i);
                        }
                        else{
                            flag = true;
                        } 
                    break;
                    default:break;
                }
            }
            if(!flag){

                while(gog.size()>0){
                    int i = gog.size()-1;
    
                    switch (gog.get(i)){
                        case 3:
                        listtmp.add(3);
                        gog.remove(i);
                        break;
                        case 1:
                        listtmp.add(1);
                        gog.remove(i);
                        break;
                        case 2:
                            listtmp.add(2);
                            gog.remove(i);
                        break;
                        case 4:
                            listtmp.add(4);
                            gog.remove(i);
                        break;
                    }
                }
                listRes.add((long)0);
                while(listtmp.size()!=0){
                    int i = listRes.size()-1;
                    Long u = (listRes.get(i)*5)+listtmp.get(0);
                    listRes.set(i,u);
                    listtmp.remove(0); 
                }
                
            }
            
        }
        // int mid = 0;
        System.out.println("before "+listRes.size());
        Collections.sort(listRes);
        System.out.println("after "+listRes.size());

        while(listRes.size()>1){
            listRes.remove(0);
            listRes.remove(listRes.size()-1);
        }
        for (long m  : listRes) {
            System.out.println(m);
            
        }
        return listRes.get(0);
    }

}
