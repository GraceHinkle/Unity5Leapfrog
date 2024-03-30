using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private Text winnerText; // Reference to the text element displaying the winner

    public void DisplayWinner(string winnerName)
    {
        winnerText.text = "Winner: " + winnerName; // Display the winner's name
        gameObject.SetActive(true); // Show the UI for the end game
    }
}


// using UnityEngine;
// using UnityEngine.UI;

// public class EndGameManager : MonoBehaviour
// {
//     [SerializeField] private Text winnerText; // Reference to the text element displaying the winner

//     public void DisplayWinner(string winnerName)
//     {
//         winnerText.text = "Winner: " + winnerName; // Display the winner's name
//         gameObject.SetActive(true); // Show the UI for the end game
//     }
// }