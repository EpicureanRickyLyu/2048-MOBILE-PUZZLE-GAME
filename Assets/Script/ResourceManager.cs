using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    // 类加载时调用静态构造
    private static Dictionary<int,Sprite> spriteDic;
    private static float[] Array2048;
    static ResourceManager()
    {
        spriteDic = new Dictionary<int, Sprite>();
        var spriteArray = Resources.LoadAll<Sprite>("2048Image/2048");
        foreach (var item in spriteArray)
        {
            int intSpiriteName = int.Parse(item.name);
            spriteDic.Add(intSpiriteName,item);
            
        }
    }
    private void Calculate()
    {
        for (int i = 0; i < 11; i++)
        {
            Array2048[i] = jiecheng(2,i+1);
            
        }
    }
    public float jiecheng(float a,float b)
    {
        float x=a;
        for (int i = 0; i < b; i++)
        {
            a*=x;
        }
        return a;
    }
    public static Sprite LoadSprites(int num)
    {
        
       
        foreach (var item in spriteDic)
        {
            return spriteDic[num];
            
        }
        return null;
        
    }
}
