using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class letterChange : MonoBehaviour
{
    public Sprite letterB;
    public Sprite letterD;
    public Sprite letterP;
    public Sprite letterS;
    public Sprite letterT;

    // New target letters
    public Sprite letterZ;
    public Sprite letterV;
    public Sprite letterF;



    public static string letter;
    public static int letterInteger = 0;

    void Update()
    {
        //TODO---
        // Make the levels HERE:
        if (Manager.letterLevel == 1)
        {
            letter = "P";
            letterInteger = 1;
        }
        else if (Manager.letterLevel == 2)
        {
            letter = "B";
            letterInteger = 2;
        }
        else if (Manager.letterLevel == 3)
        {
            letter = "S";
            letterInteger = 3;
        }
        else if (Manager.letterLevel == 4)
        {
            letter = "Z";
            letterInteger = 4;
        }
        else if (Manager.letterLevel == 5)
        {
            letter = "T";
            letterInteger = 5;
        }
        else if (Manager.letterLevel == 6)
        {
            letter = "D";
            letterInteger = 6;
        }
        //else if (Manager.letterLevel == 7)
        //{
        //    letter = "F";
        //    letterInteger = 7;
        //}
        //else if (Manager.letterLevel == 8)
        //{
        //    letter = "V";
        //    letterInteger = 8;
        //}

        // Finish all the words in the level -> Prompt if player will continue with this letter + noise or new letter

        // Print the letter on screen
        if (letter == "P")
        {
            GetComponent<Image>().sprite = letterP;
        }
        else if (letter == "B")
        {
            GetComponent<Image>().sprite = letterB;
        }
        else if (letter == "S")
        {
            GetComponent<Image>().sprite = letterS;
        }
        else if (letter == "Z")
        {
            GetComponent<Image>().sprite = letterZ;
        }
        else if (letter == "T")
        {
            GetComponent<Image>().sprite = letterT;
        }
        else if (letter == "D")
        {
            GetComponent<Image>().sprite = letterD;
        }
        //else if (letter == "F")
        //{
        //    GetComponent<Image>().sprite = letterF;
        //}
        //else if (letter == "V")
        //{
        //    GetComponent<Image>().sprite = letterV;
        //}
    }

}