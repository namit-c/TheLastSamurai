using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player: MonoBehaviour
{
    public CharacterController2D controller;
    public float maxHealth = 100f;
    public float currentHealth;
    private Animator anim;

    public bool killPlayer = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 50f;   
    }

    public void TakeDamage (float damage) {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Punch);
        currentHealth -= damage;
        
        if(currentHealth <= 0){
            // controller.death();
            // currentHealth = maxHealth;
            // the menu screen is index 0 in the build settings (will change to string later)
            // SceneManager.LoadScene(0);

            switchScenes();
        }
    }


    public void switchScenes(){
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)%4);
    }

}
