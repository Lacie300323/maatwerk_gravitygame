using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    [SerializeField] private Transform player;

    private Vector2 lastCheckpoint;

    private void Awake()
    {
        // If a CheckpointManager already exists (and it is not this object), delete this
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        // If it doesn't exist yet, make this the only CheckpointManager to exist
        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Set the default "last checkpoint" to the (starting) position of the player
    private void Start()
    {
        lastCheckpoint = player.position;
    }

    /// <summary>
    /// Reset the player back to the last checkpoint.
    /// </summary>
    public void RestorePlayerToCheckpoint()
    {
        player.position = lastCheckpoint;
    }

    /// <summary>
    /// Set the last checkpoint the player passed to the passed point.
    /// </summary>
    /// <param name="position">The position of the checkpoint for the player to return to.</param>
    public void SetLastCheckpoint(Vector2 position)
    {
        lastCheckpoint = position;
    }
}
