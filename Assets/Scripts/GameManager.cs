using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject same;
    public GameObject different;
    public float firstPos = -2.5f;
    public float secondPos = 3.0f;

    // Testing clips
    public AudioClip[] testing;

    private GameObject sameClone;
    private GameObject differentClone;
    private int order;
    private int noiseLevel = 0;
    private int pairLevel = 0;
    private int firstSoundIndex;
    private int secondSoundIndex;
    private bool spawned = true;
    private bool firstSoundPlayed = false;
    private bool secondSoundPlayed = false;
    private bool areTheSame;
    private AudioClip firstStimulus;
    private AudioClip secondStimulus;

	// Use this for initialization
	void Start () {
        order = Random.Range(0, 2);
        firstSoundIndex = Random.Range(0, 2);
        secondSoundIndex = Random.Range(0, 2);
        AudioSource audio = GetComponent<AudioSource>();

        if (order == 0)
        {
            sameClone = (GameObject) Instantiate(same, new Vector2(firstPos, 0.0f), Quaternion.identity);
            differentClone = (GameObject) Instantiate(different, new Vector2(secondPos, 0.0f), Quaternion.identity);
        }
        else
        {
            sameClone = (GameObject)Instantiate(same, new Vector2(secondPos, 0.0f), Quaternion.identity);
            differentClone = (GameObject)Instantiate(different, new Vector2(firstPos, 0.0f), Quaternion.identity);
        }

        if (firstSoundIndex == secondSoundIndex)
        {
            areTheSame = true;
        }
        else
        {
            areTheSame = false;
        }

        if (!firstSoundPlayed)
        {
            audio.clip = testing[firstSoundIndex];
            audio.Play();
            firstSoundPlayed = true;
        }

        if (!secondSoundPlayed && firstSoundPlayed)
        {
            audio.clip = testing[secondSoundIndex];
            audio.Play();
            secondSoundPlayed = true;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (!spawned)
        {
            order = Random.Range(0, 2);
            firstSoundIndex = Random.Range(0, 2);
            secondSoundIndex = Random.Range(0, 2);

            if (order == 0)
            {
                sameClone = (GameObject)Instantiate(same, new Vector2(firstPos, 0.0f), Quaternion.identity);
                differentClone = (GameObject)Instantiate(different, new Vector2(secondPos, 0.0f), Quaternion.identity);
            }
            else
            {
                sameClone = (GameObject)Instantiate(same, new Vector2(secondPos, 0.0f), Quaternion.identity);
                differentClone = (GameObject)Instantiate(different, new Vector2(firstPos, 0.0f), Quaternion.identity);
            }
            spawned = true;
            if (firstSoundIndex == secondSoundIndex)
            {
                areTheSame = true;
            } else
            {
                areTheSame = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(areTheSame && order == 0)
            {
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("Incorrect");
            }
            Destroy(sameClone);
            Destroy(differentClone);
            firstSoundPlayed = false;
            secondSoundPlayed = false;
            spawned = false;

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (areTheSame && order == 0)
            {
                Debug.Log("Inorrect");
            }
            else
            {
                Debug.Log("Correct");
            }
            Destroy(sameClone);
            Destroy(differentClone);
            firstSoundPlayed = false;
            secondSoundPlayed = false;
            spawned = false;


        }
    }

}
