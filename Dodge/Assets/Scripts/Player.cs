using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 character_pos;
    Vector3 pos;
    public Text timeSet;
    public Text plusPoint;
    public Canvas endGame;
    bool isPause = false;
    bool effect = false;
    float nowTime;
    float plusTime;
    // Use this for initialization
    void Start()
    {
        endGame.enabled = false;
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeSet.text = ((int)(Time.time-nowTime)).ToString();
        if (Input.GetMouseButton(0) && endGame.enabled == false)
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z-Camera.main.transform.position.z));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isPause)
            {
                Time.timeScale = 1;
                isPause = false;
            }
            else
            {
                Time.timeScale = 0;
                isPause = true;
            }
        }
        character_pos.x = Mathf.Lerp(character_pos.x, pos.x, 0.1f);
        transform.position = new Vector3(character_pos.x, transform.position.y, transform.position.z);
        if(effect == true)
        {
            plusPoint.text = "+10";
            plusTime = Time.time;
            nowTime -= 10;
            effect = false;
        }
        if (Time.time - plusTime > 1) plusPoint.text = "";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            Debug.Log("hit box");
            Renderer Color = other.GetComponent<Renderer>();
            Color.material.color = new Color(1f, 0f, 0f);
            Time.timeScale = 0;
            endGame.enabled = true;
        }
        if(other.tag == "item")
        {
            Debug.Log("get item");
            Destroy(other.gameObject);
            effect = true;
        }
    }
    public void restart()
    {
        endGame.enabled = false;
        Time.timeScale = 1;
        nowTime = Time.time;
    }
}