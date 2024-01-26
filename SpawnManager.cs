using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos;
        public float startDelay = 2;
    private float repeatRate = 2;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, repeatRate);

    
}

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

}
