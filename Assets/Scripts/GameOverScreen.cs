using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI winningPlayer;
    public TextMeshProUGUI score;
    
    public void Setup(int playerNum, int score1, int score2)
    {
        gameObject.SetActive(true);
        winningPlayer.text = "Player " + playerNum + " wins!";
        score.text = "Score: " + score1 + "-" + score2;
    }

    public void Rematch(){
        SceneManager.LoadScene(1);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
}
