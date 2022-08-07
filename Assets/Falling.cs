using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    float time = 0;
    Rigidbody2D rb;
    bool isFalling = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFalling)
        {
            if (time == 0)
            {
                time = Time.time;
            }
            else if (Time.time - time > 0.15f && rb.gravityScale == 0)
            {
                rb.gravityScale = 1;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 20f);
            }
        }
        else
        {
            time = 0;
        }
    }

    public void SetFalling(bool falling)
    {
        isFalling = falling;
    }
}
