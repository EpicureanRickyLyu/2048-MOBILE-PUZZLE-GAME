using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Transform Targerttf;
    private AudioSource btnsound;
    private GameMenu gamemenue;
    void Start()
    {
        
        btnsound = GetComponentInParent<AudioSource>();
        gamemenue = this.transform.root.GetComponentInChildren<GameMenu>();
        
    }
    public void OnStart()
    {
        print("1");
        iTween.MoveTo(this.gameObject,Targerttf.position,1f);
        btnsound.Play();
        gamemenue.Restart();
       

    }
     public void OnRank()
    {
        GameObject go = this.GetComponentInChildren<RankPanel>().gameObject;
        iTween.MoveTo(go,this.transform.position,1f);
         btnsound.Play();
        
    }
     public void OnExit()
    {
        Application.Quit();
         btnsound.Play();
        
    }
    void Update()
    {
        
    }
}
