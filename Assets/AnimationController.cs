using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    bool isWalking = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isWalk", isWalking);
    }

    public void setWalking(bool b)
    {
        isWalking = b;
    }
}
