using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class P1Control : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;
    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    private int score = 0; // Player's score
    public bool canScore;
    //parameter contact;
    public float pushForce = 3.0f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hInput = 0;
        float vInput = 0;

        if (Input.GetKey(KeyCode.I))
        {
            vInput = 1;
        }
        if (Input.GetKey(KeyCode.L))
        {
            hInput = 1;
        }
        if (Input.GetKey(KeyCode.J))
        {
            hInput = -1;
        }

        if (characterController.isGrounded)
        {
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;

            if (Input.GetKey(KeyCode.K))
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

    void OnControllerColliderHit(ControllerColliderHit hit) {
        //contact = hit;
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic) {
        body.velocity = hit.moveDirection * pushForce;
        }
    }
}