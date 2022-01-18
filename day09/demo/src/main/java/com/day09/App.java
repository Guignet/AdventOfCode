package com.day09;
import java.io.*;
import java.util.*;
// import java.io.File;
import java.util.Scanner;
/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args ) throws Exception
    {
        
        boolean debug = false;
        day09 p1 = new day09("demo/src/main/java/com/day09/input.txt");
        if(debug){
            ArrayList<ArrayList<Integer>> input = p1.tab;
            while (p1.sc.hasNextLine())
             System.out.println(p1.sc.nextLine());
    
            for(ArrayList<Integer> list : input){
                for(int a : list){
                    System.out.print(" " + a);
                }
                System.out.print("\n");
            }
    
            ArrayList<Integer> res_p1 = p1.listOfSmaller();
            for(int a:res_p1){
                System.out.print(" small " + a);
    
            }
            System.out.println();
            System.out.println("basins :");
            for(ArrayList<Integer> list : p1.basins){
                for(int a : list){
                    System.out.print(" " + a);
                }
                System.out.print("\n");
            }

        }

        System.out.println("Part I : Risk = "+p1.calcRisk(p1.listOfSmaller())); // 528
        System.out.println("Part II : Basins = "+p1.res_PartII()); // 528


    }
}
