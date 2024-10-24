using UnityEngine;

public class CurvedHealthBar : MonoBehaviour
{
    [SerializeField]
    private int smootherUI = 32;
    [SerializeField]
    [Range(0f, 1f)]
    private float fillState = 1.0f;
    [SerializeField]
    public LineRenderer lineRenderer;
    public float heightOfLine = 0f;
    public float expandLine = 2.5f;

    public float FillState
    {
        get => fillState;
        set
        {
            fillState = value;
            RecalculatePoints();
        }
    }
    private void OnValidate() => RecalculatePoints();
    private void RecalculatePoints()
    {
        float angleIncrement = 1.75f * fillState / smootherUI;
        float angle = 0.0f;
        Vector3[] positions = new Vector3[smootherUI + 1];
        for (var i = 0; i <= smootherUI; i++)
        {
            positions[i] = new Vector3(
                Mathf.Cos(angle)* expandLine,
                heightOfLine,
                Mathf.Sin(angle)* expandLine
            );
            angle += angleIncrement;
        }
        lineRenderer.positionCount = smootherUI + 1;
        lineRenderer.SetPositions(positions);
    }
}
