using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{
    public float roundDuration;
    private float timeLeft;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI playerOneScore;
    public TextMeshProUGUI playerTwoScore;

    public DumbFukChainManager playerOneDFCM;
    public DumbFukChainManager playerTwoDFCM;

    public GameObject gameEndPanel;
    public TextMeshProUGUI outcomeText;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (roundDuration > 0)
        {
            roundDuration -= Time.deltaTime;
            timeLeft = Mathf.Round(roundDuration);
            timerText.text = timeLeft.ToString("0");
            playerOneScore.text = playerOneDFCM.currentChainLength.ToString();
            playerTwoScore.text = playerTwoDFCM.currentChainLength.ToString();
        } else
        {
            timerText.text = "GAME END";
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
    }
}
