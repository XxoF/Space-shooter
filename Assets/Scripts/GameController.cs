using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject asteroidPrefab;

    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float Y = 0;
    public float Z = 17;

    private float randomX;

    void Start()
    {

        spawnAsteriod();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnAsteriod()
    {
        randomX = Random.Range(minX, maxX);

        Vector3 spawnPosition = new Vector3(randomX, 0, 17);
        Quaternion spawnRotation = asteroidPrefab.transform.rotation;


        Instantiate(asteroidPrefab, spawnPosition, spawnRotation);
    }

}
