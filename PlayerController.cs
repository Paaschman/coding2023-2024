using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float fowardInput;

    // Start is called before the first frame update void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    horizontalInput = Input.GetAxis("Horizontal")
    fowardInput = Input.GetAxis("Vertical");
    // Moves the car foward based on vertical input
    transform.Translate(Vector3.foward * Time.deltaTime * speed * fowardInput);
    // Rotates the car based on horizontal input
    transform.Rotate(Vector3.up, turnSpeed * horizontalINput * Time.deltaTime);


        }
}
