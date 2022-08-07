using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCountController : MonoBehaviour
{
    private static DeathCountController deathCountController;
    void Start()
    {
        DontDestroyOnLoad(this);

        if (deathCountController == null)
        {
            deathCountController = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseDeathCount()
    {
        Text deathCountText = gameObject.transform.GetChild(0).GetComponent<Text>();
        int deathCount = int.Parse(deathCountText.text);
        deathCount++;
        deathCountText.text = deathCount.ToString();
    }
}
