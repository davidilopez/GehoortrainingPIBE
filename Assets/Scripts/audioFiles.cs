using UnityEngine;
using System.Collections;

public class audioFiles : MonoBehaviour {

    public static AudioClip[] Files;
    public int NoiseLevel = 0;
    public int PairLevel = 1;
    private AudioSource audio;


    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        Files = Resources.LoadAll<AudioClip>("Audio");

    }
	
	// Update is called once per frame
	void Update () {
	    switch (NoiseLevel)
        {
            case 0:
                Files = Resources.LoadAll<AudioClip>("Audio/Level00");
                break;
            case 1:
                Files = Resources.LoadAll<AudioClip>("Audio/Level01");
                break;
            case 2:
                Files = Resources.LoadAll<AudioClip>("Audio/Level02");
                break;
            case 3:
                Files = Resources.LoadAll<AudioClip>("Audio/Level03");
                break;
            case 4:
                Files = Resources.LoadAll<AudioClip>("Audio/Level04");
                break;
            case 5:
                Files = Resources.LoadAll<AudioClip>("Audio/Level05");
                break;
        }



	}
}
