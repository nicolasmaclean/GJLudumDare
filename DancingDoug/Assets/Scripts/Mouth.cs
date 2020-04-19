using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public float hunger = 0;
    public float digestionSpeed = 5f;
    public float hungerThreshold = 100f;
    public bool canFeed;
    public PlayerManager playerManager;
    public Transform eyes;
    public float maxLookDistance;

    public Vector2 targetPosition;

    void Update() {
        hunger += digestionSpeed * Time.deltaTime;
        if(hunger > hungerThreshold)
            starvedToDeath();

        if(eyes != null)
            lookAtPlayer();
    }

    void lookAtPlayer()
    {
        Vector2 look = new Vector2(playerManager.currentPlayer.position.x - eyes.position.x, playerManager.currentPlayer.position.y - eyes.position.y + .15f);
        look = Vector2.ClampMagnitude(look, maxLookDistance);

        targetPosition = look;
        eyes.localPosition = Vector2.Lerp(eyes.localPosition, targetPosition, .1f);
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
