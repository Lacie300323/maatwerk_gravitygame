using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false; ///Bool to check if the game has ended
    
    public float restartDelay = 1f; //The amount of time it takes to restart the game
    public GameObject levelCompleteUI;


    public void CompleteLevel()
    {

        levelCompleteUI.SetActive(true);
        GetComponent<StarHandler>().starsAcquired();
    }

    public void EndGame()
    {
        if(gameOver == false)
        {
            gameOver = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}