using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Game started");
        SceneManager.LoadScene("PlayScene");
    }

    public void PlayGame()
    {
        Debug.Log("Game Played");
        //Termination Conditions 
    }
    
    public void EndGame()
    {
        Debug.Log("Game ended");
        SceneManager.LoadScene("StartScene");
    }
    
}
