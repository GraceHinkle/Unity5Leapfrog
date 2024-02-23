using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
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
            player.IncrementScore();

            // Set triggered to true to prevent further activations
            triggered = true;

            // Print to the console
            Debug.Log(player.gameObject.name + " jumped over " + otherPlayer.gameObject.name + "! " + player.gameObject.name + "'s score: " + player.GetScore());
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ScoreTrigger : MonoBehaviour
// {
//     public P1Control player1;
//     public P2Control player2;

//     private bool triggered = false;
//     private bool scored = false; // New boolean to track whether a score has been awarded
//     private GameObject jumpingPlayer; // Track the player who is jumping

//     void OnTriggerEnter(Collider other)
//     {
//         if (triggered || scored)
//             return;

//         if (other.CompareTag("Player"))
//         {
//             if (other.GetComponent<P1Control>() != null)
//             {
//                 player1 = other.GetComponent<P1Control>();
//                 player2 = null;
//             }
//             else if (other.GetComponent<P2Control>() != null)
//             {
//                 player2 = other.GetComponent<P2Control>();
//                 player1 = null;
//             }

//             if (player1 != null)
//             {
//                 if (player2 != null && player2.IsJumping())
//                 {
//                     jumpingPlayer = other.gameObject;
//                     player1.IncrementScore();
//                     triggered = true;
//                     scored = true; // Set scored to true when a score is awarded
//                     Debug.Log(player1.gameObject.name + " jumped over " + player2.gameObject.name + "! " + player1.gameObject.name + "'s score: " + player1.GetScore());
//                 }
//             }
//             else if (player2 != null)
//             {
//                 if (player1 != null && player1.IsJumping())
//                 {
//                     jumpingPlayer = other.gameObject;
//                     player2.IncrementScore();
//                     triggered = true;
//                     scored = true; // Set scored to true when a score is awarded
//                     Debug.Log(player2.gameObject.name + " jumped over " + player1.gameObject.name + "! " + player2.gameObject.name + "'s score: " + player2.GetScore());
//                 }
//             }
//         }
//     }

//     // Reset scored flag when the player exits the trigger
//     void OnTriggerExit(Collider other)
//     {
//         if (other.gameObject == jumpingPlayer)
//         {
//             scored = false;
//             triggered = false;
//             jumpingPlayer = null;
//         }
//     }
// }