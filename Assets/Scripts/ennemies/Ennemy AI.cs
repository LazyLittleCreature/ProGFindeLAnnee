using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyAI : MonoBehaviour
{
    private Transform myTransform;
    [SerializeField] private float speed = 5f;
    private EnnemyManager ennemyManager;
    private Vector3 currentMovePoint;
    private GameObject movePointOne;
    private GameObject movePointTwo;
    private bighitzone hitZoneScript;
    
    void Start()
    {
        ennemyManager = GetComponentInParent<EnnemyManager>();
        movePointOne = ennemyManager.movePointOne;
        movePointTwo = ennemyManager.movePointTwo;
        currentMovePoint = movePointOne.transform.position;
        hitZoneScript = ennemyManager.hitZoneScript;

    }
    
    
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentMovePoint, step);
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
