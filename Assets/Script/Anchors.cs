using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Anchors : MonoBehaviour
{
    Image img;
    public Vector2 heightwidth;
    public void Size()
    {
        // image size
        Vector2 heightwidth = img.rectTransform.sizeDelta;
        
    }
}
