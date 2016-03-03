using UnityEngine;
using System.Collections;

public class audioStimuli : MonoBehaviour
{
    public AudioClip[] bWords;
    public AudioClip[] dWords;
    public AudioClip[] pWords;
    public AudioClip[] sWords;
    public AudioClip[] tWords;
    public AudioClip[] zWords;
    //public AudioClip[] vWords;
    //public AudioClip[] fWords;

    public AudioClip[] correctTrials;

    private AudioSource audioSource;
    private int cachedClip;

    // Select between the two sets of words
    public static int wordRandomizer;

    private bool soundPlayed = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int [] finalists = new int[] { Random.Range(1, 7), Random.Range(1, 7), Manager.letterLevel };
        wordRandomizer = finalists[Random.Range(0, finalists.Length)];
    }

    void Update()
    {
        if (!audioSource.isPlaying && !soundPlayed)
        {
            switch (wordRandomizer)
            {
                case 1:
                    cachedClip = Random.Range(0, pWords.Length);
                    audioSource.clip = pWords[cachedClip];
                    if (ShootingStar.wasCorrect)
                    {
                        //correctTrials.Add(pWords[cachedClip]);
                    }
                    break;
                case 2:
                    audioSource.clip = bWords[Random.Range(0, bWords.Length)];
                    break;

                case 3:
                    audioSource.clip = sWords[Random.Range(0, sWords.Length)];
                    break;

                case 4:
                    audioSource.clip = zWords[Random.Range(0, zWords.Length)];
                    break;

                case 5:
                    audioSource.clip = tWords[Random.Range(0, tWords.Length)];
                    break;

                case 6:
                    audioSource.clip = dWords[Random.Range(0, dWords.Length)];
                    break;

                //case 7:
                //    audiosource.clip = fwords[random.range(0, fwords.length)];
                //    break;

                //case 8:
                //    audiosource.clip = vwords[random.range(0, vwords.length)];
                //    break;

            }


            //audio.Play();
            audioSource.Play();
            soundPlayed = true;


        }

    }
}  
