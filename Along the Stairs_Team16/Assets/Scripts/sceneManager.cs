using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour //장면 전환 코드
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeSceneToIntro() //인트로
    {
        SceneManager.LoadScene(1);
    }
    public void changeSceneToRule() //게임규칙
    {
        SceneManager.LoadScene(2);
    }
    public void changeSceneToGame() //본게임
    {
        SceneManager.LoadScene(3);
    }
    public static void changeSceneToBad() //배드엔딩
    {
        SceneManager.LoadScene(4);
    }
    public static void changeSceneToHappy() //해피엔딩
    {
        SceneManager.LoadScene(5);
    }
    public static void changeSceneToHeartAttack() //심장마비엔딩
    {
        SceneManager.LoadScene(6);
    }
    public void quit() //앱 종료
    {
        Application.Quit();
    }
}
