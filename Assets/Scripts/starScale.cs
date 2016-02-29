using UnityEngine;
using System.Collections;

public class starScale : MonoBehaviour {

    private float score = (MainScript01_game.overallScore * 0.05f) % 0.5f;

    // Use this for initialization
    void Start () {
        transform.localScale += new Vector3(score, score, 0);      
	}
}
