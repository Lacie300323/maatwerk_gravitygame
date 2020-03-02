using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool inverseGravity = false; // Checking if the gravity is inversed

    [SerializeField] private Rigidbody2D rigidb; //Rigidbody of the player
    [SerializeField] private float speed = 1f; //Movement speed of the character
    [SerializeField] private float jumpheight = 3f; //Jumpheight of the character
    
    private bool isGrounded = false; // Checks if the character is touching ground or not. Default is false.
    private Vector2 moveInput = Vector2.zero; // Writes the Vector 2 (0,0)

    private void FixedUpdate()
    {
        /// <summary>
        /// Movement based on the horiontal axis.
        /// </summary>
        Vector2 movementHor = this.transform.right * moveInput.x * speed;
        rigidb.AddForce(movementHor);

        /// <summary>
        /// Movement based on the horiontal axis.
        /// </summary>
        Vector2 movementVert = this.transform.up * moveInput.y * jumpheight;
        rigidb.AddForce(movementVert, ForceMode2D.Impulse);
        isGrounded = false; //since the player is jumping, it's no longer grounded.

        moveInput = Vector2.zero; 
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal"); // Uses the horizontal input as for th X axis

        if(isGrounded && Input.GetKeyDown(KeyCode.Space)) //If the player is grounded and theres in input key of SPACE 
        {
            moveInput.y = 1;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            inverseGravity = !inverseGravity; // Sets false --> true and true ---> false
            Debug.Log("Change gravity");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log(this.gameObject.name + " is grounded ");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true; // As long as the character is on top of the collision box, the character will remain grounded
    }
}
