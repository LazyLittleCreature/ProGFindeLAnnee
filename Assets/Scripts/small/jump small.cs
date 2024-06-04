using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmallJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private int MaxJump = 2;
    private int CurrentJumpCount = 0;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jumpForce = _jumpForce * 1000;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Plateforme"))
        {
            CurrentJumpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plateforme"))
        {
            CurrentJumpCount = 0;
        }
    }

    public void HandleSmallJump(InputAction.CallbackContext jumpInput)
    {
        if (jumpInput.performed)
        {
            if (CurrentJumpCount < MaxJump)
            {
                _rigidbody.AddForce(transform.up * _jumpForce);
                CurrentJumpCount += 1;
                
            }
        }
    }
}