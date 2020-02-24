using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    /// <summary>
    /// Since the player isn't going to be the only one affected bby the planet's gravity
    /// A list is needed to store all the rigidbodies affected.
    /// </summary>
    private List<Rigidbody2D> rgList = new List<Rigidbody2D>();

    private float totRadius; // Calculates the radius of the collider
    [SerializeField] private CircleCollider2D radiusComp;

    /// <summary>
    /// Gravitational pull of the planet
    /// </summary>
    [SerializeField] private float maxGForce = 9.81f; // force value maximal
    [SerializeField] private float minGForce = 1; // force value minimum

    private void Start()
    {

        totRadius = radiusComp.radius * radiusComp.gameObject.transform.lossyScale.x; // Because im using a collider within the parent object, the scale is different on the chil object
    }

    private void FixedUpdate()
    {
        /// <summary>
        /// Since the player isn't going to be the only one affected bby the planet's gravity
        /// A list is needed to store all the rigidbodies affected.
        /// </summary>

        foreach (Rigidbody2D rgbody in rgList)
        {
            /// <summary>
            /// Calculate how much gravity to add with the force.
            /// </summary>
            Vector2 forceDirection = ((Vector2)transform.position - rgbody.position).normalized; //Calculates in which direction force needs to be applied

            float distance = 1 - Vector2.Distance(transform.position, rgbody.position) / totRadius; //Calculate in precentages distance in the collider towards the center of the planet
                                                                                                    // Debug.LogFormat("{0} dist {1} radius", Vector2.Distance(transform.position, rgbody.position), totRadius);

            float gForceLerp = Mathf.Lerp(minGForce, maxGForce, distance);

            Vector2 gravityForce = forceDirection * gForceLerp;
            //Debug.Log(gravityForce);

            Player playerScript = rgbody.gameObject.GetComponent<Player>();

            if(playerScript != null && playerScript.inverseGravity)
            {
                gravityForce *= -1;
            }

            // Add the force of gravity to the rigidbody of the object.
            //ToDo: Add minus to a button / keyinput to change attraction to repulsion
            rgbody.AddForce(gravityForce);

            // Rotate whatever is affected to face away from the center at all times.
            rgbody.transform.up = forceDirection * -1;
        }
    }

    /// <summary>
    /// A planet has a atmosphere, in which the area is affected. The closer you get to the center the harder the gravity pulls.
    /// To simulate this Atmospheric effect, a OntriggerEnter and OntriggerExit will be created.
    /// </summary>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D affectedByGravity = collision.GetComponent<Rigidbody2D>(); //Get the rigidbody of the object entering the Collider of the planet.

        //If there's a rigidbody detected
        if (affectedByGravity)
        {
            rgList.Add(affectedByGravity); //Add the rigidbody to the list of that particluar planet
            Debug.Log(affectedByGravity.gameObject.name + " entered the gravity of " + this.gameObject.name); //Log for check
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D previousByGravity = collision.GetComponent<Rigidbody2D>(); //Get the rigidbody of the object exiting the Collider of the planet.

        if (previousByGravity && rgList.Contains(previousByGravity))
        { 
            rgList.Remove(previousByGravity); //Remove the rigidbody from the list of that particular plannet
            Debug.Log(previousByGravity.gameObject.name + " exited the gravity of " + this.gameObject.name); //Log for check

            Player playerScript = previousByGravity.gameObject.GetComponent<Player>();

            if (playerScript != null) //Resetting inverse gravity
            {
                playerScript.inverseGravity = false;
            }
        }
    }
}
