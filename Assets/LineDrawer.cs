using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private int clicksCount;
    private List<Vector3> clicksPositions;
    private List<Vector3> oldClicksPositions;
    private LineRenderer lineRenderer;
    private bool hasTouched;

    int overLaps = 0;
    int discrepancies = 0;
    void Start()
    {
        clicksCount = 0;
        clicksPositions = new List<Vector3>();
        oldClicksPositions = new List<Vector3>();
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.2f;
    }

    void Update()
    {
        TouchDetector();
        RegisterclicksPositions();
        DrawLineByTouch();
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ShapeRecognition();
        }
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
            for (int i = 0; i < clicksCount; i++)
            {
                lineRenderer.positionCount = clicksCount;
                lineRenderer.SetPositions(clicksPositions.ToArray());
            }
#endif
        }
    }

    void RegisterclicksPositions()
    {
        if (hasTouched)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clicksCount++;

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
        if (Input.GetMouseButton(0))
        {
            hasTouched = true;
        }
#endif
        else
        {
            for (int i = 0; i < clicksCount; i++)
            {
                oldClicksPositions.Add(clicksPositions[i]);
            }
            // print(oldClicksPositions.Count);
            // print(clicksPositions.Count);
            clicksCount = 0;
            clicksPositions.Clear();
            hasTouched = false;
        }
    }

    void ShapeRecognition()
    {
        for (int i = 0; i < oldClicksPositions.Count; i++)
        {
            if (oldClicksPositions.Contains(oldClicksPositions[i]))
            {
                overLaps++;
            }
            else
            {
                discrepancies++;

            }
        }
        print("Overlaps: " + overLaps);
        print("discrepancies: " + discrepancies);
        if (overLaps > discrepancies)
        {
            Debug.Log("ODINAKOVI!");
        }
        else
        {
            Debug.Log("NEODINAKOVI!(");
        }
    }
}
