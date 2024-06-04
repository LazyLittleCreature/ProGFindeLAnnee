using UnityEngine;
using UnityEngine.InputSystem;

public class cablesmall : MonoBehaviour
{
    [SerializeField] private float multiplier = 50;
    public float taillecable;
    public float offset = 0.6f;
    public float climbSpeed = 200f;
    private bool canClimb = false;
    private bool canGoDown = false;
    private bool isClimbing = false;
    private bool isGoingDown = false;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private float middleOfcable;

    [SerializeField] private Collider playerCollider;
    //[SerializeField] public bigpush target;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("cable"))
        {
            taillecable = other.gameObject.transform.localScale.y;
            middleOfcable = other.gameObject.transform.position.y + (taillecable / 2);
            if (transform.position.y <= middleOfcable)
            {
                
                canClimb = true;
                canGoDown = false;
            }
            if (transform.position.y > middleOfcable)
            {
                
                canGoDown = true;
                canClimb = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cable"))
        {
            canClimb = false;
            canGoDown = false;
        }
    }

    public void HandleClimbcable(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           
        }
        if (context.performed && canClimb)
        {
            
            targetPosition = transform.position + transform.up * (taillecable + offset) * multiplier;
            isClimbing = true;
            playerCollider.isTrigger = true;
        }
        else if (context.canceled && playerCollider != null)
        {
            isClimbing = false;
            playerCollider.isTrigger = false;
        }
    }

    public void HandleGoDowncable(InputAction.CallbackContext context)
    {
        if (context.performed && canGoDown)
        {
            targetPosition = transform.position + transform.up * (taillecable - offset) * -1 * multiplier;
            isGoingDown = true;
            playerCollider.isTrigger = true;
        }
        else
        {
            isGoingDown = false;
            playerCollider.isTrigger = false;
        }
    }

    void Update()
    {
        if (isClimbing || isGoingDown)
        {
            rb.useGravity = false;
            float step = climbSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
            {
                isClimbing = false;
                isGoingDown = false;
                playerCollider.isTrigger = false;
                rb.useGravity = true;
            }
        }
    }
}