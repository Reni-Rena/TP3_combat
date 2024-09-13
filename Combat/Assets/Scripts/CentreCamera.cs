using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreCamera : MonoBehaviour
{
    public Mouve playMouve;
    private float x = 0f;
    private float y = 1f;
    public float yMin = -8f;
    public float yMax = 60f;
    public float Speed = 3f;
    private const string MOUSEX = "Mouse X";
    private const string MOUSEY = "Mouse Y";
    void Update()
    {
        Vector3 newPosition = playMouve.transform.position;

        newPosition.y += 1f;

        transform.position = newPosition;
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0)){
            x += Input.GetAxis(MOUSEX) * Speed;
            y += Input.GetAxis(MOUSEY) * Speed;
            if (y < yMin){
                y = yMin;
            }
            if (y > yMax){
                y = yMax;
            }
            Quaternion a = Quaternion.Euler(y, x, 0f);
            transform.rotation = a;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            x += Input.GetAxis(MOUSEX) * Speed;
            y += Input.GetAxis(MOUSEY) * Speed;
            if (y < yMin){
                y = yMin;
            }
            if (y > yMax){
                y = yMax;
            }
            Quaternion a = Quaternion.Euler(y, x, 0f);
            transform.rotation = a;
            Vector3 cameraForward = transform.forward;
            cameraForward = new Vector3(cameraForward.x, 0f, cameraForward.z);
            playMouve.transform.forward = cameraForward;
        }
    }
}
