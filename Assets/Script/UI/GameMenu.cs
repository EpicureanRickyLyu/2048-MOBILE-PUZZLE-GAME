using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMenu : MonoBehaviour,IDragHandler,IPointerDownHandler
{
    public GameController start;
    private Vector2 StartPoint;
    public GameObject MainMenu;
    public AudioSource btnsound;
    public void Restart()
    {
        btnsound = GetComponentInParent<AudioSource>();
        btnsound.Play();
        start.Restart();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StartPoint = eventData.position;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        Transform parenttf = this.GetComponentInParent<Canvas>().transform;
        print(parenttf);
        Vector2 offset = eventData.position -StartPoint;
        float x = Mathf.Abs(offset.x);
        float y = Mathf.Abs(offset.y);
        // 判断横竖长度，来判断拖拽方向。再根据offset大小
        if(x>y)
        {
    
            if(offset.x<0)
            {
                iTween.MoveTo(MainMenu.gameObject,iTween.Hash(
            "position",parenttf.position,
            "Time",1f,
            "oncomplete","Restart"
            ));
                
            }
        }
    }
}
