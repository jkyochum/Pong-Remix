using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject player;
    public GameObject opponent;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ////---------for opponent bumper
        opponent.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        
        if(Input.GetKey(KeyCode.D))
        {
            //move bumper right
            opponent.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 10f);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            //move bumper left
            opponent.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -10f);
        }



        ////--------for player bumper////
        player.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //move bumper right
            player.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 10f);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //move bumper left
            player.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -10f);
        }
    }
}
