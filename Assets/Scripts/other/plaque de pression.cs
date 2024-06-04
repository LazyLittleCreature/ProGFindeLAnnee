using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueDePression : MonoBehaviour
{
    private int compteur = 0;
    [SerializeField] private GameObject target;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player small") || other.CompareTag("block") || other.CompareTag("player big"))
        {
            compteur += 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player small") || other.CompareTag("block") || other.CompareTag("player big"))
        {
            compteur -= 1;
        }
    }

    void Update()
    {
        if (compteur > 0)
        {
            target.SetActive(true);
        }
        else
        {
            target.SetActive(false);
        }
    }
}