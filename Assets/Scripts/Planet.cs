using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float planetMass;
    public float playerMass;

    Rigidbody2D rgPlayer;

    public float distance;
    public Transform centerOfPlanet;
    public float forceValue;
    public float gForce;
    Vector3 forceDirection;

    // Start is called before the first frame update
    void Start()
    {
        rgPlayer = GetComponent<Rigidbody2D>();
        playerMass = rgPlayer.mass;
        distance = Vector3.Distance(centerOfPlanet.transform.position, transform.position);
        forceValue = gForce * (planetMass * playerMass) / (distance * distance);

    }

    // Update is called once per frame
    void Update()
    {
        forceDirection = (centerOfPlanet.position - transform.position).normalized; 
        rgPlayer.AddForce(forceValue * forceDirection);
    }
}
