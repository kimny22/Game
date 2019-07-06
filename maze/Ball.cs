using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Rigidbody ballRigidBody;
    public Camera myCamera;
    Vector3 cameraDist;
    public Canvas endGame;

    void Awake()
    {

    }
    // Use this for initialization
    void Start () {
        ballRigidBody = GetComponent<Rigidbody>();
        transform.position = new Vector3(0f, 1f, 0f);
        cameraDist = myCamera.transform.position - transform.position;
        endGame.enabled = false;
    }
	
	// Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("Horiziontal : " + h +"  "+ "Vertical : " + v);

        ballRigidBody.AddForce(new Vector3(h, 0, v));

        myCamera.transform.position = transform.position + cameraDist;

        /*
        if(Input.GetMouseButton(0))
        {
            Renderer boxColor = GetComponent<Renderer>();
            boxColor.material.color = new Color(1f, 0f, 0f);
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box")
        {
            Debug.Log("hit box");
            Renderer boxColor = other.GetComponent<Renderer>();
            boxColor.material.color = new Color(1f, 0f, 0f);
            endGame.enabled = true;
        }
    }

    public void Restart()
    {
        transform.position = new Vector3(0f, 1f, 0f);
        endGame.enabled = false;
    }

    /*

 void OnCollisionEnter(Collision collision)
 {
     if (collision.gameObject.CompareTag("Box"))          // 부딛힌 오브젝트의 태그가 Box라면..
     {

         Renderer boxColor = collision.gameObject.GetComponent<Renderer>();
         boxColor.material.color = new Color(1f, 0f, 0f);
     }

 }
 */
}
