using System.Collections;
using UnityEngine;

public class CarAIController : MonoBehaviour
{
    private CarControllerV1 car;

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

    //AI stuff
    [SerializeField] private Transform[] targetPositonTranformList;
    private Vector3 targetPose;
    [SerializeField] private int targetIndex = 0;

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    void Update()
    {
        if (targetIndex > targetPositonTranformList.Length - 1)
        {
            targetIndex = 0;
        }
        SetTargetPose(targetPositonTranformList[targetIndex].position);


        Vector3 dirToMovePosition = (targetPose - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dirToMovePosition);

        float ForwardAmount = 0;
        float TurnAmount = 0;
        bool Brake = false;

        float reachedTargetDistance = 20f;
        float distanceToTarget = Vector3.Distance(transform.forward, targetPose);
        if (distanceToTarget > reachedTargetDistance)
        {
            Brake = false;
            if (dot > 0)
            {
                ForwardAmount = 1f;
            }
            else
            {
                ForwardAmount = -1f;
            }

            float angleToDir = Vector3.SignedAngle(transform.forward, dirToMovePosition, Vector3.up);

            if (angleToDir > 0)
            {
                TurnAmount = 1f;
            }
            else
            {
                TurnAmount = -1f;
            }
        }
        else {
            ForwardAmount = 0;
            TurnAmount = 0;
            Brake = true;
        }

        GetInput(ForwardAmount, TurnAmount, Brake);
    }

    //Degrades the tyers by one percent
    private void TyreDegrade()
    {
        tyreDegradationPercent = tyreDegradationPercent - 0.01f;
    }

    void GetInput(float v, float h, bool b)
    {
        horizontalInput = h;
        verticalInput = v;
        isBreaking = b;
        breakingForce = 1;
        isReversing = false;
    }

    //Moves the car forward based on vertcal input
    private void HandleMotor()
    {
        if (!isReversing)
        {
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
        currentSteerAngle = maxSteerAngle * horizontalInput * tyreDegradationPercent;
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

    private void SetTargetPose(Vector3 targetPose)
    {
        this.targetPose = targetPose;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            
            if (targetIndex < targetPositonTranformList.Length)
            {
                targetIndex += 1;
            } else
            {
                targetIndex = 0;
            }
        }
    }
    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
    }
}
