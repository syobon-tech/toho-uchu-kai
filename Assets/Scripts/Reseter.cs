﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reseter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Reset", 5f);
    }

    // Update is called once per frame
    void Reset()
    {
        SceneManager.LoadScene("Title");
    }
}
