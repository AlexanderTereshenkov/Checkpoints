using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkpointManager;
    private Transform firstBezierPoint;
    private Transform secondBezierPoint;

    private void Start()
    {
        foreach(Transform child in transform.parent.parent)
        {
            if (child.gameObject.name.Equals("Bezier point 1")) firstBezierPoint = child.transform;
            if (child.gameObject.name.Equals("Bezier point 2")) secondBezierPoint = child.transform;
        }

        checkpointManager = CheckpointManager.checkpointManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpointManager.ChangeCheckpoint();
        }
    }

    public Transform GetFirstBezierPoint()
    {
        return firstBezierPoint;
    }

    public Transform GetSecondBezierPoint()
    {
        return secondBezierPoint;
    }
}
