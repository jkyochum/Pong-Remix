using System.Collections;

using UnityEngine;

public class AIController : MonoBehaviour
{
    public float speed = 8f;
    Vector3 targetPos;
    GameObject ball;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
        
    }

    void Update()
    {
        targetPos = Vector3.Lerp(gameObject.transform.position, ball.transform.position, Time.deltaTime * speed);
        gameObject.transform.position = new Vector3(-24.5f, 0, targetPos.z);
    }
   
}

