using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hi");
            gameManager.CompleteLevel();
        }
    }
}
