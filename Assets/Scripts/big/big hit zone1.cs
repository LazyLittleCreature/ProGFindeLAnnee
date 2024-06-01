using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bighitzone : MonoBehaviour
{
    [SerializeField] private GameObject bigPlayer;
    private BigMove bigMoveScript;
    [SerializeField] private float cooldown;
    private float counter;
    public bool isHitting = false;
        
    // Start is called before the first frame update
    void Start()
    {
        bigMoveScript = bigPlayer.GetComponent<BigMove>();
        counter = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = bigPlayer.transform.position + (new Vector3(1.5f, 0, 0) * bigMoveScript.direction);
        counter -= Time.deltaTime;
    }

    private void Delay()
    {
        isHitting = false;
    }

    public void HandleBigHit(InputAction.CallbackContext hitInput)
    {
        if (hitInput.performed)
        {
            if (counter <= 0)
            {
                counter = cooldown;
                isHitting = true;
                Invoke("Delay", 1f);
            }
        }
    }
}
