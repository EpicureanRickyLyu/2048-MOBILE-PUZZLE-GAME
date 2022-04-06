using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteMotor : MonoBehaviour
{
    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }
    public void SetImage(int num)
    {

        img.sprite = ResourceManager.LoadSprites(num);
        
        
    }
    public void MoveSpirite(Vector3 direction)
    {

        iTween.MoveTo(this.gameObject,iTween.Hash(
            "Time",0.3f,
            "easetype",iTween.EaseType.linear,
            "position",direction
        ));


    }
    public void CreatEffect()
    {
        // small to big
        iTween.ScaleFrom(this.gameObject,Vector3.zero,0.3f);

    }
}
