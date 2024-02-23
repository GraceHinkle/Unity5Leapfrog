using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger2 : MonoBehaviour
{
    public P2Control player; // Reference to the player whose score will be incremented when jumping over the other player

    // Keep track of whether this trigger has been activated
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger has already been activated or if the other collider is not a player
        if (triggered || !other.CompareTag("Player"))
        {
            return;
        }

        // Get the P1Control component of the other player
        P1Control otherPlayer = other.GetComponent<P1Control>();

        // Check if the other player is jumping and the player is eligible to score
        if (otherPlayer.IsJumping() && player.canScore)
        {
            // Increment the score of the player associated with this trigger
            player.IncrementScore();

            // Set triggered to true to prevent further activations
            triggered = true;

            // Print to the console
            Debug.Log(player.gameObject.name + " jumped over " + otherPlayer.gameObject.name + "! " + player.gameObject.name + "'s score: " + player.GetScore());
        }
    }
}
