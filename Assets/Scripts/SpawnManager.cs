using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public float spawnPosX = 10;
    public float spawnPosY = 9;
    public float startDelay = 2;
    public float spawnInterval = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBalls", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBalls()
    {
       int ballIndex = Random.Range(0, ballPrefabs.Length);
       Vector3 spawnPos = new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY, -4.36f);

       Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
}
