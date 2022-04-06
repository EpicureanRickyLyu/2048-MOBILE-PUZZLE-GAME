using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameController:MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    private Gamecore core;
    private SpriteMotor[,] spriteActionArray;
    private Vector2 Startpoint;
    private bool ischanged;
    public TextMeshProUGUI score;
    private string num;

    private AudioSource btnsound;
 
    void Awake()
    {
        spriteActionArray = new SpriteMotor[4,4];
    }
       public void OnPointerDown(PointerEventData eventData)
    {
        Startpoint = eventData.position;
        btnsound.Play();

    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset = eventData.position -Startpoint;
        float x = Mathf.Abs(offset.x);
        float y = Mathf.Abs(offset.y);
        // 判断横竖长度，来判断拖拽方向。再根据offset大小
        if(x>y)
        {
            if(offset.x>0)
            {
                core.MoveRight();
              
            }
            if(offset.x<0)
            {
                core.MoveLeft();
              
            }
        }
        if(x<y)
        {
            if(offset.y>0)
            {
                core.MoveUp();
              
            }
            if(offset.y<0)
            {
                core.MoveDown();
               
            }
        }
       
    }
    public void OnPointerUp(PointerEventData eventData)
    {
          GenerateNumber(); 
    }
    void Start()
    {
        btnsound = GetComponentInParent<AudioSource>();
        Init();
        core = new Gamecore();   
        GenerateNumber();     
        GenerateNumber();    
        
    }
    public void ClearAll()
    {
         for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);   
        }
    }
    public void Restart()
    {
        ClearAll();
        core.ClearMap();
        Init();
        GenerateNumber();
        GenerateNumber();
         
        
    }
    private void GenerateNumber()
    {
        Location? loc;
        int? number;
        core.GenerateNum(out loc,out number);
        spriteActionArray[loc.Value.RIndex,loc.Value.CIndex].SetImage(number.Value);
        spriteActionArray[loc.Value.RIndex,loc.Value.CIndex].CreatEffect();
        
    }
    private void Init()
    {

        for (int i = 0; i < 4; i++)
        {
            for (int o = 0; o < 4; o++)
        {
            CreateSprite("image",i,o);
            
        }
            
        }
    }

    private void CreateSprite(string s,int a,int b)
    {
        GameObject go = new GameObject(s+a.ToString()+b.ToString());
        go.AddComponent<Image>();
     
        SpriteMotor Spritemotor = go.AddComponent<SpriteMotor>();
        spriteActionArray[a,b] = Spritemotor;
        Spritemotor.SetImage(0);
        // false use local axis
        go.transform.SetParent(this.transform,false);
       
    }
    private void UpdateMap()
    {
        
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                spriteActionArray[r,c].SetImage(core.map[r,c]);
                
            }
            
        }
    }
    public Vector3 calculatePos(int movement,int r,int c,int direct)
    {
        Vector3 pos = Vector3.zero;
         switch(direct)
        {
            case 0:
            pos =spriteActionArray[r,c-movement].transform.position;
            break;
            case 1:
            pos =spriteActionArray[r,c+movement].transform.position;
            break;
            case 2:
            pos =spriteActionArray[r-movement,c].transform.position;
            break;
            case 3:
            pos =spriteActionArray[r+movement,c].transform.position;
            break;

        }
      return pos;

    }
    private void MoveMap(int direct)
    {
         for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                if(core.map[r,c]!=0)
                {
                    spriteActionArray[r,c].MoveSpirite(calculatePos(core.moveMatrix[r,c],r,c,direct));
                }
                
            }
            
        }
        
    }
    public void Play()
    {
       if(Input.GetKeyDown(KeyCode.UpArrow))
       {
           btnsound.Play();
        //   MoveMap(0); 
          core.MoveUp();   
          GenerateNumber();        
       }
       if(Input.GetKeyDown(KeyCode.DownArrow))
       {
           btnsound.Play();
        //    MoveMap(1);
           core.MoveDown();
           GenerateNumber();
       }
       if(Input.GetKeyDown(KeyCode.LeftArrow))
       {
           btnsound.Play();
           core.MoveLeft();
        //    MoveMap(2);
           GenerateNumber();
         
       }
       if(Input.GetKeyDown(KeyCode.RightArrow))
       {
           btnsound.Play();
        //    MoveMap(3);
           core.MoveRight();
           GenerateNumber();
           
       }

      UpdateMap();

    }
    public void GameOver()
    {
        print("gameover");
        Transform tf = this.transform.root.GetComponentInChildren<GameOverPanel>().transform;
        iTween.ScaleTo(tf.gameObject,new Vector3(1,1,1),1f);
    }
    void Update()
    {
        Play();
        score.GetComponent<TextMeshProUGUI>().text = core.score.ToString();
        if(core.ischanged == false)
        {
            GameOver();
        }
     
    
       
    }
}
