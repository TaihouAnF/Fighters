using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashing : MonoBehaviour
{
    [Header("Subject To Observe")]
    [SerializeField] private PlayerInputManager playerInputManager;
    
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

    void OnDashing()
    {
        // Logic here, coroutine
        Debug.Log("Observer responds");
    }
}
