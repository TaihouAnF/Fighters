using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDashing : MonoBehaviour
{
    [Header("Subject To Observe")]
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private PlayerMovement playerMovement;

    [Header("Attribute")]
    public float dashSpeed;
    public float cooldown;
    public float dashTime;
    private float coolDownCounter;
    private float dashTimeCounter;
    private float lastSpeed;
    
    void Awake()
    {
        if (playerInputManager)
        {
            playerInputManager.ShouldDash += OnDashing;
        }
    }

    void OnDestroy()
    {
        if (playerInputManager) 
        {
            playerInputManager.ShouldDash -= OnDashing;
        }
    }

    private void Update()
    {
        if (coolDownCounter > 0)
        {
            coolDownCounter -= Time.deltaTime;
        } else if (coolDownCounter < 0)
        {
            coolDownCounter = 0;
        }
    }

    private void OnDashing()
    {
        // Logic here
        Debug.Log("Dashing Observer responds");

        if (coolDownCounter == 0 && dashTimeCounter == 0)
        {
            Debug.Log("Now Dashing");
            StartCoroutine(Dash());
        }
        else if (dashTimeCounter > 0)
        {
            Debug.Log("Dashing " + dashTimeCounter + " with speed " + playerMovement.moveSpeed);
        }
        else
        {
            Debug.Log("CoolDown " + coolDownCounter + " with speed " + playerMovement.moveSpeed);
        }
    }

    IEnumerator Dash()
    {
        lastSpeed = playerMovement.moveSpeed;
        // Dashing
        while (dashTimeCounter < dashTime)
        {
            playerMovement.moveSpeed = dashSpeed;
            dashTimeCounter += Time.deltaTime;
            yield return null;
        }
        // Cooldoan
        coolDownCounter = cooldown;
        dashTimeCounter = 0;
        playerMovement.moveSpeed = lastSpeed;
    }
}
