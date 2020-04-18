using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public float hunger = 0;
    public float digestionSpeed = 5f;
    public float hungerThreshold = 100f;
    public bool canFeed = false;

    void Update() {
        hunger += digestionSpeed * Time.deltaTime;
        if(hunger > hungerThreshold)
            starvedToDeath();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        canFeed = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        canFeed = false;    
    }

    public void drinkMilk(float val)
    {
        hunger -= val;
        hunger = hunger < 0 ? 0 : hunger;
    }

    public void starvedToDeath()
    {

    }
}
