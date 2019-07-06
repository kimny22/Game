using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    float xpos;
    float ypos;
    float zpos;
    float speed = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(xpos, ypos, zpos);
        ypos += speed;
        if(ypos > 7f)
        {
            Destroy(gameObject);
        }
	}
    
    public void AddBullet(float x, float y, float z)
    {
        xpos = x;
        ypos = y;
        zpos = z;
    }
}
