using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTest : MonoBehaviour //플래쉬&심장마비 코드
{
    public static Light lt;
    public static bool lightOn;
    public AudioSource shutter;
    public AudioSource heart;
    float count = 0f;
    float nowTime;
    float deadTime;
    bool end;
    int heartCount = 0;
    void Start()
    {
        lt = GetComponent<Light>();
        lt.enabled = false;
        lightOn = false;
        end = false;
        nowTime = 0f;
        deadTime = Time.time;
    }

    void Update()
    {
        if (lt.enabled == true && ending.appeared2 == false) //점점 어두워짐
        {
            lt.color -= Color.white * Time.deltaTime * 0.7f;
            count += Time.deltaTime;
            lightOn = false;
        }
        if (count > 2.15f) //완전히 까맣게 되고 난 후 플래쉬 초기화
        {
            lt.enabled = false;
            lt.color = Color.white;
            count = 0f;
        }
        if (ending.appeared2) //해피엔딩에서 화면 밝아짐
        {
            lt.intensity += 100 * Time.deltaTime;
            lt.range += 300 * Time.deltaTime;
        }
        //배드엔딩에서 자동으로 플래시 켜짐
        if (ending.appeared && !end && nowTime == 0) { nowTime = Time.time; end = true; }
        if (ending.appeared && end && Time.time - nowTime > 5f) { flashOn(); end = false; }
        //플래쉬를 너무 긴 시간 동안 안 켜면 심장마비 엔딩
        if (Time.time - deadTime > 12f) sceneManager.changeSceneToHeartAttack();
        if (heartCount > 240/(Time.time - deadTime)) //플래시 안키고 있으면 심장소리 점점 빨라짐
        {
            heart.Play();
            heartCount = 0;
        }
        heartCount++;
    }
    public void flashOn() //플래쉬가 켜짐
    {
        lt.enabled = true;
        lightOn = true;
        shutter.Play();
        deadTime = Time.time;
    }
}
