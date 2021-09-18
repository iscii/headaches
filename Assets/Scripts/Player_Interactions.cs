using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Interactions : MonoBehaviour
{
    //reference to bullet movement script's moveSpeed variable.
    private Player_Movement player;

    //reference to sugar behavior script
    public Sugar_Behavior sugar;

    //reference to obstacle behavior script
    public Obstacle_Behavior obstacle;

    //reference to sugar behavior script
    public Booster_Behavior booster;

    //reference to canvas
    public Deathscreen deathscreen;

    //reference to audio manager script 
    public AudioManager themeAudio;

    //reference to audio manager script
    private AudioSource deadAudio;

    //reference to background scroll script
    public Background_Scroller background;
    public Background_Scroller background2;

    //reference to global variable points
    public int points = Game_Manager.Globals.points;

    //create the variables for speed and point increase
    //playerInc default = 0.02f
    public float playerInc;
    //obstacleInc default = 0.03f
    public float obstacleInc;
    //sugarInc default = 0.03f
    public float sugarInc;
    //boosterInc default = 0.05f
    public float boosterInc;
    //backgroundInc default = 0.01f
    public float backgroundInc;

    //start is called before the first frame update
    private void Start()
    {
        //refer to Player_Movement script
        player = gameObject.GetComponent<Player_Movement>();
        //refer to AudioSource component
        deadAudio = gameObject.GetComponent<AudioSource>();
    }

    //call function on collision detection
    void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy bullet from collision with obstacle
        if (collision.CompareTag("Obstacle"))
        {
            //hide the bullet (both visually and physically)
            gameObject.GetComponent<Player_Movement>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("isDead");
            //pause the theme music
            themeAudio.themeAudio.Stop();
            //plays dead sound effect
            deadAudio.Play();
            //sends "Stop" to obstacle
            obstacle.SendMessage("Stop");
            //sends "Stop" to ballons
            sugar.SendMessage("Stop");
            //sends "Stop" to sugar
            booster.SendMessage("Stop");
            //sends "Stop" to background
            background.SendMessage("Stop");
            background2.SendMessage("Stop");

            //coroutine to activate deathscreen after half a second
            IEnumerator Deathscreen(float time)
            {
                yield return new WaitForSeconds(time);

                deathscreen.BroadcastMessage("Activate");
            }
            StartCoroutine(Deathscreen(0.5f));

            //coroutine to load menu scene after 3 seconds
            IEnumerator LoadMenuScene(float time)
            {
                yield return new WaitForSeconds(time);

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            StartCoroutine(LoadMenuScene(5));
            
        }
        //when colliding with sugars, call statement
        if (collision.CompareTag("Sugar"))
        {
            //add 1 point
            points += 1;

            //add 0.05 to bullet's moveSpeed. Max movespeed is 8
            if (player.moveSpeed < 7.96f)
            {
                player.moveSpeed += playerInc;
            }

            //add 0.1 movespeed to environmental objects. Max movespeed is 9
            if (obstacle.obstacleSpeed <8.99f)
            {
                //add 0.1f speed to obstacle's speed
                obstacle.obstacleSpeed += obstacleInc;
                //add 0.1f speed to sugar's speed
                sugar.sugarSpeed += sugarInc;
                //add 0.15f speed to sugar's speed
                booster.boosterSpeed += boosterInc;
                //make background scroll slightly faster
                background.scrollSpeed += backgroundInc;
                background2.scrollSpeed += backgroundInc;
            }
        }
        //when colliding with boosters, call statement
        if (collision.CompareTag("Booster"))
        {
            //add 10 points
            points += 10;

            //add 0.15 to bullet's moveSpeed. Max movespeed is 8
            if(player.moveSpeed < 7.96f)
            {
                player.moveSpeed += playerInc * 3;
            }

            //add 0.3 movespeed to environmental objects. Max movespeed is 9
            if(obstacle.obstacleSpeed < 8.99f)
            {
                //add 0.3f speed to obstacle's speed
                obstacle.obstacleSpeed += obstacleInc * 3;
                //add 0.3f speed to sugar's speed
                sugar.sugarSpeed += sugarInc * 3;
                //add 0.45f speed to sugar's speed
                booster.boosterSpeed += boosterInc * 3;
                //make background scroll slightly faster
                background.scrollSpeed += backgroundInc * 3;
                background2.scrollSpeed += backgroundInc * 3;
            }
        }
    }
}
