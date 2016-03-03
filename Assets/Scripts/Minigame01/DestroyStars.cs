using UnityEngine;
using System.Collections;

public class DestroyStars : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 4.0f);
    }

    void OnCollisionEnter2d()
    {
        Destroy(gameObject);
    }

}
