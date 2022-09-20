using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject obstruction;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float spawnDelay = 2;
    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstruction", spawnDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstruction() {
        Instantiate(obstruction, spawnPos, obstruction.transform.rotation);
    }
}
