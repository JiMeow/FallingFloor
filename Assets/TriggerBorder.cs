using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBorder : MonoBehaviour
{
    PlayerMovement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            if (gameObject.name == "trigger_w")
            {
                player.setBool('w', false);
            }
            if (gameObject.name == "trigger_a")
            {
                player.setBool('a', false);
            }
            if (gameObject.name == "trigger_s")
            {
                player.setBool('s', false);
            }
            if (gameObject.name == "trigger_d")
            {
                player.setBool('d', false);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            if (gameObject.name == "trigger_w")
            {
                player.setBool('w', false);
            }
            if (gameObject.name == "trigger_a")
            {
                player.setBool('a', false);
            }
            if (gameObject.name == "trigger_s")
            {
                player.setBool('s', false);
            }
            if (gameObject.name == "trigger_d")
            {
                player.setBool('d', false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            if (gameObject.name == "trigger_w")
            {
                player.setBool('w', true);
            }
            if (gameObject.name == "trigger_a")
            {
                player.setBool('a', true);
            }
            if (gameObject.name == "trigger_s")
            {
                player.setBool('s', true);
            }
            if (gameObject.name == "trigger_d")
            {
                player.setBool('d', true);
            }
        }
    }
}
