using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        selfRotation(1);
    }

    // Update is called once per frame
    void Update()
    {
        selfRotation(Time.deltaTime);
    }

    private void selfRotation(float time)
    {
        // Rotate asteroid over time

        float randomX = Random.Range(0, 180);
        float randomY = Random.Range(0, 180);
        float randomZ = Random.Range(0, 180);

        transform.Rotate(randomX * time, randomY * time, randomZ * time);
    }
}
