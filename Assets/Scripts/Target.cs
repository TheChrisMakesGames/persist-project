using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 15.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -3.0f;
    private Rigidbody targetRb;
    public GameManager gameManager;
    public ParticleSystem explosionParticle;
    public int pointValue;
    public int livesAmount;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        }
    }

    
    private void OnTriggerEnter(Collider other)

    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1);
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

   float RandomTorque()
   {
        return Random.Range(-maxTorque, maxTorque) / 4;
   }

   Vector3 RandomSpawnPos()
   {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
   }
}
