using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    private void Awake()
    {
        // If a Sceneloader Manager already exists (and it is not this object), delete this
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        // If it doesn't exist yet, make this the only Sceneloader Manager to exist
        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
