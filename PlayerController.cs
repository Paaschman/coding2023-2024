using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8;
    private Rigidbody playerRb;
    public float forwardInput;
    private GameObject focalPoint;
    public bool hasPowerup;
    public float powerupStrength = 5;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody Lebron = collision.gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            Lebron.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);



    }
}
