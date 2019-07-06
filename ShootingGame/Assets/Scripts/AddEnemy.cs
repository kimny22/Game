using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour {

    float nowTime;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        nowTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - nowTime > 0.5f)
        {
            GameObject p = Instantiate(enemy, new Vector3(Random.Range(-3, 3), 7, 0), Quaternion.identity);
            nowTime = Time.time;
        }
	}
}
