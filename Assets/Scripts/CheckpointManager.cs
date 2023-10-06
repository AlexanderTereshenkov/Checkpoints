using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager checkpointManager;

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
        Debug.Log(currentCheckpoint);
        checkpoints[currentCheckpoint].gameObject.SetActive(true);
    }
}
