using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : MonoBehaviour
{
    public Transform TargetTF;
    public AudioSource btnsound;
    public void OnClick()
    {
        this.transform.root.GetComponent<AudioSource>().Play();
        iTween.MoveTo(this.gameObject,TargetTF.position,1f);

    }
}
