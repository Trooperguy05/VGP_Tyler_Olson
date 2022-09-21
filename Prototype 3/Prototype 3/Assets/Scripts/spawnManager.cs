using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject obstruction;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float spawnDelay = 2;
    private float repeatRate = 2;
    private playerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstruction", spawnDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstruction() {
        if (playerControllerScript.gameOver == false) {
            Instantiate(obstruction, spawnPos, obstruction.transform.rotation);
        }
    }
}
