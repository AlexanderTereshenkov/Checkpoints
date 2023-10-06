using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRIghtWheelCollider;
    [SerializeField] private float carSpeed;
    [SerializeField] private float carSteerAngle;

    private Vector2 playerInput;
    private float currentSteerAngle;

    private void Update()
    {
        playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.R)) CheckpointManager.checkpointManager.RestartGame(gameObject);
    }

    private void FixedUpdate()
    {
        CarAcceleration();
        CarSteering();
    }

    private void CarAcceleration()
    {
        frontLeftWheelCollider.motorTorque = carSpeed * playerInput.y;
        frontRightWheelCollider.motorTorque = carSpeed * playerInput.y;
        backLeftWheelCollider.motorTorque = carSpeed * playerInput.y;
        backRIghtWheelCollider.motorTorque = carSpeed * playerInput.y;
    }

    private void CarSteering()
    {
        currentSteerAngle = carSteerAngle * playerInput.x;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }
}
