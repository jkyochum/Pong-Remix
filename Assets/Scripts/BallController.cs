using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    //referencing the rigidbody
    Rigidbody rb;

    //referencing audio source
    public AudioSource ballAudioGame;
    public AudioSource ballAudioScore;
    public AudioClip gameplay;
    public AudioClip score;

    public float moveSpeed = 10f;

    //initializing variables that will increase the movement speed of the ball
    public float increaseTimer = 0;
    public int increaseInterval = 20;
    public float speedIncrease = 2f;

    
    

	// Use this for initialization
	void Start () {

        //pausing the game start until space bar is pressed
        Time.timeScale = 0;

        //pausing the ball on start
        StartCoroutine(Pause());

        //ball starts in a certain direction
        rb = GetComponent<Rigidbody> ();

    }

    // Update is called once per frame
    void Update () {

        //game starts when space is pressed
        if(Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown(KeyCode.RightShift))
        {
            Time.timeScale = 1;
            
        }

        //calling speed increase function
        speedIncreaseUpdate();
        
            //goes past player
            if (transform.position.x > 26f)
        {

            //play sound clip on score
            ballAudioScore.PlayOneShot(score);

            //returning the ball to 0 after score
            transform.position = Vector3.zero;

            //stopping the ball after score so it can reset
            rb.velocity = Vector3.zero;

            //give player a point
            ScoreController.instance.OppScoredPoint();

            StartCoroutine(Pause());
            
        }
        //goes past opponent
        if (transform.position.x < -26f)
        {
            //play sound clip on score
            ballAudioScore.PlayOneShot(score);

            //returning the ball to 0 after score
            transform.position = Vector3.zero;

            //stopping the ball after score so it can reset
            rb.velocity = Vector3.zero;
            
            //give opp a point
            ScoreController.instance.PlayerScoredPoint();

            StartCoroutine(Pause());
          
        }
    }

    //increasing the speed over time
    void speedIncreaseUpdate()
    {
        //checking to see if the increase timer has reached 20
        if (increaseTimer>=increaseInterval)
        {
            //resetting the increase timer if it has reached 20
            increaseTimer = 0;

            if(moveSpeed>0)
            {
                moveSpeed += speedIncrease;
            }
            else
            {
                moveSpeed -= speedIncrease;
            }
        }
        else
        {
            //if timer hasn't reached 20 then increase the timer
            increaseTimer += Time.deltaTime;
        }
    }

    //setting the pause time on start
    IEnumerator Pause()
    { 
        //wait for 2 seonds
        yield return new WaitForSeconds(2f);
        LaunchBall();
    }
    void LaunchBall()
    {
        //coin flip to determine direction x-axis
        int xDirection = Random.Range(0, 2);

        //coin flip to determine direction z-axis
        int zDirection = Random.Range(0, 3);

        Vector3 launchDirection = new Vector3();

        //flipping for x-axis
        if (xDirection == 0)
        {
            launchDirection.x = -8f;
        }
        else if (xDirection == 1)
        {
            launchDirection.x = 8f;
        }

        //flipping for z-axis
        if (zDirection == 0)
        {
            launchDirection.z = -8f;
        }
        else if (zDirection == 1)
        {
            launchDirection.z = 8f;
        }
        else if (zDirection == 2)
        {
            launchDirection.z = 0f;
        }
        rb.velocity = launchDirection;
    }

 
    //moving the ball if it hits wall
    void OnCollisionEnter(Collision hit)
    {
        

        if (hit.gameObject.name == "Wall Right")
        {
            //play sound clip on impact
            ballAudioGame.PlayOneShot(gameplay);

            float speedInZDirection = 0f;

            if (rb.velocity.z > 0f)
                speedInZDirection = rb.velocity.z;
            if (rb.velocity.z < 0f)
                speedInZDirection = rb.velocity.z;

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }
        if (hit.gameObject.name == "Wall Left")
        {
            //play sound clip on impact
            ballAudioGame.PlayOneShot(gameplay);

            float speedInZDirection = 0f;

            if (rb.velocity.z > 0f)
                speedInZDirection = rb.velocity.z;
            if (rb.velocity.z < 0f)
                speedInZDirection = rb.velocity.z;

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z) ;
        }


        //----moving the ball if it hits players bumper
        
            if (hit.gameObject.name == "PlayerBumper")
            {

                //play sound clip on impact
                ballAudioGame.PlayOneShot(gameplay);

                rb.velocity = new Vector3(-moveSpeed, 0f, 0f);
                //if ball hits left side of bumper
                if (transform.position.z - hit.gameObject.transform.position.z < 0)
                {
                    rb.velocity = new Vector3(-moveSpeed, 0f, -moveSpeed);
                }
                //if ball hits right side of bumper
                if (transform.position.z - hit.gameObject.transform.position.z > 0)
                {
                    rb.velocity = new Vector3(-moveSpeed, 0f, moveSpeed);
                }


            }
        

        //----moving the ball if it hits opponent bumper

        
            if (hit.gameObject.name == "OppBumper")
            {
                //play sound clip on impact
                ballAudioGame.PlayOneShot(gameplay);

                rb.velocity = new Vector3(moveSpeed, 0f, 0f);
                //if ball hits left side of bumper
                if (transform.position.z - hit.gameObject.transform.position.z < 0)
                {
                    rb.velocity = new Vector3(moveSpeed, 0f, -moveSpeed);
                }
                //if ball hits right side of bumper
                if (transform.position.z - hit.gameObject.transform.position.z > 0)
                {
                    rb.velocity = new Vector3(moveSpeed, 0f, moveSpeed);
                }
            }       
        }
}
