using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    public float CarSpeed;



    private bool isFren;
    private float currentFrenForce;
    private float currentDonusAcisi;

    //[SerializeField] private float carMaxSpeed;
    Rigidbody RB;

    [SerializeField] private float MotorTorqueForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float MaxturningAngle;

    [SerializeField] private WheelCollider FL_Colider;
    [SerializeField] private WheelCollider FR_Colider;
    [SerializeField] private WheelCollider RR_Colider;
    [SerializeField] private WheelCollider RL_Colider;

    [SerializeField] private Transform FL_Wheel;
    [SerializeField] private Transform FR_Wheel;
    [SerializeField] private Transform RL_Wheel;
    [SerializeField] private Transform RR_Wheel;


    private void FixedUpdate()
    {
       
        moveTheCar();
        rotateTheCar();
        rotateTheWheels();
    }
    private void Update()
    {
        getUserInput();

    }
    private void rotateTheWheels()
    {
        rotateTheWheel(FL_Colider, FL_Wheel);
        rotateTheWheel(FR_Colider, FR_Wheel);
        rotateTheWheel(RL_Colider, RL_Wheel);
        rotateTheWheel(RR_Colider, RR_Wheel);
    }

    private void rotateTheWheel(WheelCollider tekerlerkCollider, Transform tekerlekTransform)
    {
        Vector3 position;
        Quaternion rotation;
        tekerlerkCollider.GetWorldPose(out position, out rotation);
        tekerlekTransform.position = position;
        tekerlekTransform.rotation = rotation;
    }

    private void rotateTheCar()
    {
        currentDonusAcisi = MaxturningAngle * horizontalInput;
        FL_Colider.steerAngle = currentDonusAcisi;
        FR_Colider.steerAngle = currentDonusAcisi;
    }

    private void moveTheCar()
    {
        FL_Colider.motorTorque = verticalInput * 500 * CarSpeed;
        FR_Colider.motorTorque = verticalInput * 500 * CarSpeed;
        currentFrenForce = isFren ? brakeForce : 0f;
        if (isFren)
        {
            FL_Colider.brakeTorque = currentFrenForce;
            FR_Colider.brakeTorque = currentFrenForce;
            RL_Colider.brakeTorque = currentFrenForce;
            RR_Colider.brakeTorque = currentFrenForce;
        }else
        {
            FL_Colider.brakeTorque = 0f;
            FR_Colider.brakeTorque = 0f;
            RL_Colider.brakeTorque = 0f;
            RR_Colider.brakeTorque = 0f;
        }
    }

    
    private void getUserInput()
    {
        horizontalInput = (Input.GetAxis("Horizontal"));
        verticalInput =( Input.GetAxis("Vertical"));
        //isFren = Input.GetKey(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCarRotation();

        }
    }

    public void BrakeButtonOn()
    {
        isFren = true;
        Debug.Log("frenAktif" + isFren);
    }
    public void BrakeButtonOf()
    {
        isFren = false;
        Debug.Log("frennull" + isFren);
    }

    private void resetCarRotation()
    {
        Quaternion rotation = transform.rotation;
        rotation.z = 0f;
        rotation.x = 0f;
        transform.rotation = rotation;
    }
}
