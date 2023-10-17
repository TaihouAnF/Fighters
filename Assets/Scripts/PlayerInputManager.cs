using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [Header("Reference")]
    public PlayerMovement playerMovement;
    public PlayerDashing playerDashing;

    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;
    private bool dashInput;

    public event Action ShouldDash;

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
        #region Moving

        MovePlayer();

        #endregion

        #region Dashing

        if (dashInput)
        {
            // Call dash method coroutine, use observer pattern here
            Dashing();
        }

        #endregion
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

    public void Dashing()
    {
        ShouldDash?.Invoke();
    }
}
