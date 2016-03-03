using UnityEngine;
using System.Collections;


public class PlayerControllerMG1 : MonoBehaviour
{

    public GameObject DifferentStars;
    public GameObject SameStars;
    public AudioClip[] P01L00;
    public AudioClip[] P01L01;
    public AudioClip[] P01L02;
    public AudioClip[] P02L00;
    public AudioClip[] P02L01;
    public AudioClip[] P02L02;
    public AudioClip[] P03L00;
    public AudioClip[] P03L01;
    public AudioClip[] P03L02;


    public static int starOrder = Random.Range(0, 2);
    public static bool isTheSame = false;
    public int PairNumber = 1;
    public int noiseLevel = 0;

    private bool clip1Played = true;
    private bool clip2Played = true;
    private bool initialClip1Played = false;
    private bool initialClip2Played = false;
    private int clip1;
    private int clip2;
    private AudioSource audioSource;

    // Keep track of correct and incorrect answers
    public int correctAnswers = 0;
    public int incorrectAnswers = 0;
    public int score = 0;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (starOrder == 0)
        {
            Instantiate(DifferentStars, new Vector3(transform.position.x - 3, transform.position.y + 4), Quaternion.identity);
            Instantiate(SameStars, new Vector3(transform.position.x + 3, transform.position.y + 4), Quaternion.identity);

        }
        else if (starOrder == 1)
        {
            Instantiate(DifferentStars, new Vector3(transform.position.x + 3, transform.position.y + 4), Quaternion.identity);
            Instantiate(SameStars, new Vector3(transform.position.x - 3, transform.position.y + 4), Quaternion.identity);

        }

