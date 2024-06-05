using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Renderer rend;
    private Color[] colors = { Color.red, new Color(1.0f, 0.5f, 0.0f), Color.yellow, Color.green, Color.blue, new Color(0.0f, 1.0f, 1.0f), Color.magenta };
    private int colorIndex = 0;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.material.color = colors[colorIndex];

        rb.velocity = Vector3.right * 2f; // 初始向右移动
    }

    void Update()
    {
        MoveBall();
    }

    void MoveBall()
    {
        if (transform.position.x >= 10f)
        {
            movingRight = false;
            ChangeColor();
            StartCoroutine(ReverseMovement());
        }
        else if (transform.position.x <= 0f)
        {
            movingRight = true;
            ChangeColor();
            StartCoroutine(ReverseMovement());
        }
    }

    IEnumerator ReverseMovement()
    {
        rb.velocity = Vector3.zero; // 停止移动
        yield return new WaitForSeconds(1f); // 停顿1秒
        if (movingRight)
        {
            rb.velocity = Vector3.right * 2f;
        }
        else
        {
            rb.velocity = Vector3.left * 2f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            ChangeColor();
            StartCoroutine(ReverseMovement());
        }
    }

    void ChangeColor()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        rend.material.color = colors[colorIndex];
    }
}