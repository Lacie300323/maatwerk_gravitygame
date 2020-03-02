using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Image[] allHearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

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
