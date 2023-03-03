using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float movementSpeed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    public PowerUpType currentPowerUp = PowerUpType.None;
    public GameObject rocketPrefab;
    private GameObject tmpRocket;
    private Coroutine powerupCountdown;
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
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (currentPowerUp == PowerUpType.Rockets && Input.GetKeyDown(KeyCode.F)) {
            LaunchRockets();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            hasPowerup = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Debug.Log("Powerup = " + hasPowerup);
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            if(powerupCountdown != null) {
                StopCoroutine(powerupCountdown);
            }
            powerupCountdown = StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUp == PowerUpType.Pushback) {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Player collided with: " + collision.gameObject.name + " with powerup set to " + currentPowerUp.ToString());
        }
    }

    void LaunchRockets()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies) {
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up,
            Quaternion.identity);
            tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
        }
    }


    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        currentPowerUp = PowerUpType.None;
        Debug.Log("Powerup = " + hasPowerup);
        powerupIndicator.gameObject.SetActive(false);
    }
}
