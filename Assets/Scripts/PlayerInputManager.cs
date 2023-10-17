using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [Header("Reference")]
    public PlayerMovement playerMovement;

    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;
    private bool dashInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        HandleInput();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (dashInput)
        {
            // Call dash method coroutine
        }
    }

    void HandleInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        dashInput = Input.GetKey(KeyCode.LeftShift);
    }

    void MovePlayer()
    {
        playerMovement.Move(horizontalInput, verticalInput);
    }
}
