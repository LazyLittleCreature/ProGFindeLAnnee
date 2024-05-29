using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dying : MonoBehaviour
{ 
    public bool GameOn = true;
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("player big") || this.CompareTag("player small"))
        {
            if (other.CompareTag("lethal"))
            {
                GameOn = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
