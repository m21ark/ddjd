using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] WheelCollider FR;
    [SerializeField] WheelCollider FL;
    [SerializeField] WheelCollider BR;
    [SerializeField] WheelCollider BL;

    [SerializeField] Transform FRTransform;
    [SerializeField] Transform FLTransform;
    [SerializeField] Transform BRTransform;
    [SerializeField] Transform BLTransform;

    [SerializeField] private string HorizontalAxisName;
    [SerializeField] private string VerticalAxisName;


    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;


    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate()
    {

        currentAcceleration = acceleration * Input.GetAxis(VerticalAxisName);

        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakingForce;
        }
        else
        {
            currentBreakForce = 0f;
        }


        FR.motorTorque = currentAcceleration;
        FL.motorTorque = currentAcceleration;

        FR.brakeTorque = currentBreakForce;
        FL.brakeTorque = currentBreakForce;
        BL.brakeTorque = currentBreakForce;
        BR.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis(HorizontalAxisName);
        FL.steerAngle = currentTurnAngle;
        FR.steerAngle = currentTurnAngle;

        UpdateWheel(FR, FRTransform, new Vector3(0f, 0.0f, 90f));
        UpdateWheel(FL, FLTransform, new Vector3(0f, 0.0f, 90f));
        UpdateWheel(BR, BRTransform, new Vector3(0f, 0.0f, 90f));
        UpdateWheel(BL, BLTransform, new Vector3(0f, 0.0f, 90f));
    }

    void UpdateWheel(WheelCollider col, Transform trans, Vector3 localRotationOffset)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        // Apply local rotation offset to the wheel rotation
        rotation *= Quaternion.Euler(localRotationOffset);

        trans.position = position;
        trans.rotation = rotation;
    }


}
