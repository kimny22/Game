using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseTest : MonoBehaviour //조작 관련 코드
{
    float xpos, ypos, zpos;
    float a = 0;
    Vector3 mousePos1;
    public Camera myCamera;
    Vector3 cameraDist;
    void Start()
    {
        cameraDist = myCamera.transform.position - transform.position; //카메라 거리
    }

    void Update()
    {
        if (ending.appeared == false)
        {
            xpos = GetComponent<Transform>().position.x;
            ypos = GetComponent<Transform>().position.y;
            zpos = GetComponent<Transform>().position.z;
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < 960) //클릭했을 때의 마우스 좌표
            {
                mousePos1 = Input.mousePosition;
            }
            //move
            if (Input.mousePosition.x < 960 && Input.GetMouseButton(0) && Input.mousePosition.y - mousePos1.y > 0) //위로 스크롤하고 유지하면 직진
            {
                a = Input.mousePosition.y - mousePos1.y;
                if (a > 300) a = 300; //속도 최대값 제한
                zpos += 0.0006f * a; //스크롤한 길이에 따른 속도로 전진
            }
            if (Input.mousePosition.x < 960 && Input.GetMouseButton(0) && Input.mousePosition.y - mousePos1.y < 0) //아래로 스크롤하고 유지하면 후진
            {
                a = Input.mousePosition.y - mousePos1.y;
                if (a < -300) a = -300; //속도 최대값 제한
                zpos += 0.0006f * a; //스크롤한 길이에 따른 속도로 후진
            }
            transform.position = new Vector3(xpos, ypos, zpos);
            myCamera.transform.position = transform.position + cameraDist;
        }
        
    }
}