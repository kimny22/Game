using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(30, 45, 14) * Time.deltaTime);
	}
}
