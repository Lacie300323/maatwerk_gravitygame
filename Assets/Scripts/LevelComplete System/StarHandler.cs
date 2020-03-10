using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    [SerializeField] private Image[] stars; //This is the list of stars within the starholder
    [SerializeField] private Sprite fullstar; //Image of the fullstar sprite
    [SerializeField] private Sprite emptystar; //Image of the emptystar sprite

    private int coinsTotal; //This wild hold the total of coin stars in the game


    void Start()
    {
        coinsTotal = GameObject.FindGameObjectsWithTag("Coin").Length; //Find all the objects with the tag coin
        Debug.Log(coinsTotal);
    }

    public void starsAcquired()
    {
        int coinsleft = GameObject.FindGameObjectsWithTag("Coin").Length; // Check for the coin objects left in the game
        // Checking for the amount of coins the player has collected, which is the total of coins - what is left uncollected in the game
        int coinsCollected = coinsTotal - coinsleft; 

        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsTotal.ToString()) * 100f; //This is the basically coinscollected / coinstotal * 100, which gives a percentage back
        Debug.Log(percentage + " %");

        if(percentage == 0) //If the percentage is 0; player has collected no coins
        {
            //Set 0 star
            stars[0].sprite = emptystar; //Show the empty star sprite 
            stars[1].sprite = emptystar;
            stars[2].sprite = emptystar;
        }     
        else if( percentage >= 33f && percentage < 66) //If the percentage is inbetween 33 and 66 (or 1/3 and 2/3) 
        {
            //Set 1 star
            stars[0].sprite = fullstar; //Show the full star sprite 
            stars[1].sprite = emptystar; 
            stars[2].sprite = emptystar; 

        }
        else if (percentage >= 66 && percentage < 70) //If the percentage is inbetween 33 and 66 (or 1/3 and 2/3) 
        {
            // Set 2 stars
            stars[0].sprite = fullstar;
            stars[1].sprite = fullstar;
            stars[2].sprite = emptystar;
        }
        else if (percentage == 100) //If the percentage is 100 ; player has collected all the coins
        {
            // Set 3 stars
            stars[0].sprite = fullstar;
            stars[1].sprite = fullstar;
            stars[2].sprite = fullstar;

        }

    }

}
