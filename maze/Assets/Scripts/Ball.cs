using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    Rigidbody ballRigidBody; //공 굴림
    public Camera myCamera; //카메라
    Vector3 cameraDist; //공에서 카메라까지 거리
    public Canvas endGame; //종료 화면
    public Canvas playing; //플레이 중 화면
    public Text countText; //카운트다운
    public Text endText; //종료 메시지
    float nowTime; //시작시간
    void Awake()
    {

    }
    // Use this for initialization
    void Start () {
        ballRigidBody = GetComponent<Rigidbody>();
        transform.position = new Vector3(0f, 1f, 0f);
        cameraDist = myCamera.transform.position - transform.position;
        endGame.enabled = false; //종료화면 끄기
        playing.enabled = true;
        nowTime = Time.time;
    }
	
	// Update is called once per frame
    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("Horiziontal : " + h +"  "+ "Vertical : " + v);
        float time = (60 - (Time.time - nowTime));
        time = (int) time;
        countText.text = time.ToString();

        if(endGame.enabled == false) ballRigidBody.AddForce(new Vector3(h*5, 0, v*5));
        if (time == 0 && playing.enabled == true) { endGame.enabled = true; playing.enabled = false; endText.text = "GAME OVER"; }
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
            playing.enabled = false;
            endText.text = "COMPLETED!";
        }
    }

    public void Restart()
    {
        transform.position = new Vector3(0f, 1f, 0f);
        endGame.enabled = false;
        playing.enabled = true;
        nowTime = Time.time;
        GameObject[] box = GameObject.FindGameObjectsWithTag("Box");
        Renderer boxColor = box[0].GetComponent<Renderer>();
        boxColor.material.color = new Color(1f, 1f, 1f);
    }

    
    /*
     void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Box"))          // 부딛힌 오브젝트의 태그가 Box라면..
         {

           Renderer boxColor = collision.gameObject.GetComponent<Renderer>();
           boxColor.material.color = new Color(1f, 0f, 0f);
           endGame.enabled = true;
         }

    }*/
 
}