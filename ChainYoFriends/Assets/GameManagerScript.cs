using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    public float roundDuration;
    private float timeLeft;

    public TextMeshProUGUI timerText;

    public List<TextMeshProUGUI> playerScore;
    public List<DumbFukChainManager> chainManagers;

    public GameObject gameEndPanel;
    public TextMeshProUGUI outcomeText;

    private bool gameHasEnded = false;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void endGame()
    {
        gameHasEnded = true;
        timerText.text = "GAME END";
        gameEndPanel.SetActive(true);

        int maxValue = 0;
        int maxIndex = -1;
        for (int i = 0; i < chainManagers.Count; i++)
        {
            if (chainManagers[i].currentChainLength > maxValue)
            {
                maxIndex = i;
                maxValue = chainManagers[i].currentChainLength;
            }
        }

        switch (maxIndex)
        {
            case 0:
                outcomeText.text = "Player One Wins!";
                break;
            case 1:
                outcomeText.text = "Player Two Wins!";
                break;
            case 2:
                outcomeText.text = "Player Three Wins!";
                break;
            case 3:
                outcomeText.text = "Player Four Wins!";
                break;
            case 4:
                outcomeText.text = "It's a draw!";
                break;
            default:
                outcomeText.text = "haha..";
                break;
        }
    }

    public void checkForLastPlayerAlive()
    {
        foreach (DumbFukChainManager dfm in chainManagers)
        {
            if (dfm.currentChainLength != 0)
            {
                return;
            }
        }

        endGame();
    }

    public void renderTimerAndScores()
    {
        if (roundDuration > 0)
        {
            roundDuration -= Time.deltaTime;
            timeLeft = Mathf.Round(roundDuration);
            timerText.text = timeLeft.ToString("0");

            for (int i = 0; i < chainManagers.Count; i++)
            {
                playerScore[i].text = "Player " + i.ToString() + ": " + chainManagers[i].currentChainLength.ToString();
            }
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
