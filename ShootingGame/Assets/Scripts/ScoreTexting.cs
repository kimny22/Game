using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTexting : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE : 0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE : " + Enemy.score;
    }
}
