using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction 
{

    // struct Direct
    // {
    //     public int rindex;
    //     public int cindex;

    //     public void Up()
    //     {

    //     }

    // }
    // Direct direction;
    public int rIndex{get;set;}
    public int cIndex{get;set;}
    public Direction(int rIndex, int CIndex)
    {
        this.rIndex = rIndex;this.cIndex = CIndex;
    }
    public static Direction Up
    {
        get{return new Direction(-1,0);}
    }
    public static Direction Down
    {
        get{return new Direction(1,0);}
    }
    public static Direction Left
    {
        get{return new Direction(0,-1);}
    }
    public static Direction Right
    {
        get{return new Direction(0,1);}
    }

}
