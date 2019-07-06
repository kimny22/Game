using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public static int score=0;
    float xpos;
    float ypos;
    float xspeed;
    float yspeed;
    public static bool playing;
    public static bool gameOver;
    // Use this for initialization
    void Start()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
        transform.Rotate(new Vector3(90, 0, 0));
        xspeed = Random.Range(-0.01f, 0.01f);
        yspeed = Random.Range(-0.05f, -0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        xpos = xpos + xspeed;
        ypos = ypos + yspeed;
        transform.position = new Vector3(xpos, ypos, 0);
        if(ypos < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("hit");
            score++;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.tag == "Air")
        {
            Debug.Log("game over");
            Destroy(gameObject);
            Destroy(other.gameObject);
            playing = false;
            gameOver = true;
        }
    }
}

