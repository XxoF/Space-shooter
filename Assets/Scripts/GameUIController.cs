using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public static int scoreValue = 0;
    public TextMeshProUGUI scoreUI, GameOverUI;

    void Start()
    {
        GameOverUI.gameObject.SetActive(false);
        scoreUI.text = scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().getScore();
        scoreUI.text = "Score: " + scoreValue;
    }

    public void GameOver()
    {
        GameOverUI.gameObject.SetActive(true);
    }
}
