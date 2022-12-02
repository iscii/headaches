using UnityEngine;

public class Background_Scroller : MonoBehaviour
{
    //create a public variable scrollSpeed
    public float scrollSpeed = 0.3f;
    //create a private reference to BoxCollider2D
    private BoxCollider2D backgroundCollider;
    //create a private reference for background's x size value
    private float backgroundSize;

    //start is called before the first frame update
    void Start()
    {
        //refer to BoxCollider2D
        backgroundCollider = GetComponent<BoxCollider2D>();
        //set backgroundSize to background's BoxCollider2D's size's x-value. Multiply by 4 since the prefab is scaled by 4 on x and y.
        backgroundSize = backgroundCollider.size.x * 4;
    }

    //update is called once per frame
    void Update()
    {
        //when x-position is less than x-value of size (when the background goes out of camera), call statement
        if(transform.position.x < -backgroundSize)
        {
            //repeat the background
            RepeatBackground();
        }

        //move left
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
    }

    //function to repeat background
    void RepeatBackground()
    {
        //set backgroundOffset to a Vector2 with backgroundSize as x-value.
        Vector2 backgroundOffset = new Vector2(backgroundSize, 0f);
        //move the background to the right by backgroundSize (using backgroundOffset's Vector2).
        transform.position = (Vector2)transform.position + backgroundOffset;
    }

    //function to disable script
    void Stop()
    {
        //disable script
        enabled = false;
    }
}
