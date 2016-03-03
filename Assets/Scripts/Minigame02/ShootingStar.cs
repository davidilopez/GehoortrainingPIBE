using UnityEngine;
using System.Collections;

public class ShootingStar : MonoBehaviour {

    public int pointsToAdd;
    public static int Hit = 3;
    public static int FalsePositive = -2;
    public static int Missed = -1;
    public static int NoShot = 1;
    public static bool wasCorrect = false;

    void Start()
    {
        if (transform != null)
        {
            Destroy(gameObject, 1.5f);
        }
    }
	
	


    void OnTriggerEnter2D(Collider2D other)
    {
        if (letterChange.letterInteger == audioStimuli.wordRandomizer && other.gameObject.tag == "Player")
        {
            pointsToAdd = Hit;
            Score.AddPoints(pointsToAdd);        // Add points to the score
            wasCorrect = true;
        }
        else if (letterChange.letterInteger != audioStimuli.wordRandomizer && other.gameObject.tag == "Player")
        {
            pointsToAdd = FalsePositive;
            Score.AddPoints(pointsToAdd);
        }
        else if (letterChange.letterInteger != audioStimuli.wordRandomizer && other.gameObject.tag == "Finish")
        {
            pointsToAdd = NoShot;
            Score.AddPoints(pointsToAdd);        // Add points to the score
        }
        else if (letterChange.letterInteger == audioStimuli.wordRandomizer && other.gameObject.tag == "Finish")
        {
            pointsToAdd = Missed;
            Score.AddPoints(pointsToAdd);
        }

        Destroy(gameObject);        // When anything collides with the star, destroy this object
    }
}  
