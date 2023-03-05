using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject asteroidPrefab;

    [SerializeField]
    private int score;

    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float Y = 0;
    public float Z = 17;

    public int count;
    public float startWait;
    public float cloneWait;
    public float waveWait;

    private float randomX;

    public GameObject player;
    public GameObject gameUI;

    private bool gameOver;
    void Start()
    {
        gameOver = false;
        score = 0;
        StartCoroutine(Waves());
    }

    private void Update()
    {
        //Debug.Log(score.ToString());

        // IF game is over
        if (isGameOver())
        {
            gameOver = true;
            gameUI.GetComponent<GameUIController>().GameOver();
        }


        if (gameOver && Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("MainScene");
        }


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
        while (!gameOver)
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

    public void addScore()
    {
        this.score += 1;
    }

    public int getScore()
    {
        return this.score;
    }

    private bool isGameOver()
    {
        return !player.GetComponent<PlayerController>().isAlive();
    }

}
