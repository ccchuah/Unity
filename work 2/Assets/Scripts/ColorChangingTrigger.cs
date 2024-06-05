using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingTrigger : MonoBehaviour
{
    private Renderer rend;
    private Color[] colors = { Color.red, new Color(1.0f, 0.5f, 0.0f), Color.yellow, Color.green, Color.blue, new Color(0.0f, 1.0f, 1.0f), Color.magenta };
    private int colorIndex = 0;
    private bool isChangingColor = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = colors[colorIndex];
        StartCoroutine(ChangeColorRoutine());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isChangingColor = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isChangingColor = false;
        }
    }

    IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            if (isChangingColor)
            {
                ChangeColor();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void ChangeColor()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        rend.material.color = colors[colorIndex];
    }
}