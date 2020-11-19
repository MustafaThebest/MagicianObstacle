using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public List<Vector2> touchPositions;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        touchPositions.Clear();
        touchPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        touchPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, touchPositions[0]);
        lineRenderer.SetPosition(1, touchPositions[1]);
    }
}
