using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float r = Time.time;
        Debug.Log(r);
        transform.localRotation = Quaternion.Euler(new Vector3(0, r*50, 0));

    }
}
