using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTest : MonoBehaviour //효과음 관리 코드
{
    public static int soundNum = 0;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    public AudioSource sound4;
    void Start()
    {
        sound1.enabled = false;
        sound2.enabled = false;
        sound3.enabled = false;
        sound4.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (soundNum == 1) sound1.enabled = true;
        if (soundNum == 2) sound2.enabled = true;
        if (soundNum == 3) sound3.enabled = true;
        if (soundNum == 4) sound4.enabled = true;
        if (soundNum == 5) //초기화
        {
            sound1.enabled = false;
            sound2.enabled = false;
            sound3.enabled = false;
            sound4.enabled = false;
        }
    }
}
