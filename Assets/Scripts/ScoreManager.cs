using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager: MonoBehaviour
{
    static ScoreManager instance;
    public GameOverScreen gameOverScreen;
    static int score1 = 0;
    public TextMeshProUGUI score1Text;
    static int score2 = 0;
    public TextMeshProUGUI score2Text;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.SetActive(true);
        }
        // score1Text.text = "Rounds won: " + score1;
        // score2Text.text = "Rounds won: " + score2;
    }

    // Update is called once per frame
    public void UpdateScore(int playerNumber)
    {
        print("winning player: " + playerNumber);
        if(playerNumber == 1){
            score1 = score1 + 1;
            score1Text.text = "Rounds won: " + score1;
        }
        else{
            score2 = score2 + 1;
            score2Text.text = "Rounds won: " + score2;
        }
        Debug.Log("score 1: " + score1 + "     score2: " + score2);
    }

    public void ResetScore(int winningPlayer)
    {
        gameObject.SetActive(false);
        gameOverScreen.Setup(winningPlayer, score1, score2);
        score1 = 0;
        score2 = 0;
    }
}
