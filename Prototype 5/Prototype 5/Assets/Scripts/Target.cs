using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPosition = -6;
    private Rigidbody targetRb;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionFx;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPosition() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition);
    }
    private void OnMouseDown() {
        if (gameManager.isGameActive) {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")) {
            gameManager.GameOver();
        }
    }
}
