using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Mouth mouth;
    public Text text;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.fillAmount = mouth.hunger / mouth.hungerThreshold;
        if(text != null)
            text.text = ""+((int)mouth.hunger);
    }
}
