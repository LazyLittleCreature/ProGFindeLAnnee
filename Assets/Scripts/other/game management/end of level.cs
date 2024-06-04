using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endOfLevel : MonoBehaviour
{ 
    public bool GameOn = true;
    private bool bigPlayerWin = false;
    private bool smallPlayerWin = false;
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
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
