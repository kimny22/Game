using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    private Vector3 original;
    public Transform player;
    private bool updating = true;
	// Use this for initialization
	void Start () {
        original = player.position - transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
        if (updating)
        {
            transform.position = player.position - original;
        }
	}

    public void stopUpdating()
    {
        updating = false;
    }
}