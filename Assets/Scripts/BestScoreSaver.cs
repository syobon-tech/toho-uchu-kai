using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreSaver : MonoBehaviour
{
    public GameObject newBestText;
    // Start is called before the first frame update
    void Start()
    {
        int difficulty = DifficultySelector.GetDifficulty();
        int score = PlayerController.GetScore();
        int bestScore;
        switch (difficulty) {
            case 0:
                bestScore = PlayerPrefs.GetInt("easyBestScore", 0);
                if (score > bestScore) {
                    newBestText.SetActive(true);
                    PlayerPrefs.SetInt("easyBestScore", score);
                    PlayerPrefs.Save();
                }
                break;

            case 1:
                bestScore = PlayerPrefs.GetInt("hardBestScore", 0);
                if (score > bestScore) {
                    newBestText.SetActive(true);
                    PlayerPrefs.SetInt("easyBestScore", score);
                    PlayerPrefs.Save();
                }
                break;

            case 2:
                bestScore = PlayerPrefs.GetInt("owataBestScore", 0);
                if (score > bestScore) {
                    newBestText.SetActive(true);
                    PlayerPrefs.SetInt("easyBestScore", score);
                    PlayerPrefs.Save();
                }
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
