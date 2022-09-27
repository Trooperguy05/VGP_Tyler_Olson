using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float movementSpeed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * movementSpeed * forwardInput);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    private void OnColliderEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup){
            Debug.Log("a");
        }
    }
}
