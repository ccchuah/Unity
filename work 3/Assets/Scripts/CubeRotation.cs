using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeRotation : MonoBehaviour
{
    public Slider slider;
    public Text speedText;
    public float minSpeed = 90f;
    public float maxSpeed = 450f;
    private float currentSpeed;

    void Start()
    {
        slider.onValueChanged.AddListener(delegate { ChangeSpeed(); });
        currentSpeed = minSpeed;
    }

    void Update()
    {
        transform.Rotate(0, currentSpeed * Time.deltaTime, 0);
        speedText.text = "转速: " + currentSpeed.ToString("F0") + " 度/秒";
    }

    void ChangeSpeed()
    {
        if (slider.value == slider.minValue)
        {
            currentSpeed = minSpeed;
        }
        else if (slider.value == slider.maxValue)
        {
            currentSpeed = maxSpeed;
        }
        else
        {
            slider.value = slider.minValue;
            currentSpeed = minSpeed;
        }
    }
}