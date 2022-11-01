using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float xBounds = 20;
    public float horizontalInput;
    public float horizontalSpeed = 10.0f;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player in the horizontal axis
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * horizontalSpeed);
        // Keeps the player inside the boundries
        if (transform.position.x < -xBounds) {
            transform.position = new Vector3(-xBounds, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBounds) {
            transform.position = new Vector3(xBounds, transform.position.y, transform.position.z);
        }
        // Checks if player is trying to shoot a projectile
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
