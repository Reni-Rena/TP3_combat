using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public CentreCamera centreCamera;
    private float z = 0f;
    private float zMin = -6f;
    private float zMax = -2f;
    private float zoomSpeed = 3f;
    private const string MOUSEWEEL = "Mouse ScrollWheel";
    void Update()
    {
        Vector3 pos = new Vector3(0f,0f,z);
        transform.localPosition = pos;
    }

    void LateUpdate(){
        
        z += Input.GetAxis(MOUSEWEEL) * zoomSpeed;
        if (z < zMin) {
            z = zMin;
        }
        if (z > zMax){
            z = zMax;
        }

    }
}
