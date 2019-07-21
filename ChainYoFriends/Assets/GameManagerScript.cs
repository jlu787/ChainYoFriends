using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour
{
    public float roundDuration;
    private float timeLeft;

    public Text timerText;
    public Text playerOneScore;
    public Text playerTwoScore;

    public DumbFukChainManager playerOneDFCM;
    public DumbFukChainManager playerTwoDFCM;

    public GameObject gameEndPanel;
    public Text outcomeText;

    private bool gameHasEnded = false;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void endGame()
    {
        gameHasEnded = true;
        timerText.text = "";
        gameEndPanel.SetActive(true);
        if (playerOneDFCM.currentChainLength > playerTwoDFCM.currentChainLength)
        {
            outcomeText.text = "Player One Wins!";
        }
        else if (playerOneDFCM.currentChainLength < playerTwoDFCM.currentChainLength)
        {
            outcomeText.text = "Player Two Wins!";

        }
        else
        {
            outcomeText.text = "It's a draw!";

        }
    }

    public void checkForLastPlayerAlive()
    {
        if (playerOneDFCM.currentChainLength == 0 || playerTwoDFCM.currentChainLength == 0)
        {
            endGame();
        }
    }

    public void renderTimerAndScores()
    {
        if (roundDuration > 0)
        {
            roundDuration -= Time.deltaTime;
            timeLeft = Mathf.Round(roundDuration);
            timerText.text = timeLeft.ToString("0");
            playerOneScore.text = playerOneDFCM.currentChainLength.ToString();
            playerTwoScore.text = playerTwoDFCM.currentChainLength.ToString();
        }
        else
        {
            endGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameHasEnded)
        {
            renderTimerAndScores();
            checkForLastPlayerAlive();
        }


        
    }
}
