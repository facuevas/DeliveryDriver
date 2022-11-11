using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Driver : MonoBehaviour
{
    // Components
    private Rigidbody2D rb;
    
    [FormerlySerializedAs("moveSpeed")] [SerializeField]
    private float _moveSpeed = 10f;
    [FormerlySerializedAs("steerAngle")] [SerializeField]
    private float _steerAngle = 250f;

    private bool _isReversing;

    private bool _isMoving;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Clamp move speed
        _moveSpeed = Mathf.Clamp(_moveSpeed, 3f, 30f);
        applySteering();
        applyMovement();
    }

    void applySteering()
    {
        // Do not apply steering if the car is not moving.
        if (!_isMoving) 
            return;
        
        // Invert the direction if we are reversing.
        float steerDirection = _isReversing ? -1 : 1;
        float steerInput = Input.GetAxis("Horizontal");
        float steerAmount = -steerInput * _steerAngle * steerDirection * Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);
    }

    void applyMovement()
    {
        float moveInput = Input.GetAxis("Vertical");
        float moveAmount = moveInput * _moveSpeed * Time.deltaTime;
        
        // If we are going negative, we are reversing.
        _isReversing = moveAmount < 0f;
        _isMoving = moveInput != 0f;
        transform.Translate(0, moveAmount, 0);
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    public void SetSteerAngle(float steerAngle)
    {
        _steerAngle = steerAngle;
    }
}
