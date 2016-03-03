using UnityEngine;
using System.Collections;

public class randomNumber : MonoBehaviour {

    public static int RndPair;
    public static int RndWord1;
    public static int RndWord2;
    public static bool playedSound;

	// Use this for initialization
	void Start () {
        RndPair = Random.Range(0, 12);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
