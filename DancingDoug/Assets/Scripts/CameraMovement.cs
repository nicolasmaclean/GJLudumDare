using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerManager target;
    public float cameraSpeed;
    public float mouseLookMax;
    public float mouseReach;
    public float yOffset;
    public bool lookAround;

    Vector2 targetPosition;
    void Update()
    {
        if(target.currentPlayer != null) {
            targetPosition = target.currentPlayer.position;
            
            if(lookAround) {
                Vector2 mousePos = Input.mousePosition;
                mousePos.x = Map(mousePos.x, 0, Screen.width, -1, 1);
                mousePos.y = Map(mousePos.y, 0, Screen.height, -1, 1);
                mousePos *= mouseReach;

                targetPosition += mousePos;
            }

            targetPosition = Vector2.Lerp(transform.position, targetPosition, cameraSpeed);
            transform.position = new Vector3(targetPosition.x, targetPosition.y + yOffset, transform.position.z);
        } else
            Debug.Log("AAAAAAAAAAAAAAAAAAA");


    }

    public static float Map(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
