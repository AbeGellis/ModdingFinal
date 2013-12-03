using UnityEngine;
using System.Collections;

//life control. contains functions to remove hearts from GUI and put them back in case of restart.
public class lifeControl : MonoBehaviour
{

    //player starts at 3 lives. change in other scripts using lifeControl.lives
    static public int lives = 3;

    //the heart textures
    public GUITexture heart1;
    public GUITexture heart2;
    public GUITexture heart3;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //to remove an on-screen heart once player dies. call using lifeControl.removeHeart()
    public void removeHeart()
    {
        if (lives < 0)
            Application.LoadLevel("GameOver");
        else if (lives == 0)
            heart1.enabled = false;
        else if (lives == 1)
            heart2.enabled = false;
        else if (lives == 2)
            heart3.enabled = false;
    }

    //when player presses P, call this function by using lifeControl.restart()
    public void restart()
    {
        heart1.enabled = true;
        heart2.enabled = true;
        heart3.enabled = true;
    }
}
