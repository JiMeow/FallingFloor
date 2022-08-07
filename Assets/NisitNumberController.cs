using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NisitNumberController : MonoBehaviour
{
    [SerializeField]
    Text score;
    void Update()
    {
        int scoreInt = int.Parse(score.text);
        int show = scoreInt / 30;
        if (show == 0)
        {
            return;
        }
        GameObject nisitNumber = gameObject.transform.GetChild(show - 1).gameObject;
        nisitNumber.SetActive(true);
    }
}
