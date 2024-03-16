using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody ballRb;
    private float xRange = 9.0f;
    private float ySpawnPos = 10.0f;
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, -4);
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
        }
        else if(collider.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        } 
    }
}
