using UnityEngine;
using System.Collections;

public class MainScript01_game : MonoBehaviour
{

    // The hardcoded audio files.
    private static AudioClip[] Files;

    // The noise and pair levels (variables)
    private int NoiseLevel = 0;
    private int PairLevel = 1;
    // Create an array to store the clip indices
    public int[] pairIndex;

    // Overall score
    public static int overallScore;
    public int showScore;
    public int sizeIncrements;

    // Variables to keep track of the clip index in the files
    private int clip1Index;
    private int clip2Index;
    //Check if the played clips are the same.
    private bool areTheSame;
    // Check if the trial ended
    private bool trialEnded = false;

    // Keep track of correct and incorrect answers
    private int correctAnswers;
    private int incorrectAnswers;
    // Check if the current trial's response was correct
    private bool isCorrect;

    // Prefabs for the target answer
    public GameObject SameTarget;
    public GameObject DifferentTarget;
    // Clones of the prefabs (for easier management and destruction on key press)
    private GameObject sameClone;
    private GameObject differentClone;
    // Position of the prefab clones on the screen
    public float firstPosX = -2.5f;
    public float secondPosX = 3.0f;
    public float firstPosY = 2.0f;
    public float secondPosY = 2.0f;
    // Current position of the player
    private Vector2 currentPos;
    // Did the clones spawn already? (Boolean variable)
    private bool spawned = false;

    // Speed of the alien
    public float speed = 0.5f;

    // Make the files into audible objects
    private AudioClip clip1;
    private AudioClip clip2;
    // The audio source that will play the files
    private AudioSource audioSource;
    // Did the clips play already for this trial?
    private bool clip1Played = false;
    private bool clip2Played = false;


    // Use this for initialization
    void Start()
    {
        // Initialize the audio source.
        audioSource = GetComponent<AudioSource>();

        // Get the current position of the player
        Vector2 currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        showScore = overallScore;
        if (!trialEnded)
        {
            if (!spawned)
            {
                // Stop it from looping 
                spawned = true;
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
                sameClone = (GameObject)Instantiate(SameTarget, new Vector2(currentPos.x + firstPosX, currentPos.y + firstPosY), Quaternion.identity);
                differentClone = (GameObject)Instantiate(DifferentTarget, new Vector2(currentPos.x + secondPosX, currentPos.y + secondPosY), Quaternion.identity);

            }
            // Play the stimuli
            if (!clip1Played)
            {
                audioSource.clip = Files[pairIndex[clip1Index]];
                audioSource.Play();
                clip1Played = true;
            }
            if (clip1Played && !clip2Played && !audioSource.isPlaying)
            {
                audioSource.clip = Files[pairIndex[clip2Index]];
                audioSource.Play();
                clip2Played = true;
            }

            // Listen for a response and act accordingly
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("LeftBumper"))
            {
                if (areTheSame)
                {
                    isCorrect = true;
                    correctAnswers += 1;
                    overallScore += sizeIncrements;
                    incorrectAnswers = 0;
                    Debug.Log("Correct");
                    currentPos.x += firstPosX;
                    currentPos.y += (firstPosY + 2);
                    iTween.MoveTo(gameObject, new Vector3(currentPos.x, currentPos.y, 0), speed);

                }
                else
                {
                    isCorrect = false;
                    incorrectAnswers += 1;
                    overallScore -= sizeIncrements;
                    correctAnswers = 0;
                    Debug.Log("Inorrect");
                }

                // Restart in a new trial
                // Only get a new set if the answer was correct
                if (isCorrect || incorrectAnswers > 1)
                {
                    Destroy(differentClone);
                    Destroy(sameClone);
                    spawned = false;
                    trialEnded = false;
                }
                clip1Played = false;
                clip2Played = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButtonDown("RightBumper"))
            {
                if (!areTheSame)
                {
                    isCorrect = true;
                    correctAnswers += 1;
                    overallScore += sizeIncrements;
                    incorrectAnswers = 0;
                    Debug.Log("Correct");
                    currentPos.x += secondPosX;
                    currentPos.y += (secondPosY + 2);
                    iTween.MoveTo(gameObject, new Vector3(currentPos.x, currentPos.y, 0), speed);

                }
                else
                {
                    isCorrect = false;
                    incorrectAnswers += 1;
                    overallScore -= sizeIncrements;
                    correctAnswers = 0;
                    Debug.Log("Inorrect");
                }

                // Restart in a new trial
                if (isCorrect || incorrectAnswers > 1)
                {
                    Destroy(differentClone);
                    Destroy(sameClone);
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
