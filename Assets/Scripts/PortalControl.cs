using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    public static PortalControl portalControlInstance; //singleton

    [SerializeField] private GameObject portalEnter, portalExit;
    [SerializeField] private Transform portalEnterSpawn, portalExitSpawn;
    private Collider2D portalEnterCollider, portalExitCollider;

    [SerializeField] private GameObject clonePlayer;

    // Start is called before the first frame update
    void Start()
    {
        portalControlInstance = this;
        portalEnterCollider = portalEnter.GetComponent <Collider2D>();
        portalExitCollider = portalExit.GetComponent<Collider2D>();
    }

    public void createClone (string spawnPoint)
    {
        if (spawnPoint == "atExit")
        {
            var instantiatePlayer = Instantiate(clonePlayer, portalExitSpawn.position, Quaternion.identity);
            instantiatePlayer.gameObject.name = "PlayerClone";
        }

        if(spawnPoint == "atStart")
        {
            var instantiatePlayer = Instantiate(clonePlayer, portalEnterSpawn.position, Quaternion.identity);
            instantiatePlayer.gameObject.name = "PlayerClone";
        }
    }

    public void disableCollider(string colliderToDisable)
    {
        if (colliderToDisable == "start")
        {
            portalEnterCollider.enabled = false;
        }
        if (colliderToDisable == "exit")
        {
            portalExitCollider.enabled = false;
        }
    }
    
    public void enableCollider()
    {
        portalEnterCollider.enabled = true;
        portalExitCollider.enabled = true;
    }
}
