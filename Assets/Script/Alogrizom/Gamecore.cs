using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


class Gamecore
{
    public enum MoveDirection:int
    {
        up,
        Down,
        Left,
        Right
    }
    public float score;
    public int[,] map;
    private int[] mergeArray;
    private int[] removeArray; 
    private System.Random random;
    public bool ischanged;
    private Vector2[,] PosRecord;
    public int[] movement;
    public int[,] moveMatrix;
    public Gamecore()
    {
        score = 0;
        map = new int[4,4]; 
        removeArray = new int[4];
        mergeArray = new int[5];
        moveMatrix = new int[5,5];
        movement = new int[5];
        locList = new List<Location>(16);
        random = new System.Random();
        ischanged = true;
    }
    private List<Location> locList;
    
    public void CalculateemptyList()
    {
        locList.Clear();
        for (int r = 0; r < map.GetLength(0); r++)
        {   
            for (int c = 0; c < map.GetLength(1); c++)
            {
                if(map[r,c] == 0)
                {
                    locList.Add(new Location(r,c));                    
                }
                
            }
            
        }

    }
    public void GenerateNum(out Location? loc,out int? number)
    {
    
        CalculateemptyList();
        if(locList.Count>0)
        {        
        int Index = random.Next(0,locList.Count);
        loc = locList[Index];
        number = map[loc.Value.RIndex,loc.Value.CIndex] = random.Next(0,10)==1?4:2;
        ischanged = true;
        }
        else
        {
            loc=null;
            number=null;   
            ischanged= false;
        }

    }
    public void ClearMap()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int o = 0; o < map.GetLength(1); o++)
            {
                map[i,o]=0;
                
            }
            
        }
    }
    private void Clear(int[] Array)
    {
        for (int i = 0; i <Array.Length; i++)
        {
            Array[i]=0;
        }
    }
    public void ClearDouble(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int o = 0; o < array.GetLength(1); o++)
            {
                
                
            }
            
        }
    }
    public void CalculatePos()
    {
       



    }
  
    private void RemoveZero()
    {
        Clear(removeArray);
        int index = 0;
        for (int i = 0; i < mergeArray.Length; i++)
        {   
            if(mergeArray[i]!=0)
            {               
                 removeArray[index++] = mergeArray[i];

            }
            movement[i] = i-index;  

               
        }
        removeArray.CopyTo(mergeArray,0);
    }
    public void Merge()
    {
        Clear(movement);
        RemoveZero();
        for (int i = 0; i < mergeArray.Length; i++)
        {
            if(mergeArray[i]!=0 && mergeArray[i]==mergeArray[i+1])
            {
                mergeArray[i]+=mergeArray[i+1];
                score +=mergeArray[i];
                mergeArray[i+1]=0;
            }           
        }
        RemoveZero();
    }
    public void MoveDown()
    {
        for (int c = 0; c < map.GetLength(1); c++)
        {
            for (int r = map.GetLength(0)-1; r >= 0; r--)
                mergeArray[3-r] = map[r,c];

            Merge();

            for (int r = map.GetLength(0)-1; r >= 0; r--)
                map[r,c] = mergeArray[3-r];
        }
    }
    public void MoveUp()
    {
        for (int c = 0; c < map.GetLength(1); c++)
        {
            for (int r = 0; r < map.GetLength(0); r++)
                mergeArray[r] = map[r,c];

            Merge();

            for (int r = 0; r < map.GetLength(0); r++)
                map[r,c] = mergeArray[r]; 
        }
    }
    public void MoveRight()
    {
        for (int r = 0; r < map.GetLength(0); r++)
        {
            for (int c = map.GetLength(1)-1; c >= 0; c--)
                mergeArray[3-c] = map[r,c];

            Merge();

            for (int c = map.GetLength(1)-1; c >= 0; c--)
                map[r,c] = mergeArray[3-c];
        }
    }
       public void MoveLeft()
    {
        for (int r = 0; r < map.GetLength(0); r++)
        {
            for (int c = 0; c < map.GetLength(1); c++)
            {
                mergeArray[c] = map[r,c];
            }
            Merge();
            for (int c = 0; c < map.GetLength(1); c++)
            {
                map[r,c] = mergeArray[c];
            }
            for (int c = 0; c < map.GetLength(1); c++)
            {
                moveMatrix[r,c]=movement[c];
            }
                
        }
    }


    public void Move(MoveDirection dic)
    {
        switch(dic)
        {
         case MoveDirection.up:
         MoveUp();
         break;
         case MoveDirection.Down:
         MoveDown();
         break;
         case MoveDirection.Left:
         MoveLeft();
         break;
         case MoveDirection.Right:
         MoveRight();
         break;
        }
    }
    
}
