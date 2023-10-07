using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRIghtWheelCollider;
    [SerializeField] private float carSpeed;
    [SerializeField] private float carSteerAngle;
    [SerializeField] private Transform playerSpawnPoint;

    private Vector2 playerInput;
    private float currentSteerAngle;

    private void Update()
    {
        playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.R)) RestartGame();
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

    private void RestartGame()
    {
        CheckpointManager checkpointManager = CheckpointManager.checkpointManager;
        gameObject.transform.position = playerSpawnPoint.transform.position;
        gameObject.transform.rotation = playerSpawnPoint.transform.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        checkpointManager.ChangeCheckpointState(checkpointManager.GetCurrentCheckpoint(), false);
        checkpointManager.SetCurrentCheckpoint(0);
        checkpointManager.ChangeCheckpointState(checkpointManager.GetCurrentCheckpoint(), true);
    }
}
