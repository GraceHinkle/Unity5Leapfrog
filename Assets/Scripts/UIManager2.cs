using UnityEngine;
using UnityEngine.UI; // Import Unity UI namespace

public class UIManager2 : MonoBehaviour
{
    [SerializeField]
    private Text _p2Score;

    [SerializeField]
    private Text _winner;

    private int _score = 0; // Player's score

    // Start is called before the first frame update
    void Start()
    {
        // Initialize UI text with starting score
        UpdateScoreText();

        // Initially hide the winner text
        _winner.gameObject.SetActive(false);
    }

    // Method to update the score text on the UI
    private void UpdateScoreText()
    {
        _p2Score.text = "P2 Score: " + _score.ToString(); // Convert score to string and update text

        // Check if the player has won
        if (_score >= 5)
        {
            ShowWinnerText(); // Show "You Win" text
        }
    }

    // Method to add score and update UI text
    public void AddScore()
    {
        _score++; // Increment score
        UpdateScoreText(); // Update UI text
    }

    private void ShowWinnerText()
    {
        _winner.gameObject.SetActive(true); // Set winner text to active, making it visible
    }
}
