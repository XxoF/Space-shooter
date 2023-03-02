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

    public int count;
    public float startWait;
    public float cloneWait;
    public float waveWait;

    private float randomX;


    void Start()
    {
        StartCoroutine(Waves());
    }



    void spawnAsteriod()
    {
        randomX = Random.Range(minX, maxX);

        Vector3 spawnPosition = new Vector3(randomX, 0, 17);
        Quaternion spawnRotation = asteroidPrefab.transform.rotation;
        Instantiate(asteroidPrefab, spawnPosition, spawnRotation);
    }

    IEnumerator Waves()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i <= count; i++)
            {
                spawnAsteriod();
                yield return new WaitForSeconds(cloneWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
        
    }

}
