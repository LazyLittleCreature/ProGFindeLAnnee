using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashSmall : MonoBehaviour
{
    //private bool currentDimension = false; // false = etat 1  :  true = etat 2
    public float dashDistance = 5f; // Distance du dash
    public float dashSpeed = 10f; // vitesse du dash
	private SmallMove SmallMoveScript;
	private int direction;
    private float timer = 0;
    private bool CanDash = true;

	void Start()
	{
		SmallMoveScript = GetComponent<SmallMove>();
		direction = SmallMoveScript.direction;
	}

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.75f)
        {
            CanDash = true;
        }
        else
        {
            CanDash = false;
        }
    }

    public void HandleSmallDash(InputAction.CallbackContext context)
    {
        if (CanDash == true)
        {
            if (context.performed)
            {
                StartCoroutine(PerformDash());
                timer = 0;
            }
        }
    }
    IEnumerator PerformDash()
    {
        Vector3 startPosition = transform.position;

        
        direction = SmallMoveScript.direction;
        Vector3 endPosition = transform.position + transform.right * dashDistance * direction;

        
        while (Vector3.Distance(transform.position, endPosition) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, dashSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = endPosition;
    }
}



























/*
    public void HandleDimensionSwap(InputAction.CallbackContext dimensionSwap)
    {
        if (dimensionSwap.performed)
        {
            if (currentDimension)
            {
                Debug.Log("dimension swap");
                transform.Rotate(0, 90, 0);
                currentDimension = false;
            }
            else
            {
                Debug.Log("dimension swap");
                transform.Rotate(0, -90, 0);
                currentDimension = true;
            }
        }
    }

*/