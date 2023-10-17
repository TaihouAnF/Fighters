using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Attributes")]
    public float moveSpeed;
    public float accelarateRate;    // Might use this for future, when pick up some boost

    public void Move(float horizontalInput, float verticalInput)
    {
        transform.Translate(moveSpeed * Time.deltaTime * horizontalInput * Vector3.right);
        transform.Translate(moveSpeed * Time.deltaTime * verticalInput * Vector3.forward);
    }
}
