using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenTouch : MonoBehaviour
{

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
