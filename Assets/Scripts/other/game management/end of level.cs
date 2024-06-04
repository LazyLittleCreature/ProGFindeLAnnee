using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class endOfLevel : MonoBehaviour
{ 
    public bool GameOn = true;
    private bool bigPlayerWin = false;
    private bool smallPlayerWin = false;
    [SerializeField] private Canvas canvas;
    // ----
    public TextMeshProUGUI scoreText;
    private int timeInSecs;
    // Score
    
    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        // ----
        if (GameOn)
        {
            timeInSecs = Mathf.FloorToInt(Time.timeSinceLevelLoad);
            var mins = timeInSecs / 60;
            var secs = timeInSecs % 60;
        }
        else
        {
            //scoreText.text = playerScore.ToString("F2");
            scoreText.text = $"{timeInSecs / 60} mins {timeInSecs % 60} secs";
        }
        // Score
        
        if (bigPlayerWin == true && smallPlayerWin == true)
        {
            GameOn = false;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            canvas.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player big"))
        {
            bigPlayerWin = true;
        }
        if (other.CompareTag("player small"))
        {
            smallPlayerWin = true;
        }
    }
    
}
