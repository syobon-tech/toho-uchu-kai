using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public static int difficulty;
    public static int GetDifficulty(){
        return difficulty;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToEasy()
    {
        difficulty = 0;
        SceneManager.LoadScene("Arcade");
    }

    public void ToHard()
    {
        difficulty = 1;
        SceneManager.LoadScene("Arcade");
    }

    public void ToOwata()
    {
        difficulty = 2;
        SceneManager.LoadScene("Arcade");
    }
}
