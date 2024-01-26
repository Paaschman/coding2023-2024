using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
public float gravityModifier;
public float jumpForce;
private Rigidbody playerRb;
public bool isOnGround=true;

    // Start is called before the first frame update
    void Start()
    {
Physics.gravity *= gravityModifier;
 
       playerRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)&& isOnGround){
playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
isOnGround = false;
    }
}
private void OnCollisionEnter(Collision collision) 
{
isOnGround = true; 
}

}
