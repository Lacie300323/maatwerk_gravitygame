using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start()
    {
        // Cache the CheckpointManager
        checkpointManager = CheckpointManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Update the checkpoint the player should return to
            checkpointManager.SetLastCheckpoint(transform.position);
        }
    }
}
