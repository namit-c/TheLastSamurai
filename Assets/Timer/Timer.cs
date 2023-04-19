using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;

    [Header("Limit Settings")]
    public float timerLimit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      currentTime = currentTime -= Time.deltaTime;

      if (currentTime <= timerLimit){
        currentTime = timerLimit;
        timerText.text = currentTime.ToString("0");
        timerText.color = Color.red;
        SceneManager.LoadScene(0);
      }
      float min = Mathf.FloorToInt(currentTime/60);
      float seconds = Mathf.FloorToInt(currentTime%60);
      timerText.text = string.Format("{0:00}:{1:00}", min, seconds);
    }
}
