using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Slingshot : MonoBehaviour
{
    //reference to BoxCollider2D component of Slingshot
    private BoxCollider2D sling;

    //private vector2 variable for offset
    private Vector2 slingOffset;

    //public variable launched
    [HideInInspector]
    public int launched;

    //start is called before the first frame update
    void Start()
    {
        //first stage of "launched"
        launched = 1;

        //refer to boxcollider2d component of slingshot
        sling = GameObject.Find("Slingshot").GetComponent<BoxCollider2D>();
        
        //stop the script after set time
        IEnumerator StopScript(float time)
        {
            //yield return thing idk
            yield return new WaitForSeconds(time);
            //disable script
            enabled = false;
        }
        //stop the script after 4 seconds ^
        StartCoroutine(StopScript(4));

        //stop acceleration after set time
        IEnumerator StopAcceleration(float time)
        {
            yield return new WaitForSeconds(time);

            //third stage of "launched"
            launched = 3;
            //enable player movement
            gameObject.GetComponent<Player_Movement>().enabled = true;
        }
        StartCoroutine(StopAcceleration(1.9f));
    }

    //update is called once per frame
    void Update()
    {
        //call during first stage of "launched"
        if (launched == 1)
        {
            //set slingOffset to offset player sprite so it looks normal
            slingOffset = new Vector2(sling.offset.x + 0.25f, sling.offset.y);
            //constantly set position to sling's position + offset (for alignment)
            transform.position = (Vector2)sling.transform.position + slingOffset;
        }

        //call during second stage of "launched"
        if (launched == 2)
        {
            //accelerate
            Acceleration();
        }
    }

    //function for acceleration
    private void Acceleration()
    {
        //move right really fast as if accelerating
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
    }
}

