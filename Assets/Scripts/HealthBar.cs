using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour
{
    public Player playerHealth;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // for emptying the health bar on 0 health
        if(slider.value <= slider.minValue){
            fillImage.enabled = false;
        }
        if(slider.value > slider.minValue && !fillImage.enabled){
            fillImage.enabled = true;
        }

        float fillValue = playerHealth.currentHealth/playerHealth.maxHealth;

        if(fillValue <= slider.maxValue/5){
            fillImage.color = Color.red;
        }
        else{
            fillImage.color = Color.green;
        }
        slider.value = fillValue;
    }
}
