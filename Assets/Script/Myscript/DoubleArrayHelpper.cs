using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleArrayHelpper 
{
    public int[] GetElements(int[,] array,int rIndex,int cIndex,Direction dir,int count)
    {
        List<int> result = new List<int>(count);
        rIndex += dir.rIndex;
        cIndex += dir.cIndex;
        if(rIndex>=0&&rIndex<array.GetLength(0)&&cIndex>=0&&cIndex<array.GetLength(1))
        result.Add(array[rIndex,cIndex]);   
        return result.ToArray();

    }

}
