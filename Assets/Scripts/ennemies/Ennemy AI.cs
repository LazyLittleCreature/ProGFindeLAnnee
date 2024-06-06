using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ennemyAI : MonoBehaviour
{
    private Transform myTransform;
    [SerializeField] private float speed;
    private EnnemyManager ennemyManager;
    private Vector3 currentMovePoint;
    private GameObject movePointOne;
    private GameObject movePointTwo;
    private bighitzone hitZoneScript;
    private string currentSceneName;
    
    void Start()
    {
        ennemyManager = GetComponentInParent<EnnemyManager>();
        movePointOne = ennemyManager.movePointOne;
        movePointTwo = ennemyManager.movePointTwo;
        currentMovePoint = movePointOne.transform.position;
        hitZoneScript = ennemyManager.hitZoneScript;
        currentSceneName = SceneManager.GetActiveScene().name;

    }
    
    
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentMovePoint, step);
        if (currentSceneName == "LVL1")
        {
            speed = 125;
        }
        else if (currentSceneName == "LVL2")
        {
            speed = 25;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == movePointOne)
        {
            currentMovePoint = movePointTwo.transform.position;
        }
        if (other.gameObject == movePointTwo)
        {
            currentMovePoint = movePointOne.transform.position;
        }

        if (other.gameObject.CompareTag("block"))
        {
            if (currentMovePoint == movePointTwo.transform.position)
            {
                currentMovePoint = movePointOne.transform.position;
            }
            if (currentMovePoint == movePointOne.transform.position)
            {
                currentMovePoint = movePointTwo.transform.position;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("hit zone") && hitZoneScript.isHitting)
        {
            Debug.Log("Mi ded pls");
            Destroy(this.gameObject);
        }
    }
}
