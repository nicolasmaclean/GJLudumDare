using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public RectTransform fillTarget;
    public Mouth mouth;
    public float width;

    float currentValue;
    float minValue = 0;
    float maxValue;

    void Awake()
    {
        maxValue = mouth.hungerThreshold;    
    }

    void Update() {
        currentValue = mouth.hunger;
        // updateGFX();
        GetComponent<Text>().text = "" + (int)currentValue;
    }

    void updateGFX()
    {
        // fillTarget.right = maxValue-currentValue*(width/maxValue);
    }
}
