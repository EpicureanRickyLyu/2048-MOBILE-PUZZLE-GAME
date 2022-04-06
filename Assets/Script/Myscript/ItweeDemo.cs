using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItweenDemo : MonoBehaviour
{
    public Transform imgtf,btnTF;
    public float movespeed = 100;
    public iTween.EaseType type;
    public void DoMovment()
    {
        iTween.MoveTo(imgtf.gameObject,btnTF.position,2f);
        iTween.MoveTo(imgtf.gameObject,iTween.Hash(
            "position",btnTF.position,
            "speed",movespeed,
            "easetype",type,
            "oncomplete","function1"
        ));
    }
    public void function1()
    {
        print("testitween");
    }
}
