using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = CheckpointManager.checkpointManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpointManager.ChangeCheckpoint();
        }
    }
}