        // Play two clips from the current pair at the current noise level
        clip1 = Random.Range(0, 2);
        clip2 = Random.Range(0, 2);
        if (clip1 == clip2)
        {
            isTheSame = true;
        }
        else
        {
            isTheSame = false;
        }

    }



    // Update is called once per frame
    void Update()
    {

        // Increase noise level
        if (correctAnswers == 3 && noiseLevel < 2)
        {
            clip1Played = true;
            correctAnswers = 0;
            noiseLevel += 1;
            clip1Played = false;
        }

        // Reduce noise level
        if (incorrectAnswers == 2)
        {
            clip1Played = true;
            incorrectAnswers = 0;
            if (noiseLevel > 0)
            {
                noiseLevel -= 1;
            }
            else if (noiseLevel <= 0)
            {
                noiseLevel = 0;
            }
            clip1Played = false;
        }

        if (correctAnswers == 3 && noiseLevel >= 2)
        {
            noiseLevel = 0;
            correctAnswers = 0;
            PairNumber += 1;
        }


        if (!initialClip1Played)
        {
            audioSource.clip = P01L00[clip1];
            initialClip1Played = true;
            audioSource.Play();
        }

        if(initialClip1Played && !initialClip2Played && !audioSource.isPlaying)
        {
            audioSource.clip = P01L00[clip2];
            initialClip2Played = true;
            audioSource.Play();
        }



        // When the player presses the left arrow, do this
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (starOrder == 0 && !isTheSame)
            {
                correctAnswers += 1;
                incorrectAnswers = 0;
                score += 1;
            }
            else if (starOrder == 0 && isTheSame)
            {
                correctAnswers = 0;
                incorrectAnswers += 1;
                score -= 1;
            }
            else if (starOrder == 1 && !isTheSame)
            {
                correctAnswers = 0;
                incorrectAnswers += 1;
                score -= 1;
            }
            else if (starOrder == 1 && isTheSame)
            {
                correctAnswers += 1;
                incorrectAnswers = 0;
                score += 1;
            }

            clip1 = Random.Range(0, 2);
            clip2 = Random.Range(0, 2);
            if (clip1 == clip2)
            {
                isTheSame = true;
            }
            else
            {
                isTheSame = false;
            }
            clip1Played = false;
            clip2Played = false;
            Vector2 position = this.transform.position;
            position.x += -3;
            position.y += 4;
            this.transform.position = position;
            starOrder = Random.Range(0, 2);

            if (starOrder == 0)
            {
                Instantiate(DifferentStars, new Vector3(transform.position.x - 3, transform.position.y + 4), Quaternion.identity);
                Instantiate(SameStars, new Vector3(transform.position.x + 3, transform.position.y + 4), Quaternion.identity);
            }
            else if (starOrder == 1)
            {
                Instantiate(DifferentStars, new Vector3(transform.position.x + 3, transform.position.y + 4), Quaternion.identity);
                Instantiate(SameStars, new Vector3(transform.position.x - 3, transform.position.y + 4), Quaternion.identity);
            }

            if (PairNumber == 1)
            {
                if (noiseLevel == 0)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P01L00[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P01L00[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
                else if (noiseLevel == 1)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P01L01[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P01L01[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
                else if (noiseLevel == 2)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P01L02[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && !clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P01L02[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
            }
            else if (PairNumber == 2)
            {
                if (noiseLevel == 0)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P02L00[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && !clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P02L00[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
                else if (noiseLevel == 1)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P02L01[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && !clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P02L01[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
                else if (noiseLevel == 2)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P02L02[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && !clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P02L02[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
            }
            else if (PairNumber == 3)
            {
                if (noiseLevel == 0)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P03L00[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && !clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P03L00[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
                else if (noiseLevel == 1)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P03L01[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && !clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P03L01[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
                else if (noiseLevel == 2)
                {
                    if (!clip1Played)
                    {
                        audioSource.clip = P03L02[clip1];
                        clip1Played = true;
                        audioSource.Play();
                    }

                    if (clip1Played && !clip2Played && !audioSource.isPlaying)
                    {
                        audioSource.clip = P03L02[clip2];
                        clip2Played = true;
                        audioSource.Play();
                    }
                }
            }

        } // When the player presses the right arrow, do this
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (starOrder == 0 && isTheSame)
            {
                correctAnswers += 1;
                incorrectAnswers = 0;
                score += 1;
            }
            else if (starOrder == 0 && !isTheSame)
            {
                correctAnswers = 0;
                incorrectAnswers += 1;
                score -= 1;
            }
            else if (starOrder == 1 && isTheSame)
            {
                correctAnswers = 0;
                incorrectAnswers += 1;
                score -= 1;
            }
            else if (starOrder == 1 && !isTheSame)
            {
                correctAnswers += 1;
                incorrectAnswers = 0;
                score += 1;
            }

            clip1Played = false;
            clip2Played = false;
            clip1 = Random.Range(0, 2);
            clip2 = Random.Range(0, 2);
            if (clip1 == clip2)
            {
                isTheSame = true;
            }
            else
            {
                isTheSame = false;
            }

            Vector2 position = this.transform.position;
            position.x += 3;
            position.y += 4;
            this.transform.position = position;
            starOrder = Random.Range(0, 2);
            if (starOrder == 0)
            {
                Instantiate(DifferentStars, new Vector3(transform.position.x - 3, transform.position.y + 4), Quaternion.identity);
                Instantiate(SameStars, new Vector3(transform.position.x + 3, transform.position.y + 4), Quaternion.identity);

            }
            else if (starOrder == 1)
            {
                Instantiate(DifferentStars, new Vector3(transform.position.x + 3, transform.position.y + 4), Quaternion.identity);
                Instantiate(SameStars, new Vector3(transform.position.x - 3, transform.position.y + 4), Quaternion.identity);

            }
        }


        if (PairNumber == 1)
        {
            if (noiseLevel == 0)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P01L00[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P01L00[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
            else if (noiseLevel == 1)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P01L01[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P01L01[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
            else if (noiseLevel == 2)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P01L02[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P01L02[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
        }
        else if (PairNumber == 2)
        {
            if (noiseLevel == 0)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P02L00[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P02L00[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
            else if (noiseLevel == 1)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P02L01[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P02L01[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
            else if (noiseLevel == 2)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P02L02[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P02L02[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
        }
        else if (PairNumber == 3)
        {
            if (noiseLevel == 0)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P03L00[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P03L00[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
            else if (noiseLevel == 1)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P03L01[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P03L01[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
            else if (noiseLevel == 2)
            {
                if (!clip1Played)
                {
                    audioSource.clip = P03L02[clip1];
                    clip1Played = true;
                    audioSource.Play();
                }

                if (clip1Played && !clip2Played && !audioSource.isPlaying)
                {
                    audioSource.clip = P03L02[clip2];
                    clip2Played = true;
                    audioSource.Play();
                }
            }
        }

    }


}