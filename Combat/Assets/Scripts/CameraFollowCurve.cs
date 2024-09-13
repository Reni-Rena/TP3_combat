using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCurve : MonoBehaviour
{
    public LineRenderer lineRenderer; // Référence au LineRenderer qui contient les points de la courbe
    public float speed = 5f; // Vitesse de déplacement de la caméra
    private List<Vector3> bezierPoints = new List<Vector3>(); // Liste des points de la courbe
    private int currentPointIndex = 0; // Index du point actuel où se trouve la caméra
    private float distanceThreshold = 0.1f; // Distance minimale pour atteindre un point avant de passer au suivant

    void Start()
    {
        // Récupère tous les points de la courbe à partir du LineRenderer
        int numPoints = lineRenderer.positionCount;
        for (int i = 0; i < numPoints; i++)
        {
            bezierPoints.Add(lineRenderer.GetPosition(i));
        }

        // Place la caméra au premier point de la courbe
        if (bezierPoints.Count > 0)
        {
            transform.position = bezierPoints[0];
        }
    }

    void Update()
    {
        // Si on a atteint la fin de la courbe, on arrête le mouvement
        if (currentPointIndex >= bezierPoints.Count - 1) return;

        // Obtenir la position du prochain point sur la courbe
        Vector3 targetPoint = bezierPoints[currentPointIndex + 1];

        // Déplacer la caméra vers le prochain point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        // Facultatif: Regarder vers le prochain point pour simuler un mouvement fluide
        transform.LookAt(targetPoint);

        // Vérifier si la caméra est suffisamment proche du point cible pour passer au suivant
        if (Vector3.Distance(transform.position, targetPoint) < distanceThreshold)
        {
            currentPointIndex++;
        }
    }
}
