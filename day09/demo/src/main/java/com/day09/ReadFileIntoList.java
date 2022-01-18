package com.day09;

import java.util.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.*;
import java.io.*;
public class ReadFileIntoList
{
  public static List<String> readFileInList(String fileName)
  {
 
    List<String> lines = Collections.emptyList();
    try
    {
      lines =
       Files.readAllLines(Paths.get(fileName), StandardCharsets.UTF_8);
    }
 
    catch (IOException e)
    {
 
      // do something
      e.printStackTrace();
    }
    return lines;
  }
  public static void main(String[] args)
  {
    List l = readFileInList("~/Documents/code/AoC/AdventOfCode/day09/demo/src/main/java/com/day09/input.txt");
    // List l = readFileInList("~\\Documents\\code\\AoC\\AdventOfCode\\day09\\demo\\src\\main\\java\\com\\day09\\input.txt");

    // ~/Documents/code/AoC/AdventOfCode/day09
 
    Iterator<String> itr = l.iterator();
    while (itr.hasNext())
      System.out.println(itr.next());
  }
}