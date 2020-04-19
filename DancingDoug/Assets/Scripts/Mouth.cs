using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public float hunger = 0;
    public float digestionSpeed = 5f;
    public float hungerThreshold = 100f;
    public bool canFeed;

    void Update() {
        hunger += digestionSpeed * Time.deltaTime;
        if(hunger > hungerThreshold)
            starvedToDeath();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.isTrigger) return;
        canFeed = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.isTrigger) return;
        canFeed = false;    
    }

    public void drinkMilk(float val)
    {
        hunger -= val;
        if(hunger < 0)
            hunger = 0;
    }

    public void starvedToDeath()
    {

    }
}
