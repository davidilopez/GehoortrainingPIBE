using UnityEngine;
using System.Collections;

public class starColor : MonoBehaviour
{

    public Sprite YellowStar;
    public Sprite WhiteStar;
    public Sprite BlueStar;

    // Use this for initialization
    void Start()
    {
        if (MainScript01_game.overallScore % 30 < 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = YellowStar;
        }
        else if (MainScript01_game.overallScore % 30 >= 10 && MainScript01_game.overallScore % 30 < 20)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = BlueStar;
        }
        else if (MainScript01_game.overallScore % 30 >= 20 && MainScript01_game.overallScore % 30 < 30)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = WhiteStar;
        }
    }
}
