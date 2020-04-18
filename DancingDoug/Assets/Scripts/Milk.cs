using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collected Milk");
        other.GetComponent<PlayerInventory>().addMilk();

        Destroy(gameObject);
    }
}
