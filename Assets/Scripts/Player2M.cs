using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class P2Control : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;
    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    private UIManager2 uiManager; // Reference to UIManager script
    private Timer timer; // Reference to Timer script
    private int score = 0; // Player's score
    public bool canScore;
    private bool canMove = true; // Flag to control player movement
    public float pushForce = 3.0f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        uiManager = FindObjectOfType<UIManager2>(); // Find UIManager2 in the scene
        timer = FindObjectOfType<Timer>(); // Find Timer in the scene
    }

    void Update()
    {
        if (!canMove)
            return; // If player cannot move, exit Update method

        float hInput = 0;
        float vInput = 0;

        if (Input.GetKey(KeyCode.W))
        {
            vInput = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            hInput = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            hInput = -1;
        }

        if (characterController.isGrounded)
        {
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            if (Input.GetKey(KeyCode.S))
            {
                canScore = true;
                moveVelocity.y = jumpSpeed;
            }
            else
            {
                canScore = false;
            }
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }

    // Method to check if the player is jumping
    public bool IsJumping()
    {
        return !characterController.isGrounded;
    }

    // Method to increment the player's score
    public void IncrementScore()
    {
        score++;
    }

    // Method to get the player's score
    public int GetScore()
    {
        return score;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Increment the player's score when colliding with a collectible item
            uiManager.AddScore(); // Call UIManager method to add score and update UI text
            Debug.Log("Player 2 collected an item! Score: " + score);

            // Destroy the collectible object
            Destroy(other.gameObject);
        }
    }

    // Method to disable player movement
    public void DisableMovement()
    {
        canMove = false;
    }
}

//     void OnControllerColliderHit(ControllerColliderHit hit) {
//         //contact = hit;
//         Rigidbody body = hit.collider.attachedRigidbody;
//         if (body != null && !body.isKinematic) {
//         body.velocity = hit.moveDirection * pushForce;
//         }
//     }
// }