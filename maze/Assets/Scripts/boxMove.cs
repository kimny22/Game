using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMove : MonoBehaviour {

    float xpos;
    float ypos;
    float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(xpos, ypos, 0f);
        ypos -= speed;

        if (ypos < -2f)
        {
            Destroy(gameObject);
        }
	}

    public void setPosition(float x, float y, float s)
    {
        xpos = x;
        ypos = y;
        speed = s;
    }
}
