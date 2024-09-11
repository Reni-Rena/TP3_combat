using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarLight : MonoBehaviour
{

    private Light _li;
    private float x;
    private float y = 90f;
    private bool isDay = true;
    private float dayLightIntensity = 0.5f;
    private Color dayLightColor = Color.yellow;
    private float nightLightIntensity = 0.2f;
    private Color nightLightColor = Color.blue;

    void Start()
    {
        _li = GetComponent<Light>();
    }

    void Update()
    {
        x += 1;
        if (x == 180)
        {
            x = 0;
            if (isDay){
                isDay = false;
                _li.intensity = dayLightIntensity;
                _li.color = dayLightColor;
            }else{
                isDay = true;
                _li.intensity = nightLightIntensity;
                _li.color = nightLightColor;
            }
        }
        Quaternion a = Quaternion.Euler(x, y, 0f);
        transform.rotation = a;
    }
}
