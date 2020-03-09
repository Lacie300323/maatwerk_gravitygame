using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwShots;

    public float startTimebtwShots;
    public float withinDistance;

    public GameObject projectile;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimebtwShots;
    }


    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) <= withinDistance)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimebtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    
    }
}
