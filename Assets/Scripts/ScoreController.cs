using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

    //reference to controller
    public static ScoreController instance;

    //setting variables to be availale to the text options
    public Text playerScoreText;
    public Text oppScoreText;

    public int playerScore;
    public int oppScore;

    public Light ballLight;

    //setting the counter for toggle switch to 0
    public int counter = 0;

    public GameObject oppBumper;

    public Text startText;
    private string beforeStart = "PRESS SHIFT TO START";
    private string afterStart = "";

	// Use this for initialization
	void Start () {
        instance = this;
        
        //setting the point light to the ball to call it later
        ballLight = GameObject.Find("Point light").GetComponent<Light>();

        //initializing points on start
        playerScore = 0;
        oppScore = 0;
       
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown(KeyCode.RightShift))
        {
            startText.enabled = false;
        }

        if (playerScore >= 7)
        {          
            RenderSettings.ambientIntensity = 0f;

            //setting the light range on the ball
            ballLight.range = 3f;
        }
    }

    public void textOff()
    {
       
    }
    //creating a function to toggle AI
    public void toggleAI(bool newValue)
    {
        ++counter;
       if(counter%2==1)
        {
            oppBumper.GetComponent<AIController>().enabled = false;
        }
        else
        {
            oppBumper.GetComponent<AIController>().enabled = true;
        }       
    }

    public void PlayerScoredPoint()
    {
        playerScore += 1;
       
        playerScoreText.text = playerScore.ToString();
       
        if(playerScore>9)
        {
            SceneManager.LoadScene(2);
           
        }
        
    }
    public void OppScoredPoint()
    {
        oppScore += 1;

        oppScoreText.text = oppScore.ToString();

        if (oppScore>9)
        {
            SceneManager.LoadScene(3);
        }
    }
   
}
