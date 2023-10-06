using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager checkpointManager;

    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private bool isCircled;

    private List<GameObject> checkpoints = new List<GameObject>();

    private int currentCheckpoint = 0;
    private void Awake()
    {
        checkpointManager = this;
    }
    private void Start()
    {
        foreach(Transform child in transform)
        {
            checkpoints.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
        checkpoints[currentCheckpoint].gameObject.SetActive(true);
    }

    public void ChangeCheckpoint()
    {
        checkpoints[currentCheckpoint].gameObject.SetActive(false);
        currentCheckpoint = currentCheckpoint + 1 == checkpoints.Count - 1 ? 0 : currentCheckpoint + 1;
        checkpoints[currentCheckpoint].gameObject.SetActive(true);
    }

    public void RestartGame(GameObject player)
    {
        player.transform.position = playerSpawnPoint.position;
        player.transform.rotation = playerSpawnPoint.rotation;
        checkpoints[currentCheckpoint].gameObject.SetActive(false);
        currentCheckpoint = 0;
        checkpoints[currentCheckpoint].gameObject.SetActive(true);
    }
}
