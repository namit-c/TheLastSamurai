using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player: MonoBehaviour
{
    public CharacterController2D controller;
    public ScoreManager scoreManager;
    public float maxHealth = 100f;
    public float currentHealth;
    private Animator anim;

    public bool killPlayer = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100f;   
    }

    public void TakeDamage (float damage) {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Punch);
        currentHealth -= damage;
        
        if(currentHealth <= 0){
            // print("layer of object: " + gameObject.tag);
            int winningPlayer;
            print("tag: " + gameObject.tag);
            if(gameObject.tag == "Player1"){
                winningPlayer = 2;
            }
            else{
                winningPlayer = 1;
            }
            scoreManager.UpdateScore(winningPlayer);
            
            if(SceneManager.GetActiveScene().buildIndex != 3){
                switchScenes();
            }
            else{
                scoreManager.ResetScore(winningPlayer);
            }
        }
    }


    public void switchScenes(){
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%4);
    }

}
