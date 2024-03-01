using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        
        if(transform.position.x < -9)
        {
            transform.position = new Vector3(-9, 0.8f, -4);
        }
        if(transform.position.x > 9)
        {
            transform.position = new Vector3(9, 0.8f, -4);
        }
    }

    
}
