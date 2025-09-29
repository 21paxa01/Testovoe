using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CraneRope : MonoBehaviour
{
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform hook;  

    private LineRenderer line;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    void Update()
    {
        if (line != null && topPoint != null && hook != null)
        {
            line.SetPosition(0, topPoint.position);
            line.SetPosition(1, hook.position);
        }
    }
}