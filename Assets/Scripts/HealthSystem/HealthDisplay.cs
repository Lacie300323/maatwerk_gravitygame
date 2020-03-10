using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Image[] allHearts; //Image list of all heart sprites
    [SerializeField] private Sprite fullHeart; //Image of the fullheart sprite
    [SerializeField] private Sprite emptyHeart; //Image of the emptyheart sprite

    public void UpdateDisplay(int remainingHearts)
    {
        for (int i = 0; i < allHearts.Length; i++)
        {
            if (i < remainingHearts)
            {
                allHearts[i].sprite = fullHeart;
            }
            else
            {
                allHearts[i].sprite = emptyHeart;
            }
        }
    }
}
