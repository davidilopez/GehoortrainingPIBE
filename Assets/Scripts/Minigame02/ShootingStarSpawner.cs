using UnityEngine;
using System.Collections;

public class ShootingStarSpawner : MonoBehaviour {

    public GameObject ShootingStarPrefab;
    public float spawnTime = 2.0f;

    void Start()
    {
        InvokeRepeating("SpawnStar", spawnTime, spawnTime);
    }

    void SpawnStar()
    {
        GameObject.Instantiate(ShootingStarPrefab);
    }
}
