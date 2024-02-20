using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.InputSystem;

public class CarControllerV1 : MonoBehaviour
{
    public PlayerControls controls;

    // The Left(-1) and Right(1) input 
    private float horizontalInput;
    // The Up(-1) and Down(1) input
    private float verticalInput;

    // Car Stats
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;
    private float breakingForce = 1;
    private bool isReversing;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float tyreDegradationPercent;

    // Wheels
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    // Tyres
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    //Degrades the tyers by one percent
    private void TyreDegrade()
    {
        // need to be reworked
        tyreDegradationPercent = tyreDegradationPercent - 0.01f;
    }

    void GetInput() {
        controls.PlayerMap.Turn.performed += ctx => horizontalInput = ctx.ReadValue<float>();
        controls.PlayerMap.Turn.canceled += ctx => horizontalInput = 0;
        controls.PlayerMap.Throttle.performed += ctx => verticalInput = ctx.ReadValue<float>();
        controls.PlayerMap.Throttle.canceled += ctx => verticalInput = 0;
        controls.PlayerMap.Brake.performed += ctx => isBreaking = true;
        controls.PlayerMap.Brake.canceled += ctx => isBreaking = false;
        controls.PlayerMap.Brakeing.performed += ctx => breakingForce = ctx.ReadValue<float>();
        controls.PlayerMap.Brakeing.canceled += ctx => breakingForce = 1;
        controls.PlayerMap.Revers.performed += ctx => isReversing = true;
        controls.PlayerMap.Revers.canceled += ctx => isReversing = false;
    }

    //Moves the car forward based on vertcal input
    private void HandleMotor()
    {
        if (!isReversing) {
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce;
            rearRightWheelCollider.motorTorque = verticalInput * motorForce;
            rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        }
        if (isReversing)
        {
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce * -1;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce * -1;
            rearRightWheelCollider.motorTorque = verticalInput * motorForce * -1;
            rearLeftWheelCollider.motorTorque = verticalInput * motorForce * -1;
        }
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    //Apply force in opsit drection till net 0
    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce * breakingForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce * breakingForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce * breakingForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce * breakingForce;
    }

    //Turns wheel Collider based on the horizontalInput
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
        rearRightWheelCollider.steerAngle = -currentSteerAngle;
        rearLeftWheelCollider.steerAngle = -currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
    }

    public PlayerControls getControls()
    {
        return controls;
    }

    private void OnEnable()
    {
        controls.PlayerMap.Enable();
    }
    private void OnDisable()
    {
        controls.PlayerMap.Disable();
    }
}
