using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Vector3 CarMoveForce;
    public float MoveSpeed;
    //Set Drag less than 1
    public float Drag;
    public float MaxSpeed;
    public float SteerAngle;
    public float Traction;

    void Update()
    {
        //Get accelerator Input
        CarMoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        // Move car even if key not applied
        transform.position += CarMoveForce * Time.deltaTime;

        // Drag
        CarMoveForce *= Drag;
        // Set Speed Limit
        CarMoveForce = Vector3.ClampMagnitude(CarMoveForce, MaxSpeed);

        // Steering
        float SteerInput = Input.GetAxis("Horizontal");
        //rotate car only when moving
        transform.Rotate(Vector3.up * SteerInput * CarMoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Traction
        CarMoveForce = Vector3.Lerp(CarMoveForce.normalized, transform.forward, Traction * Time.deltaTime) * CarMoveForce.magnitude;
    }
}
