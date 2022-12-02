using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    //reference to obstacle for speed
    public Obstacle_Behavior obstacle;

    //reference to bullet for score
    public Player_Interactions player;

    //reference to text component
    public Text score;

    //update is called once per frame
    void Update()
    {
        //display score and speed
        score.text = "Score: " + player.points.ToString("0") + "\r\nSpeed: " + obstacle.obstacleSpeed.ToString("F1");
    }
}
