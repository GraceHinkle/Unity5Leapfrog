using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float duration = 60f; // Duration of the timer in seconds
    public Text timerText; // Reference to the text element displaying the timer

    public P1Control player1; // Reference to the specific instance of P1Control
    public P2Control player2; // Reference to the specific instance of P1Control

    private float timeRemaining; // Remaining time on the timer
    private bool isTimerRunning = false; // Flag to indicate if the timer is currently running

    private void Start()
    {
        StartTimer(); // Start the timer automatically when the game begins
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            // Update the remaining time
            timeRemaining -= Time.deltaTime;

            // Update the timer display
            UpdateTimerDisplay();

            // Check if the timer has reached zero
            if (timeRemaining <= 0)
            {
                // Stop the timer
                StopTimer();

                // Set the timer display to "00:00:00"
                timerText.text = "00:00:00";

                // Stop player1's movement
                player1.DisableMovement();

                // Stop player2's movement
                player2.DisableMovement();
            }
        }
    }

    public void StartTimer()
    {
        timeRemaining = duration;
        isTimerRunning = true;
        UpdateTimerDisplay();
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    private void UpdateTimerDisplay()
    {
        // Convert remaining time to hours, minutes, and seconds
        int hours = Mathf.FloorToInt(timeRemaining / 3600);
        int minutes = Mathf.FloorToInt((timeRemaining % 3600) / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Update the timer text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}

