using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchTheScreen2 : MonoBehaviour //조작법 장면 코드
{
    float nowTime;
    public Button startButton;
    void Start()
    {
        nowTime = Time.time;
        startButton.enabled = false;
    }
    void Update()
    {
        if (Time.time - nowTime > 1f) //잠시 후 게임 시작 가능
        {
            startButton.enabled = true;
        }
    }
}
