using UnityEngine;

public class Obstacle_Behavior : MonoBehaviour
{    
    //reference to Animator component for player
    public Animator playerAnimator;
    //set variable obstacleSpeed
    public float obstacleSpeed = 3;
    //set variable for y limit
    public float yLimit;

    //start is called before the first frame update.
    private void Start()
    {
        //spawn the sugar at random place
        ObstacleSpawn();

        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    //update is called once per frame.
    void Update()
    {
        //simplification: create variable for xy-position of Obstacle.
        var xPos = transform.position.x;

        //move left.
        transform.Translate(Vector2.left * obstacleSpeed * Time.deltaTime);

        //when obstacle is out of screen, reset to beginning of screen.
        if (xPos <= -11.9f)
        {
            //spawn the obstacle
            ObstacleSpawn();
        }

        //set obstacleSpeed parameter in Player Animation to obstacleSpeed.
        playerAnimator.SetFloat("obstacleSpeed", obstacleSpeed);
    }

    //method for respawning obstacle.
    public void ObstacleSpawn()
    {
        //change y-limit of obstacle
        if (obstacleSpeed < 5)
        {
            yLimit = 5.9f;
        }
        else if (obstacleSpeed >= 5 && obstacleSpeed < 7)
        {
            yLimit = 4.9f;
        }
        else if (obstacleSpeed >= 7 && obstacleSpeed <= 9)
        {
            yLimit = 3.9f;
        }

        //set integer yPosRandom random number 1 or 2. Setting a random boolean is too complicated.
        int yPosRandom = Random.Range(1, 3);

        //50% chance to spawn obstacle up
        if (yPosRandom == 1)
        {
            //teleport obstacle to beginning of screen. Used float values for the y-position to give it a greater variety, rather than just integers.
            transform.position = new Vector2(11.5f, Random.Range(yLimit - 2f, yLimit));
        }
        //50% chance to spawn obstacle below
        if (yPosRandom == 2)
        {
            //*5^
            transform.position = new Vector2(11.5f, Random.Range(-yLimit + 2f, -yLimit));
        }
    }

    //method to stop script
    public void Stop()
    {
        //disables script
        enabled = false;
    }
}
