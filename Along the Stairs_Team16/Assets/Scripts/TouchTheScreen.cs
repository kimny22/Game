using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchTheScreen : MonoBehaviour //인트로 자막 코드
{
    float nowTime;
    public Button startButton;
    public AudioSource man;
    public Canvas black;
    public Canvas letter;
    public Text voiceText,voiceText2;
    void Start()
    {
        nowTime = Time.time;
        startButton.enabled = false;
        man.enabled = false;
        letter.enabled = false;
        voiceText.text = "Where am I...?";
    }
    void Update()
    {
        if (Time.time - nowTime > 1.1f) //자막
            voiceText.text = "I can't see anything.";
        if (Time.time - nowTime > 3.1f)
            voiceText.text = "I thought I was hit by a car, but I don't remember after that.";
        if (Time.time - nowTime > 6.8f)
            voiceText.text = "It's so scary.";
        if (Time.time - nowTime > 10f) //남자 성우 출력
        {
            black.enabled = false;
            man.enabled = true;
            letter.enabled = true;
        }

        if (Time.time - nowTime > 10f)
            voiceText2.text = "The game is started.";
        if (Time.time - nowTime > 12f)
            voiceText2.text = "You have to go down the stairs to get out.";
        if (Time.time - nowTime > 15f)
            voiceText2.text = "The only tool you can use is camera flash.";
        if (Time.time - nowTime > 18.3f)
            voiceText2.text = "GOOD LUCK";
        if (Time.time - nowTime > 18f) //성우 대사가 끝나고 게임 규칙으로 넘어가는 버튼 활성화
        {
            startButton.enabled = true;
        }
    }
}
