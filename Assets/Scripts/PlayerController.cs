using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(movingSpeed * Time.deltaTime * horizontalInput * Vector3.right);
        transform.Translate(movingSpeed * Time.deltaTime * verticalInput * Vector3.forward);
    }
}
