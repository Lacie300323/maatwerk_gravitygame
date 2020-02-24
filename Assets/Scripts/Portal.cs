using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Rigidbody2D enterRigidbody;
    private float enterVelocity, exitVelocity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enterRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        enterVelocity = enterRigidbody.velocity.x;

        if (gameObject.name == "startPortal")
        {
            PortalControl.portalControlInstance.disableCollider("start");
            PortalControl.portalControlInstance.createClone("atStart");
        }
        else if (gameObject.name == "exitPortal")
        {
            PortalControl.portalControlInstance.disableCollider("exit");
            PortalControl.portalControlInstance.createClone("atExit");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitVelocity = enterRigidbody.velocity.x;

        if (enterVelocity != exitVelocity)
        {
            Destroy(GameObject.Find("PlayerClone"));
        }
        else if (gameObject.name != "PlayerClone")
        {
            Destroy(collision.gameObject);
            PortalControl.portalControlInstance.enableCollider();
            GameObject.Find("PlayerClone").name = "Player";
        }
    }
}
