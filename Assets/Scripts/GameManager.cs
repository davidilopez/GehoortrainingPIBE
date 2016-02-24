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
    private int clip1;
    private int clip2;
    private bool spawned = true;
    private bool initialClip1Played = false;
    private bool initialClip2Played = false;
    private bool areTheSame;
    private AudioClip firstStimulus;
    private AudioClip secondStimulus;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        order = Random.Range(0, 2);
        clip1 = Random.Range(0, 2);
        clip2 = Random.Range(0, 2);
        audioSource = GetComponent<AudioSource>();

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

        if (clip1 == clip2)
        {
            areTheSame = true;
        }
        else
        {
            areTheSame = false;
        }

        if (!initialClip1Played)
        {
            audioSource.clip = testing[clip1];
            initialClip1Played = true;
            audioSource.Play();
        }

        if (initialClip1Played && !initialClip2Played && !audioSource.isPlaying)
        {
            audioSource.clip = testing[clip2];
            initialClip2Played = true;
            audioSource.Play();

        }

    }
	
	// Update is called once per frame
	void Update () {
        if (!spawned)
        {
            order = Random.Range(0, 2);
            clip1 = Random.Range(0, 2);
            clip2 = Random.Range(0, 2);

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
            if (clip1 == clip2)
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
            initialClip1Played = false;
            initialClip2Played = false;
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
            initialClip1Played = false;
            initialClip2Played = false;
            spawned = false;


        }
    }

}
