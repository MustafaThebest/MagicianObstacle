using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject[] objects;
    private LineRenderer lineRenderer;
    Vector3[] linePositions; 
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.2f;
        linePositions = new Vector3[objects.Length];
        DrawLine();
    }

    void Update()
    {
    
    }

    void DrawLine()
    {
        print(objects.Length);
        
        for(int i = 0; i < objects.Length; i++)
        {
            linePositions[i] = objects[i].transform.position;
        }   

        for(int i = 0; i < objects.Length; i++)
        {
            lineRenderer.positionCount = objects.Length;
            lineRenderer.SetPositions(linePositions);
        }  
    }
}
