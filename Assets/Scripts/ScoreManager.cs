using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentCount;
    [SerializeField] private TextMeshProUGUI totalCount;

    private int score;
    private int totalScore;

    public static ScoreManager instance;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        totalScore = GameObject.FindGameObjectsWithTag("Coin").Length; //Find all the objects with the tag coin
        Debug.Log(totalScore);
        totalCount.text = totalScore.ToString(); //Convert the total count int into text and parse this into the textmesh object
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        currentCount.text = score.ToString();
    }
}
