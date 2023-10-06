using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private List<GameObject> waypoints = new List<GameObject>();
    private void Start()
    {
        foreach(Transform child in transform)
        {
            waypoints.Add(child.gameObject);
        }
        Debug.Log(waypoints.Count);
    }
}
