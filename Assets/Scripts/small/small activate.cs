using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class smallactivate : MonoBehaviour
{
    public bool isActivating = true;
    public void HandleActivateSmall(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isActivating = true;
			Debug.Log("the small robot is activating");
        }
        if(context.canceled)
        {
            isActivating = false;
			Debug.Log("the small robot stoped activating");
        }
    }
}
