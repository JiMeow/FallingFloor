using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 target;
    Vector3 startpos;

    [SerializeField] FloatingJoystick joystick;
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
        float up = joystick.Vertical / 1;
        float down = joystick.Vertical / -0.5f;
        float left = joystick.Horizontal / -1;
        float right = joystick.Horizontal / 1;
        float max = Mathf.Max(up, down, left, right);
        if (max < 0.1f)
        {
            max = 10000f;
        }
        if (target == new Vector3(0, 0, 0))
        {
            gameObject.transform.GetChild(5).GetComponent<AnimationController>().setWalking(false);
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || max == up) && w)
            {
                target = new Vector3(0.6f, 0.3f, 0);
                startpos = transform.position;
                gameObject.transform.GetChild(5).GetComponent<Transform>().localScale = new Vector3(-2f, 2f, 1);
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || max == left) && a)
            {
                target = new Vector3(-0.6f, 0.3f, 0);
                startpos = transform.position;
                gameObject.transform.GetChild(5).GetComponent<Transform>().localScale = new Vector3(2f, 2f, 1);
            }
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || max == down) && s)
            {
                target = new Vector3(-0.6f, -0.3f, 0);
                startpos = transform.position;
                gameObject.transform.GetChild(5).GetComponent<Transform>().localScale = new Vector3(2f, 2f, 1);
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || max == right) && d)
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
