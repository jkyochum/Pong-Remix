using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {


    public void startGame()
    {
        //loading the scene at index 1 of build settings
        SceneManager.LoadScene(1);    
    }

    public void quitGame()
    {
        //exiting the game
        Application.Quit();       
    }
}
