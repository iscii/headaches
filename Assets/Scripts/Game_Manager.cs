using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //reference to pause menu
    public GameObject pause;
    //reference to game
    public GameObject game;
    //reference to background
    public GameObject background;
    //reference to background2
    public GameObject background2;
    //reference to bullet
    public GameObject player;
    //reference to obstacle
    public GameObject obstacle;
    //reference to sugar
    public GameObject sugar;
    //reference to sugar
    public GameObject booster;
    //reference to slingshot
    public GameObject slingshot;

    //create public variable for Speed Level.
    public int speedLevel;

    //store global variables.
    public static class Globals
    {
        //global variable for points
        public static int points = 0;
    }

    //start is called before the first frame update
    public void Start()
    {
        //function to execute a code after 3 seconds
        IEnumerator StartScripts(float time)
        {
            //yield return or whatever it does
            yield return new WaitForSeconds(time);

            //starts scripts after 4 seconds
            obstacle.GetComponent<Obstacle_Behavior>().enabled = true;
            sugar.GetComponent<Sugar_Behavior>().enabled = true;
            booster.GetComponent<Booster_Behavior>().enabled = true;
        }
        //runs the function above
        StartCoroutine(StartScripts(6));
    }

    //update is called during each frame update
    public void Update()
    {
        //speedLevel = 1 between speeds 3 and 5
        if(obstacle.GetComponent<Obstacle_Behavior>().obstacleSpeed >= 3f && obstacle.GetComponent<Obstacle_Behavior>().obstacleSpeed <= 5f)
        {
            speedLevel = 1;
        }
        //speedLevel = 2 between speeds 5 and 7
        if (obstacle.GetComponent<Obstacle_Behavior>().obstacleSpeed >= 5f && obstacle.GetComponent<Obstacle_Behavior>().obstacleSpeed <= 7f)
        {
            speedLevel = 2;
        }
        //speedLevel = 3 between speeds 7 and 9
        if (obstacle.GetComponent<Obstacle_Behavior>().obstacleSpeed >= 7f && obstacle.GetComponent<Obstacle_Behavior>().obstacleSpeed <= 9f)
        {
            speedLevel = 3;
        }

        //to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //enable pause menu & disable game
            game.SetActive(false);
            pause.SetActive(true);
            //pause theme music
            gameObject.GetComponent<AudioSource>().Pause();
        }
    }
}
