using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject ObstaclePrefab;
    private Vector3 SpwanPos = new Vector3(25, 0, 0);
    private float StartDelay = 2;
    private float RepeatRate = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(ObstaclePrefab, SpwanPos, ObstaclePrefab.transform.rotation);
    }
}
