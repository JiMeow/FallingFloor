using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloorController : MonoBehaviour
{
    float t = -5f;
    GameObject onFloor, player;
    Text score;
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        int nowScore = int.Parse(score.text);
        int random = 0;
        if (Time.time - t > 3f / (nowScore + 1))
        {
            t = Time.time;
            random = Random.Range(0, 101);
            GameObject floor;
            if (random <= 80)
            {
                floor = GameObject.Find("Isometric Diamond (" + random + ")");
            }
            else
            {
                floor = onFloor;
            }
            if (floor != null && floor.GetComponent<SpriteRenderer>().color == new Color(1.0f, 1.0f, 1.0f, 1.0f))
                StartCoroutine(DestroyFloor(floor));
        }
    }

    IEnumerator DestroyFloor(GameObject floor)
    {
        SpriteRenderer sprite = floor.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            sprite.color = new Color(100, sprite.color[1] - 0.01f, sprite.color[2] - 0.01f, 100);
        }
        floor.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        floor.SetActive(true);
        if (player.GetComponent<Rigidbody2D>().gravityScale == 0)
        {
            score.text = (int.Parse(score.text) + 1).ToString();
        }
    }

    public void SetOnFloor(GameObject floor)
    {
        onFloor = floor;
    }
}
