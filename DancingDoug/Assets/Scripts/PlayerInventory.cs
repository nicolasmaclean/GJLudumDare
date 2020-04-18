using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Mouth mouth;
    public Text milkText;
    public int milkCount = 0;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        updateMilkText();
    }

    void Update() {
        if(Input.GetButtonDown("Feed") && mouth.canFeed == true) {
            if(feedMilk())
                mouth.drinkMilk(30);
        }
        if(Input.GetButtonDown("Consume")) {
            consumeMilk();
        }
    }

    public void addMilk()
    {
        milkCount++;
        updateMilkText();
    }

    public bool consumeMilk()
    {
        if(milkCount > 0) {
            playerMovement.changeMaxJumps(1);
            milkCount--;
            updateMilkText();
            return true;
        }
        return false;
    }

    public bool feedMilk()
    {
        if(milkCount > 0) {
            milkCount--;
            updateMilkText();
            return true;
        }
        return false;
    }

    void updateMilkText()
    {
        milkText.text = "X " + milkCount;
    }
}
