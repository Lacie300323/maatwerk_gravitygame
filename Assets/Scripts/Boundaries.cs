using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + " has entered the boundaries");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {            
            Debug.Log(collision.name + " has exited the boundaries");
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            CheckpointManager.instance.RestorePlayerToCheckpoint();

            Player playerScript = collision.gameObject.GetComponent<Player>();
            playerScript.inverseGravity = false;
        }
    }
}
