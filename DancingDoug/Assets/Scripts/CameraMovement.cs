using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerManager target;

    void Update()
    {
        if(target.currentPlayer != null)
            transform.position = new Vector3(target.currentPlayer.position.x, target.currentPlayer.position.y, transform.position.z);
        else
            Debug.Log("AAAAAAAAAAAAAAAAAAA");
    }
}
