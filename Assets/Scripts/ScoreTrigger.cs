using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public UIManager uiManager; // Reference to UIManager script
    public P1Control player; // Reference to the player whose score will be incremented when jumping over the other player

    // Keep track of whether this trigger has been activated
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger has already been activated or if the other collider is not a player
        if (triggered || !other.CompareTag("Player"))
        {
            return;
        }

        // Get the P2Control component of the other player
        P2Control otherPlayer = other.GetComponent<P2Control>();

        // Check if the other player is jumping and the player is eligible to score
        if (otherPlayer.IsJumping() && player.canScore)
        {
            // Increment the score of the player associated with this trigger
            uiManager.AddScore(); // Call UIManager method to add score and update UI text

            // Set triggered to true to prevent further activations
            triggered = true;

            // Print to the console
            Debug.Log(player.gameObject.name + " jumped over " + otherPlayer.gameObject.name + "! " + player.gameObject.name + "'s score: " + player.GetScore());
        }
    }

    // Reset the triggered flag when the player exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = false;
        }
    }
}