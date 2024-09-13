using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarLight : MonoBehaviour
{
    public float dayLengthM = 2f;
    private float dayLengthS;
    public float timeSpeed = 1f;
    private Light _li;
    public Gradient lightColor;
    public AnimationCurve lightIntensity;
    private float currentTime = 10f;

    void Start()
    {
        _li = GetComponent<Light>();
        dayLengthS = dayLengthM * 60f;
    }

    void Update()
    {
        currentTime += (Time.deltaTime / dayLengthS) * 24f * timeSpeed;

        if (currentTime >= 24f){
            currentTime = 0f;
        }

        float lightAngle = (currentTime / 24f) * 360f - 90f;
        transform.rotation = Quaternion.Euler(lightAngle, 170f, 0f);

        _li.intensity = lightIntensity.Evaluate(currentTime / 24f);
        _li.color = lightColor.Evaluate(currentTime / 24f);
    }
}
