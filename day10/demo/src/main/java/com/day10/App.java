package com.day10;

import java.io.Console;
import java.io.*;
import java.util.*;
/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args ) throws Exception
    {
        boolean debug = false;
        // System.out.println( "Hello World!" );
        Day10 p = new Day10("src/main/java/com/day10/input.txt");
        if(debug){
            for (String string : p.tab) {
                System.out.println(string);
                
            }

        }

        System.out.println("Part I : "+p.resPartI());
        System.out.println("Part II : "+p.resPartII());

        
    }
}
