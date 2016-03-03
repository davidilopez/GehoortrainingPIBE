using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int score;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        if (score < 0)
        {
            score = 0;      // Score can't be negative
        }

        text.text = "" + score;
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;       // Pickup points add to the score
    }

    public static void Reset()
    {
        score = 0;
    }


}
