using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            StartCoroutine(StopSound());
        }
    }

    IEnumerator StopSound()
    {
        yield return new WaitForSecondsRealtime(5f);
        audioSource.Pause();
    }
}
