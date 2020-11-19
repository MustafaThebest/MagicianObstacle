using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private int clicksPositionsCount;
    private List<Vector3> clicksPositions;
    private LineRenderer lineRenderer;
    private bool hasTouched;
    void Start()
    {
        clicksPositionsCount = 0;
        clicksPositions = new List<Vector3>();
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.2f;
    }

    void Update()
    {
        TouchDetector();
        print(hasTouched);
        RegisterclicksPositions();
        DrawLineByTouch();
    }

    void DrawLineByTouch()
    {
        if (hasTouched)
        {
            Touch[] touches = Input.touches;
            Vector3[] touchesVector = new Vector3[Input.touchCount];
            for (int i = 0; i < Input.touchCount; i++)
            {
                touchesVector[i] = new Vector3(touches[i].position.x, touches[i].position.y, 0);
            }
            for (int i = 0; i < Input.touchCount; i++)
            {
                lineRenderer.positionCount = Input.touchCount;
                lineRenderer.SetPositions(touchesVector);
            }

#if UNITY_EDITOR
            for (int i = 0; i < clicksPositionsCount; i++)
            {
                lineRenderer.positionCount = clicksPositionsCount;
                lineRenderer.SetPositions(clicksPositions.ToArray());
                print("YAY");

            }
#endif
        }
    }

    void RegisterclicksPositions()
    {   
        if (hasTouched)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clicksPositionsCount++;

            clicksPositions.Add(new Vector3(position.x, position.y, 0));
        }
    }

    void TouchDetector()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            hasTouched = true;
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            hasTouched = true;
        }
#endif
        else
        {
            hasTouched = false;
        }
    }
}
