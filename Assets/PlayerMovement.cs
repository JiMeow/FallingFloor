using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 target;
    Vector3 startpos;
    public bool w = true, a = true, s = true, d = true;
    void Start()
    {
        target = new Vector3(0, 0, 0);
        startpos = new Vector3(0, 0, 0);
    }

    void Update()
    {
        MoveObject();
    }
    void MoveObject()
    {
        if (target == new Vector3(0, 0, 0))
        {
            gameObject.transform.GetChild(5).GetComponent<AnimationController>().setWalking(false);
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && w)
            {
                target = new Vector3(0.6f, 0.3f, 0);
                startpos = transform.position;
                gameObject.transform.GetChild(5).GetComponent<Transform>().localScale = new Vector3(-2f, 2f, 1);
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && a)
            {
                target = new Vector3(-0.6f, 0.3f, 0);
                startpos = transform.position;
                gameObject.transform.GetChild(5).GetComponent<Transform>().localScale = new Vector3(2f, 2f, 1);
            }
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && s)
            {
                target = new Vector3(-0.6f, -0.3f, 0);
                startpos = transform.position;
                gameObject.transform.GetChild(5).GetComponent<Transform>().localScale = new Vector3(2f, 2f, 1);
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && d)
            {
                target = new Vector3(0.6f, -0.3f, 0);
                startpos = transform.position;
                gameObject.transform.GetChild(5).GetComponent<Transform>().localScale = new Vector3(-2f, 2f, 1);
            }
        }
        else
        {
            gameObject.transform.GetChild(5).GetComponent<AnimationController>().setWalking(true);
            transform.position = Vector3.MoveTowards(transform.position, startpos + target, 1.0f * Time.deltaTime);
            if (transform.position == startpos + target)
            {
                target = new Vector3(0, 0, 0);
            }
        }
    }

    public void setBool(char c, bool b)
    {
        if (c == 'w')
        {
            w = b;
        }
        if (c == 'a')
        {
            a = b;
        }
        if (c == 's')
        {
            s = b;
        }
        if (c == 'd')
        {
            d = b;
        }
    }
}
