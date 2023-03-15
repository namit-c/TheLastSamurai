using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public CharacterController2D_P2 controller;
    public float maxHealth = 100f;
    public float currentHealth;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
    }

    public void TakeDamage (float damage) {
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Punch);
        currentHealth -= damage;
        Debug.Log("damage: " + damage);
        
        if(currentHealth <= 0){
            controller.death();
            currentHealth = maxHealth;
            // the menu screen is index 1 in the build settings (will change to string later)
            SceneManager.LoadScene(1);
        }
    }
}
