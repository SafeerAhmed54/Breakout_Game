using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public BallController ball;                     // Reference to the Ball script
    public TMP_Text player1ScoreText;     // Player 1 score display
    public TMP_Text player2ScoreText;     // Player 2 score display
    public TMP_Text winText;              // Win message text

    [Header("Game Settings")]
    public int maxScore = 5;              // Score needed to win

    private int player1Score = 0;
    private int player2Score = 0;

    void Start()
    {
        ResetGame();
    }

    // Called when a player scores
    public void PlayerScores(int playerNumber)
    {
        if (playerNumber == 1)
            player1Score++;
        else
            player2Score++;

        UpdateScoreUI();

        if (player1Score >= maxScore)
            EndGame(1);
        else if (player2Score >= maxScore)
            EndGame(2);
        else
            ResetBall();
    }

    private void UpdateScoreUI()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    private void EndGame(int winner)
    {
        winText.gameObject.SetActive(true);
        winText.text = $"Player {winner} Wins!";
        ball.gameObject.SetActive(false); // Stop the ball
    }

    private void ResetBall()
    {
        ball.ResetPosition(); // Ball script should handle its own reset
    }

    private void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateScoreUI();
        winText.gameObject.SetActive(false);
        ball.gameObject.SetActive(true);
        ResetBall();
    }
}
