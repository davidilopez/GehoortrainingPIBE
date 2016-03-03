using UnityEngine;
using System.Collections;

public class MainScript01_plain : MonoBehaviour {

    // The hardcoded audio files.
    public static AudioClip[] Files;

    // The noise and pair levels (variables)
    public int NoiseLevel = 0;
    public int PairLevel = 1;
    // Create an array to store the clip indices
    public int[] pairIndex;

    // Variables to keep track of the clip index in the files
    public int clip1Index;
    public int clip2Index;
    //Check if the played clips are the same.
    private bool areTheSame;
    // Check if the trial ended
    private bool trialEnded = false;

    // Keep track of correct and incorrect answers
    public static int correctAnswers;
    public static int incorrectAnswers;
    // Check if the current trial's response was correct
    public static bool isCorrect;
    
    // Prefabs for the target answer
    public GameObject SameTarget;
    public GameObject DifferentTarget;
    // Clones of the prefabs (for easier management and destruction on key press)
    private GameObject sameClone;
    private GameObject differentClone;
    // Position of the prefab clones on the screen
    public float firstPosX = -2.5f;
    public float secondPosX = 3.0f;
    public float firstPosY = 0.0f;
    public float secondPosY = 0.0f;
    // Order in which the prefab clones will appear on screen
    private int order;
    // Did the clones spawn already? (Boolean variable)
    private bool spawned = false;

    // Make the files into audible objects
    private AudioClip clip1;
    private AudioClip clip2;
    // The audio source that will play the files
    private AudioSource audioSrc;
    // Did the clips play already for this trial?
    private bool clip1Played = false;
    private bool clip2Played = false;


    // Use this for initialization
    void Start () {
        // Initialize the audio source.
        audioSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!trialEnded)
        {
            if (!spawned)
            {
                // Stop it from looping 
                spawned = true;
                // Select a random order for the targets
                order = Random.Range(0, 1);
                // Select the clips to be played (clip a + clip b; clip b + clip a; clip a + clip a; clip b + clip b)
                clip1Index = Random.Range(0, 2);
                clip2Index = Random.Range(0, 2);

                // Get the files for the respective Noise Level from their folders
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

                // Get the indices for the clips according to the pair level
                switch (PairLevel)
                {
                    case 1:
                        pairIndex[0] = 3;
                        pairIndex[1] = 1;
                        break;
                    case 2:
                        pairIndex[0] = 0;
                        pairIndex[1] = 5;
                        break;
                    case 3:
                        pairIndex[0] = 5;
                        pairIndex[1] = 1;
                        break;
                    case 4:
                        pairIndex[0] = 3;
                        pairIndex[1] = 0;
                        break;
                    case 5:
                        pairIndex[0] = 5;
                        pairIndex[1] = 3;
                        break;
                    case 6:
                        pairIndex[0] = 1;
                        pairIndex[1] = 0;
                        break;
                    case 7:
                        pairIndex[0] = 2;
                        pairIndex[1] = 7;
                        break;
                    case 8:
                        pairIndex[0] = 4;
                        pairIndex[1] = 6;
                        break;
                    case 9:
                        pairIndex[0] = 2;
                        pairIndex[1] = 6;
                        break;
                    case 10:
                        pairIndex[0] = 4;
                        pairIndex[1] = 7;
                        break;
                    case 11:
                        pairIndex[0] = 4;
                        pairIndex[1] = 2;
                        break;
                    case 12:
                        pairIndex[0] = 7;
                        pairIndex[1] = 6;
                        break;

                }

                // Look if the clips are the same
                if (clip1Index == clip2Index)
                {
                    areTheSame = true;
                }
                else
                {
                    areTheSame = false;
                }

                // Instantiate the prefab clones
                if (order == 0)
                {
                    sameClone = (GameObject)Instantiate(SameTarget, new Vector2(firstPosX, firstPosY), Quaternion.identity);
                    differentClone = (GameObject)Instantiate(DifferentTarget, new Vector2(secondPosX, secondPosY), Quaternion.identity);
                }
                else
                {
                    sameClone = (GameObject)Instantiate(SameTarget, new Vector2(secondPosX, secondPosY), Quaternion.identity);
                    differentClone = (GameObject)Instantiate(DifferentTarget, new Vector2(firstPosX, firstPosY), Quaternion.identity);
                }

            }
            // Play the stimuli
            if (!clip1Played)
            {
                audioSrc.clip = Files[pairIndex[clip1Index]];
                audioSrc.Play();
                clip1Played = true;
            }
            if (clip1Played && !clip2Played && !audioSrc.isPlaying)
            {
                audioSrc.clip = Files[pairIndex[clip2Index]];
                audioSrc.Play();
                clip2Played = true;
            }

            // Listen for a response and act accordingly
            if (Input.GetButtonDown("LeftBumper"))
            {
                if ((areTheSame && order == 0) || (!areTheSame && order == 1))
                {
                    isCorrect = true;
                    correctAnswers += 1;
                    incorrectAnswers = 0;
                    Debug.Log("Correct");

                }
                else
                {
                    isCorrect = false;
                    incorrectAnswers += 1;
                    correctAnswers = 0;
                    Debug.Log("Inorrect");
                }

                // Restart in a new trial
                // Only get a new set if the answer was correct
                if (isCorrect || incorrectAnswers > 1)
                {
                    Destroy(sameClone);
                    Destroy(differentClone);
                    spawned = false;
                    trialEnded = false;
                }
                clip1Played = false;
                clip2Played = false;
            }
            if (Input.GetButtonDown("RightBumper"))
            {
                if ((areTheSame && order == 1) || (!areTheSame && order == 0))
                {
                    isCorrect = true;
                    correctAnswers += 1;
                    incorrectAnswers = 0;
                    Debug.Log("Correct");
                }
                else
                {
                    isCorrect = false;
                    incorrectAnswers += 1;
                    correctAnswers = 0;
                    Debug.Log("Inorrect");
                }

                // Restart in a new trial
                if (isCorrect || incorrectAnswers > 1)
                {
                    Destroy(sameClone);
                    Destroy(differentClone);
                    spawned = false;
                    trialEnded = false;
                }

                clip1Played = false;
                clip2Played = false;
            }

            if (correctAnswers >= 3)
            {
                correctAnswers = 0;
                NoiseLevel += 1;
            }
            if (NoiseLevel >= 5)
            {
                correctAnswers = 0;
                PairLevel += 1;
                NoiseLevel = 0;
            }
            if (incorrectAnswers >= 2)
            {
                incorrectAnswers = 0;
                NoiseLevel -= 1;
            }
        }
	}
}
