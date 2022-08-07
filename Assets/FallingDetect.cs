using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDetect : MonoBehaviour
{
    Falling player;
    FloorController floorController;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Falling>();
        floorController = GameObject.Find("Floor").GetComponent<FloorController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            player.SetFalling(false);
            floorController.SetOnFloor(other.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            player.SetFalling(false);
            floorController.SetOnFloor(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            player.SetFalling(true);
        }
    }
}
