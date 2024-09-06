using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Bezier : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;
    [SerializeField]
    public LineRenderer lineRenderer;

    void Update()
    {
        DrawCurve();
    }

    public void DrawCurve()
    {
        var newPoints = new List<Vector3>();

        for (float t = 0; t <= 1; t += 0.05f)
        {
            newPoints.Add(GetPoint(controlPoints[0].position, controlPoints[1].position, controlPoints[2].position, t));
        }
        lineRenderer.positionCount = newPoints.Count;
        lineRenderer.SetPositions(newPoints.ToArray());
    }

    public Vector3 GetPoint(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 p1 = Vector3.Lerp(a, b, t);
        Vector3 p2 = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(p1, p2, t);
    }
}