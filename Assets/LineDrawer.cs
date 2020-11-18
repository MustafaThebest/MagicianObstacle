using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject[] objects;
    private Vector3[] linePositions; 
    private LineRenderer lineRenderer;
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

    void GetLinePositions()
    {
        //Getting positions from drawing
    }

    void DrawLine()
    {
        
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
