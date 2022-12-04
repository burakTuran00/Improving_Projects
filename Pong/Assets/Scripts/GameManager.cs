using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public Ball ball;
    private int playerScore = 0;
    private int computerScore = 0;

    public Text playerText;
    public Text computerText;
    public void PlayerScore()
    {
        playerScore++;
        playerText.text = playerScore.ToString();
        ResetRound();
    }

    public void ComputerScore()
    {
        computerScore++;
        computerText.text = computerScore.ToString();
        ResetRound();
    }
    private void ResetRound()
    {
        playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

}
