using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    public float moveSpeed = 40f;

    float horizontalInput;
    bool jump;

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        jump = Input.GetKeyDown(KeyCode.Space);
        characterController.Move(horizontalInput * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void changeMaxJumps(int delta)
    {
        characterController.maxJumps += delta;
    }
}
