using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ending : MonoBehaviour //배드,해피엔딩 화면 출력 코드
{
    public static int endStageHeight = 0;
    int endStageWidth, sound1, sound2, sound3;
    public GameObject mannequin, part;
    public static bool appeared,appeared2;
    float nowTime;
    public Button flashButton;
    int[] place,place2;
    int k = 0;
    void Start()
    {
        endStageHeight = Random.Range(8, 10);//엔딩 층수
        endStageWidth = Random.Range(1, 93);//엔딩 지점
        appeared = false;
        appeared2 = false;
        sound1 = Random.Range(2, 4);
        sound2 = Random.Range(5, 7);
        sound3 = Random.Range(7, endStageHeight);
        //계단에서는 엔딩이 등장하지 않게 엔딩 등장 범위 지정
        place = new int[3];
        place2 = new int[3];
        place[0] = 1181; place[1] = 1349; place[2] = 1516;
        place2[0] = 1279; place2[1] = 1446; place2[2] = 1860;
    }
    
    void Update()
    {
        int floor = (int)GetComponent<Transform>().position.y; //현재 층수
        int ail = (int)GetComponent<Transform>().position.z; //현재 지점
        if (k++ < 3)
        {
            if (lightTest.lightOn == true && ail >= 168 * (endStageHeight - 1) + 15 + endStageWidth && appeared == false) //손전등이 켜져있을 때만 엔딩 발생
            {
                if (ail >= place[k] && ail <= place2[k]) //현재 위치가 계단이 아닌지 검사
                {
                    part = Instantiate(mannequin, new Vector3(10f, floor + 3.8f, ail + 15f), Quaternion.identity); // 마네킹 생성
                    part.transform.Rotate(0, 180, 0);
                    appeared = true;
                    nowTime = Time.time;
                }
            }
            if (k == 2) k = 0;
        }
        if (appeared) soundTest.soundNum = 4; //엔딩사운드
        if (ail >= 168 * (sound1 - 1) + 40 && appeared == false) soundTest.soundNum = 1;
        if (ail >= 168 * (sound2 - 1) + 50 && appeared == false) soundTest.soundNum = 2;
        if (ail >= 168 * (sound3 - 1) + 20 && appeared == false) soundTest.soundNum = 3;  //랜덤 사운드 발생
        if (ail <= -270 && lightTest.lightOn && !appeared2) //뒤로 가면 이스터에그 - 해피엔딩
        {
            appeared2 = true;
            nowTime = Time.time;
        }
        if(Time.time - nowTime > 0.5f && appeared2) sceneManager.changeSceneToHappy(); //해피엔딩 장면으로 이동
        if (appeared)
        {
            flashButton.enabled = false; //엔딩 나올 때는 조작불가
            if ((Time.time - nowTime > 8.5f))
            {
                sceneManager.changeSceneToBad();//8.5초 후 배드엔딩씬으로
                soundTest.soundNum = 5; //사운드 종료
            }
            if (Time.time - nowTime > 5f)
            {
                part.transform.position = new Vector3(10f, floor + 0.5f, ail); //마네킹이 카메라 바로 앞으로 이동
            }
        }
    }
}