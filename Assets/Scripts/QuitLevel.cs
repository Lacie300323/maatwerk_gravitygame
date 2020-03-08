using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitLevel : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("Quited the game");
        Application.Quit();
    }
}
