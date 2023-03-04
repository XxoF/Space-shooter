using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    public TextMeshProUGUI scoreUI;

    void Start()
    {
        scoreUI.text = scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreValue = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().getScore();
        scoreUI.text = "Score: " + scoreValue;
    }
}
