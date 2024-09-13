using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCurve : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 5f;
    public List<Vector3> bezierPoints = new List<Vector3>(); // Liste des points de la courbe
    private int currentPointIndex = 0;
    private float distanceThreshold = 0.1f;
    public int numPoints;

    void Start()
    {
        StartCoroutine(WaitForLineRendererPoints());
    }
    IEnumerator WaitForLineRendererPoints()
    {
        yield return new WaitForSeconds(0.5f);

        int numPoints = lineRenderer.positionCount;
        for (int i = 0; i < numPoints; i++){
            bezierPoints.Add(lineRenderer.GetPosition(i));
        }

        if (bezierPoints.Count > 0){
            transform.position = bezierPoints[0];
        }
    }

    void Update()
    {
        if (bezierPoints.Count == 0) return;
        if (currentPointIndex >= bezierPoints.Count - 1){
            gameObject.SetActive(false);
            return;
        }

            

        Vector3 targetPoint = bezierPoints[currentPointIndex + 1];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
        transform.LookAt(targetPoint);
        if (Vector3.Distance(transform.position, targetPoint) < distanceThreshold){
            currentPointIndex++;
        }
    }
}
