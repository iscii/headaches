using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //reference to Obstacle_Behavior script
    public Obstacle_Behavior obstacle;

    //create reference to RigidBody2D.
    private Rigidbody2D myRb;

    //create private variable moveSpeed.
    public float moveSpeed;

    //create a variable for y-limit
    public float yLimit;

    //start is called before the first frame update
    void Start()
    {
        //refer to component RigidBody2D.
        myRb = GetComponent<Rigidbody2D>();
    }

    //update is called once per frame
    void Update()
    {
        //simplification: create variable for wasd-movement inputs.
        var left = Input.GetKey(KeyCode.A);
        var right = Input.GetKey(KeyCode.D);
        var up = Input.GetKey(KeyCode.W);
        var down = Input.GetKey(KeyCode.S);
        //simplification: create variable for xy-position of gameObject Bullet.
        var xPos = transform.position.x;
        var yPos = transform.position.y;
        //set a boolean variable to control when "w" and "s" are pressed simultaneously
        bool upNdown = false;
        bool leftNright = false;

        //change y-limit depending on speed
        if(obstacle.obstacleSpeed < 5)
        {
            yLimit = 4f;
        }
        else if(obstacle.obstacleSpeed >= 5 && obstacle.obstacleSpeed < 7)
        {
            yLimit = 4.15f;
        }
        else if(obstacle.obstacleSpeed >= 7 && obstacle.obstacleSpeed <= 9)
        {
            yLimit = 4.35f;
        }

        //move right when "d" is pressed and x-position is less than -3.
        if (right && left)
        {
            //x-position does not change; Bullet is horizontally static.
            transform.position = new Vector2(xPos, yPos);
            //set leftNright to true so the individual input statements don't override this one.
            leftNright = true;
        }
        //when both "a" and "d" aren't pressed simultaneously, call the input statements below.
        if (leftNright == false)
        {
            //move right when "d" is pressed and x-position is greater than -2.9.
            if (right && !(xPos >= -2.9f))
            {
                //add (moveSpeed * Time.deltaTime) to current x-position of Bullet.
                transform.position = new Vector2(xPos + moveSpeed * Time.deltaTime, transform.position.y);
            }
            //move left if x-position is greater than -8.
            if (!right && !(xPos <= -7.9f))
            {
                //subtract (moveSpeed * Time.deltaTime) from current x-position of Bullet.
                transform.Translate(Vector2.left * obstacle.obstacleSpeed * Time.deltaTime);
            }
        }
        //do not move vertically when both "w" and "s" are pressed.
        if (up && down)
        {
            //y-position does not change; Bullet is vertically static.
            transform.position = new Vector2(xPos, yPos);
            //set upNdown to true so the individual input statements don't override this one.
            upNdown = true;
        }
        //when both "w" and "s" aren't pressed together, call the individual input statements.
        if (upNdown == false)
        {
            //move up when "a" is pressed and y-position is less than yLimit
            if (up && !(yPos >= yLimit))
            {
                //add (moveSpeed * Time.deltaTime) to current y-position of Bullet.
                transform.position = new Vector2(transform.position.x, yPos + (moveSpeed - 1) * Time.deltaTime);
            }
            //move down when "s" is pressed and y-position is greater than yLimit
            if (down && !(yPos <= -yLimit))
            {
                //subtract (moveSpeed * Time.deltaTime) to current y-position of Bullet.
                transform.position = new Vector2(transform.position.x, yPos - (moveSpeed - 1) * Time.deltaTime);
            }
        }
    }
}


/*  **old movement script using Input.GetAxisRaw; Does not allow for movement boundaries as one script controls both sides of horizontal or vertical movement.
    // Update is called once per frame
    void Update()
    {
        //sets up horizontal & vertical input variables for simplicity
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        //horizontal movement: if the input values are greater than 0.5f or less than -0.5f, then call below statement
        if(hori > 0.5f || hori < -0.5f)
        {
            //add velocity to x axis of RgidBody2D
            myRb.velocity = new Vector2(hori * moveSpeed * Time.deltaTime, myRb.velocity.y);

        }
        //vertical movement
        if (vert > 0.5f || vert < -0.5f)
        {
            //add velocity to y axis of RigidBody2D
            myRb.velocity = new Vector2(myRb.velocity.x, vert * moveSpeed * Time.deltaTime);
        }
        //prevents sliding for horizontal movement
        if(hori < 0.5f && hori > -0.5f)
        {
            //sets velocity on x-axis to 0 when there is no input
            myRb.velocity = new Vector2(0f, myRb.velocity.y);
        }
        //prevents sliding for vertical movement
        if(vert < 0.5f && vert > -0.5f)
        {
            //sets velocity on y-axis to 0 when there is no input
            myRb.velocity = new Vector2(myRb.velocity.x, 0f);
        }

    }
*/