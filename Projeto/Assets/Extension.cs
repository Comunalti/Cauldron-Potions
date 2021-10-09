using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extension
{
    public static T GetRandom<T>(this IEnumerable<T> current)
    {
        return current.ElementAt(Random.Range(0, current.Count()));
    }
    
    public static int Factorial(this int f)
    {
        if(f == 0)
            return 1;
        else
            return f * Factorial(f-1); 
    }
    
    public static void SwapValues<T>(this T[] source, int index1, int index2)
    {
        var size = source.Length;

        index1 %= size;
        index2 %= size;
        
        (source[index1], source[index2]) = (source[index2], source[index1]);
    }
    
}