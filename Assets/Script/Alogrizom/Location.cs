using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Location 
{
    public int RIndex{get;set;}
    public int CIndex{get;set;}
    // 结构体的构造要加个this()
    public Location(int r,int c):this()
    {
        this.RIndex = r;
        this.CIndex = c;
    }

}
