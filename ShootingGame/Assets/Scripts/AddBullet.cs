using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullet : MonoBehaviour {

    float nowTime;
    public GameObject bullet;
    public ShotButton shot;
	// Use this for initialization
	void Start () {
        nowTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (shot.Pressed == true && Time.time - nowTime > 0.3f)
        {
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.GetComponent<BulletMove>().AddBullet(transform.position.x, transform.position.y, transform.position.z);
            nowTime = Time.time;
        }
	}
}
