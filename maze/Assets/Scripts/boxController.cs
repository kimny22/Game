using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour {

    public GameObject boxObject;
    float nowTime;

	// Use this for initialization
	void Start () {
        nowTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - nowTime > 0.5f)
        {
            GameObject part = Instantiate(boxObject, new Vector3(0f, 20f, 0f), Quaternion.identity);
            part.GetComponent<boxMove>().setPosition(Random.Range(-10, 10), 4f, Random.Range(0.05f, 0.1f));
            nowTime = Time.time;
        }
	}
}
