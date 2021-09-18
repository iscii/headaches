using UnityEngine;

public class Sugar_Behavior : MonoBehaviour
{
    //reference to Obstacle
    private GameObject obstacle;

    //reference to colliders of sugar
    private CircleCollider2D collider1;
    private CapsuleCollider2D collider2;

    //reference to Animator component of sugar.
    private Animator animator;

    //reference to sugar's audiosource
    private AudioSource sugarAudio;

    //set variable sugarSpeed
    public float sugarSpeed = 3;

    //start is called before the first frame update
    private void Start()
    {
        //reference to obstacle
        obstacle = GameObject.Find("Obstacle");
        //reference to collider components
        collider1 = gameObject.GetComponent<CircleCollider2D>();
        collider2 = gameObject.GetComponent<CapsuleCollider2D>();
        //reference to animator component of sugar
        animator = GameObject.Find("+1").GetComponent<Animator>();
        //refer to audiosource
        sugarAudio = gameObject.GetComponent<AudioSource>();
        //spawn sugar at random place
        SugarSpawn();
    }

    //called on collision detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if sugar collided with the Bullet
        if (collision.CompareTag("Player"))
        {
            //disables colliders
            collider1.enabled = false;
            collider2.enabled = false;
            //hide sugar sprite
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //turn on collected animation
            animator.SetBool("isCollected", true);
            //turn off static animation
            animator.SetBool("isSpawned", false);
            //play sugar sound effect
            sugarAudio.Play();
        }
        //respawn if colliding with obstacle
        if (collision.CompareTag("Obstacle"))
        {
            SugarSpawn();
        }
    }

    //update is called once per frame
    void Update()
    {
        //simplification: create variable for xy-position of Sugar.
        var xPos = transform.position.x;

        //move left
        transform.Translate(Vector2.left * sugarSpeed * Time.deltaTime);

        //if sugar goes out of bounds, respawn it
        if (xPos <= -9.6f)
        {
            SugarSpawn();
        }
    }

    //method for respawning sugar.
    public void SugarSpawn()
    {
        //simplification: variable for the y-position of Obstacle. True = up. False = down.
        bool yPosObstacle = true;

        //show sugar sprite
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //turn on static animation
        animator.SetBool("isSpawned", true);
        //enables colliders
        collider1.enabled = true;
        collider2.enabled = true;

        //used so sugar does not spawn behind the obstacle. If Obstacle is up, sugar spawns down. If it is down, sugar spawns up.
        if(obstacle.transform.position.y > 0)
        {
            yPosObstacle = true;
        }
        else if(obstacle.transform.position.y < 0)
        {
            yPosObstacle = false;
        }
        //50% chance to spawn sugar up
        if (yPosObstacle == true)
        {
            //teleport sugar to beginning of screen. Used float values for the y-position to give it a greater variety, rather than just integers. down.
            transform.position = new Vector2(Random.Range(9.5f,11.5f), Random.Range(-1.90f, -3.90f));
        }
        //50% chance to spawn sugar below
        if (yPosObstacle == false)
        {
            //teleport sugar to beginning of screen. Used float values for the y-position to give it a greater variety, rather than just integers. up.
            transform.position = new Vector2(Random.Range(9.5f, 11.5f), Random.Range(1.90f, 2.90f));
        }
        //turn off collected animation
        animator.SetBool("isCollected", false);
    }

    //method to stop scriot
    public void Stop()
    {
        //disables script
        enabled = false;
    }
}
