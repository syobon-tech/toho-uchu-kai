﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Submit");
        if (input >= 1) {
            SceneManager.LoadScene("SelectDifficulty");
        }
    }
}
