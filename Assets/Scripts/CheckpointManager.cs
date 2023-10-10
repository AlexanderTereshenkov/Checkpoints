using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager checkpointManager;

    [SerializeField] private bool isCircled;
    [SerializeField] private GameStateUI gameStateUI;
    [SerializeField] private DrawBezierCurve drawBezierCurve;

    private List<GameObject> checkpoints = new List<GameObject>();
    private int currentCheckpoint = 0;
    private bool isFirstLap = false;
    private GameObject previousCheckpoint;
    private GameObject nextCheckpoint;

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
        if (isCircled)
        {   
            ChangeCheckpointState(currentCheckpoint, false);
            currentCheckpoint = currentCheckpoint + 1 == checkpoints.Count - 1 ? 0 : currentCheckpoint + 1;
            ChangeCheckpointState(currentCheckpoint, true);

            drawBezierCurve.DeleteLine();
            drawBezierCurve.DrawCurve(previousCheckpoint, nextCheckpoint);

            if (isFirstLap && currentCheckpoint == 1) gameStateUI.ShowCnagedLap();
            if (!isFirstLap) isFirstLap = true;
        }
        else
        {
            if(currentCheckpoint + 1 != checkpoints.Count)
            {
                ChangeCheckpointState(currentCheckpoint, false);
                currentCheckpoint++;
                ChangeCheckpointState(currentCheckpoint, true);

                drawBezierCurve.DeleteLine();
                drawBezierCurve.DrawCurve(previousCheckpoint, nextCheckpoint);
            }
            else
            {
                ChangeCheckpointState(currentCheckpoint, false);
                drawBezierCurve.DeleteLine();
                gameStateUI.ShowFinalScreen();
            }
        }
    }


    public void ChangeCheckpointState(int pos, bool value)
    {
        if (!value)
        {
            previousCheckpoint = checkpoints[pos].gameObject;
        }
        else
        {
            nextCheckpoint = checkpoints[pos].gameObject;
        }
        checkpoints[pos].gameObject.SetActive(value);
    }

    public int GetCurrentCheckpoint()
    {
        return currentCheckpoint;
    }

    public void SetCurrentCheckpoint(int value)
    {
        currentCheckpoint = value;
    }

}
