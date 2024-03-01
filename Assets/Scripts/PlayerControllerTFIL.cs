using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTFIL : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRb;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;
    public AudioClip jumpSound;
    public float jumpForce;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward * forwardInput * speed);
        playerRb.AddForce(Vector3.right * horizontalInput * speed);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)  //&& !gameOver
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            //playerAnim.SetTrigger("Jump_trig");
            //playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
     if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
