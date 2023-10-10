using UnityEngine;

public static class BezierCurve
{
    public static Vector3 GetBezierCurvePoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float temp = (1 - t);
        return temp * temp * temp * p0 + 3 * t * temp * temp * p1 + 3 * t * t * temp * p2 + t * t * t * p3;
    }
}
