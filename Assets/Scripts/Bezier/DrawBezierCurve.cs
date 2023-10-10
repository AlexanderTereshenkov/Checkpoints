using UnityEngine;

public class DrawBezierCurve : MonoBehaviour
{
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawCurve(GameObject previousCheckpoint, GameObject nextCheckpoint)
    {
        int segments = 30;
        Vector3[] allPoints = new Vector3[segments];
        lineRenderer.positionCount = segments;
        //Vector3 previousPoint = previousCheckpoint.transform.position;
        for (int i = 0; i < segments; i++)
        {
            float t = (float)i / segments;
            Vector3 point = BezierCurve.GetBezierCurvePoint(previousCheckpoint.transform.position,
                previousCheckpoint.transform.GetChild(0).GetChild(0).GetComponent<Checkpoint>().GetFirstBezierPoint().position,
                nextCheckpoint.transform.GetChild(0).GetChild(0).GetComponent<Checkpoint>().GetSecondBezierPoint().position, nextCheckpoint.transform.position, t);
            allPoints[i] = point;
            //previousPoint = point;
        }
        lineRenderer.SetPositions(allPoints);
    }

    public void DeleteLine()
    {
        lineRenderer.positionCount = 0;
    }
}
