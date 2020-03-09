using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public GameManager gameManager; // Getting the Gamemanager component script


    void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D affectedRigidbd = collision.GetComponent<Rigidbody2D>(); // Getting the rigidbody of the object it collided with

        ///<summary>
        ///When the collided object is tagged "Player", the object needs to stop moving and the Complete level function is called
        ///</summary>
        if (collision.gameObject.CompareTag("Player"))
        {
            affectedRigidbd.velocity = Vector2.zero; 
            Debug.Log("Player stopped moving");
            gameManager.CompleteLevel();
        }
    }
}
