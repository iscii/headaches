using UnityEngine;

public class Booster_Behavior : MonoBehaviour
{
    //reference to obstacle
    private GameObject obstacle;

    //reference to BoxCollider2D component of booster
    private BoxCollider2D collider1;

    //reference to +10 daughter
    private GameObject collected;

    //reference to Animator component of sugar.
    private Animator animator;

    //reference to audiosource component
    private AudioSource boosterAudio;

    //set variable boosterSpeed
    public float boosterSpeed = 8;

    // Start is called before the first frame update
    void Start()
    {
        //reference to obstacle
        obstacle = GameObject.Find("Obstacle");
        //reference to boxcollider2d component
        collider1 = gameObject.GetComponent<BoxCollider2D>();
        //refer to animator component
        animator = GameObject.Find("+10").GetComponent<Animator>();
        //refer to +10 daughter
        collected = GameObject.Find("+10");
        boosterAudio = gameObject.GetComponent<AudioSource>();
    }

    //update is called once per frame
    private void Update()
    {
        //simplification: x-position of sugar
        var xPos = transform.position.x;
        //random number generator variable to determine when sugar appears
        int randNum = Random.Range(1, 1500);
        //if the sugar is out of scene and random number is 125, spawn sugar
        //prevents premature spawning while in scene
        if(xPos <= -9.6f && randNum == 666)
        {
            BoosterSpawn();
            collected.SendMessage("GoToBooster");
        }

        //if the sugar is in the scene, move left
        if(xPos > -10.6f)
        {
            transform.Translate(Vector2.left * boosterSpeed * Time.deltaTime, 0f);
        }
    }

    //called on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collision with player, teleport out of scene
        if (collision.CompareTag("Player"))
        {
            //turns of collider
            collider1.enabled = false;
            //hides sprite
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //turn on collected animation
            animator.SetBool("isCollected", true);
            //turn off static animation
            animator.SetBool("isSpawned", false);
            //play booster sound effect
            boosterAudio.Play();
        }
    }

    //method for spawning sugar
    public void BoosterSpawn()
    {
        //simplification: variable for the y-position of Obstacle. True = up. False = down.
        bool yPosObstacle = true;

        //enables collider
        collider1.enabled = true;

        //used so sugar does not spawn behind the obstacle. If Obstacle is up, sugar spawns down. If it is down, sugar spawns up.
        if (obstacle.transform.position.y > 0)
        {
            yPosObstacle = true;
        }
        else if (obstacle.transform.position.y < 0)
        {
            yPosObstacle = false;
        }
        //50% chance to spawn sugar up
        if (yPosObstacle == true)
        {
            //teleport sugar to beginning of screen. Used float values for the y-position to give it a greater variety, rather than just integers. down.
            transform.position = new Vector2(Random.Range(9.5f, 11.5f), Random.Range(-1.90f, -3.90f));
        }
        //50% chance to spawn sugar below
        if (yPosObstacle == false)
        {
            //teleport sugar to beginning of screen. Used float values for the y-position to give it a greater variety, rather than just integers. up.
            transform.position = new Vector2(Random.Range(9.5f, 11.5f), Random.Range(1.90f, 3.90f));
        }
    }

    //method to leave scene
    public void LeaveScene()
    {
        //teleports out of scene
        transform.position = new Vector2(-10f, transform.position.y);
        //shows sprite
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //turn on static animation
        animator.SetBool("isSpawned", true);
        //turn off collected animation
        animator.SetBool("isCollected", false);
    }

    //method to stop script
    public void Stop()
    {
        //disables script
        enabled = false;
    }
}
