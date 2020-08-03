using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    int score;
    GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = score.ToString("D4");
    }

    public void AddScore()
    {
        score += 100;
    }
}
