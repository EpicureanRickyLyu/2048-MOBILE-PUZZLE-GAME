using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragUI : MonoBehaviour,IDragHandler, IPointerClickHandler,IPointerDownHandler
{
    private RectTransform ParentTF;
    private Vector3 offset;
    void Start()
    {
        ParentTF = this.transform.parent as RectTransform;
    }
    public void OnDrag(PointerEventData eventData)
    {
        // // eventData.position是屏幕坐标
        // // 仅使用overlay
        // this.transform.position = eventData.position; 
        // (parent RectTranform,scrennpoint,camera,out worldpoint)
        Vector3 worldpoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(transform.parent as RectTransform,eventData.position,eventData.pressEventCamera,out worldpoint);
        // 
        this.transform.position = worldpoint + offset;
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 worldpoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(ParentTF,eventData.position,eventData.pressEventCamera,out worldpoint);
        offset = this.transform.position - worldpoint;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // double click
        if(eventData.clickCount == 2)
        {
            Debug.Log("double click");
            print("double click");
            GetComponent<Image>().color = Color.red;
        }

    }

    
    
}
