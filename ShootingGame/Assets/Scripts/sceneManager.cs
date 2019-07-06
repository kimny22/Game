using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    public Canvas playingScreen;
    public Canvas gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.gameOver == true)
        {
            gameOverScreen.enabled = true;
            playingScreen.enabled = false;
        }
        if(Enemy.playing == true)
        {
            gameOverScreen.enabled = false;
            playingScreen.enabled = true;
        }
    }
}
