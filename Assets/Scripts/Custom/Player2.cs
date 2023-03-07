using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
    }

    public void TakeDamage (float damage) {
        currentHealth -= damage;
        Debug.Log("damage: " + damage);
        
        if(currentHealth <= 0){
            Debug.Log("enemy dead");
            Destroy(gameObject);
        }
    }
}
