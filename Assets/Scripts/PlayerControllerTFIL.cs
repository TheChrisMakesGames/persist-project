using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTFIL : MonoBehaviour
{
    public float speed;
    public float JumpVerticalSpeed = 6.0f;
    public GameObject player;
    private Rigidbody playerRb;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    bool leftIntent, rightIntent;

    [Tooltip( "Lateral walk speed.")]
	public float LateralSpeed = 5.0f;
	[Tooltip( "Lateral walk acceleration.")]
	public float LateralAcceleration = 20.0f;

    public bool Jump;
    private Animator playerAnim;
    public AudioClip jumpSound;
    public float jumpForce;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)  //&& !gameOver
        {
            Jump = true;
            //playerAnim.SetTrigger("Jump_trig");
            //playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if(transform.position.z > 250)
        {
            transform.position = new Vector3(0, 0, 250);
        }

        if(transform.position.z < -250)
        {
            transform.position = new Vector3(0, 0, -250);
        }

        if(transform.position.x > 250)
        {
            transform.position = new Vector3(250, 0, 0);
        }

        if(transform.position.x < -250)
        {
            transform.position = new Vector3(-250, 0, 0);
        }
    }

    

    void FixedUpdate() 
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * forwardInput * speed);
        playerRb.AddForce(Vector3.right * horizontalInput * speed);

        MakePlayerJump();
    }

     void OnCollisionEnter(Collision collision)
        {
        if(collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }

        if(collision.gameObject.CompareTag("Platform"))
            {
                isOnGround = true;
            }
        }

    void MakePlayerJump()
    {
        //isOnGround = false;
        if(Jump == true)
            {
                playerRb.velocity = new Vector3(0, 10, 0) * gravityModifier;
            }

    }

}

