using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    public Text spaceText;
    public float speed;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        GameObject[] gm = GameObject.FindGameObjectsWithTag("items");
        count = gm.Length;
        SetCountText();
        winText.text = "";
        spaceText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.Space)&&!jumping)
        {
            AudioSource boing = GetComponent<AudioSource>();
            boing.Play();
            StartCoroutine(jump());
        }
        int stage = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(stage);
        GameObject[] gm = GameObject.FindGameObjectsWithTag("items");
        if(gm.Length<1)
        {
            GameObject camobject = GameObject.Find("Main Camera");
            camobject.GetComponent<camera>().stopUpdating();
            winText.text = "You Win!";
            if(stage < 4) spaceText.text = "Press spacebar";
            if (stage == 4) spaceText.text = "Congratulations";
            if (Input.GetKey(KeyCode.Space) && stage<5)
                SceneManager.LoadScene(++stage);
        }

    }
    bool jumping = false;
    IEnumerator jump()
    {
        jumping = true;
        int t = 0;
        while(true)
        {
            if (t > 5) break;
            yield return null;
            t++;
            rb.AddForce(0f, speed * (15f - 2f * t), 0);
        }
        yield return new WaitForSecondsRealtime(1f);
        jumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("items"))
        {
            other.gameObject.SetActive(false);
            GameObject[] gm = GameObject.FindGameObjectsWithTag("items");
            count = gm.Length;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Left : " + count.ToString();
    }
}
