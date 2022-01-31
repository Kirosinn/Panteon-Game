using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float speed = 6;
    public float rotationSpeed;
    public float jumpForce = 10;
    public bool isOnGround;
    public bool gameOver;
    public float gravityModifier;
    private Rigidbody playerRb;
    private Animator playerAnim;

    [SerializeField] public Transform player;
    [SerializeField] public Transform respawnPoint;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (gameOver == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            //Karakterin 720 derece ile hareket etmesi 
            Vector3 movementDirection = new Vector3(-horizontalInput, 0, -verticalInput);
            movementDirection.Normalize();

            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);



            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                playerAnim.SetTrigger("Running");
                //Koşu Animasyonu

            }
            else
            {
                playerAnim.SetTrigger("Idle");
                //Duraksama Animasyonu
            }

            //Jump ve Jump animasyonu
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump");
            }
        }


    }
    //Eğer yerle temas ederse karakter zıplayabilir ama tam tersi şekilde zıplayamaz.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameOver = true;

            playerAnim.gameObject.GetComponent<Animator>().enabled = false;
            playerAnim.SetTrigger("Idle");
        }

    }
    //Engele çarptığında respawn pointe geri dönme
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            player.transform.position = respawnPoint.transform.position;
        }

    }



}


