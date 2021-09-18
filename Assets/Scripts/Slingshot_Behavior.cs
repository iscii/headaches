using System.Collections;
using UnityEngine;

public class Slingshot_Behavior : MonoBehaviour
{
    //reference to Background_Scroller script for background
    public Background_Scroller background;
    //reference to Background_Scroller script for background2
    public Background_Scroller background2;
    //reference to Player_Slingshot script
    public Player_Slingshot player;
    //reference to Animator component for player 
    public Animator playerAnimator;
    //boolean to determine when to move
    private bool move;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

        //set move to false after set time
        IEnumerator StopMoving(float time)
        {
            //yield return thing idk what it does
            yield return new WaitForSeconds(time);

            //stop moving
            move = false;
        }
        //set move to false after 3 seconds ^
        StartCoroutine(StopMoving(3));
    }

    //update is called once per frame
    void Update()
    {
        //move left if move is true
        MoveLeft();
    }

    //function to move left
    void MoveLeft()
    {
        //detect if animation has finished. Then move left
        if (move == true)
        {
            //move left really fast to show acceleration
            transform.Translate(Vector2.left * 15 * Time.deltaTime);
        }
    }

    //function to stop animation. Used in Animation event
    void StopAnimation()
    {
        //disable animator component
        gameObject.GetComponent<Animator>().enabled = false;
    }

    //function to launch
    void Launch()
    {
        //set player.launched to 2 for acceleration.
        player.launched = 2;
        //set move to true
        move = true;
        //set isLaunched parameter to true to begin midair animation.
        playerAnimator.SetBool("isLaunched", true);
        //enable Background_Scroll script for background
        background.enabled = true;
        //enable Background_Scroll script for background2
        background2.enabled = true;
    }
}
