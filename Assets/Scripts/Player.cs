using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        float inputLR = Input.GetAxisRaw("Horizontal");
        float inputUD = Input.GetAxisRaw("Vertical");

        if (inputLR > 0)
        {
            transform.Translate(0.05f, 0, 0);
        }
        else if (inputLR < 0)
        {
            transform.Translate(-0.05f, 0, 0);
        }

        if (inputUD > 0)
        {
            transform.Translate(0, 0.05f, 0);
        }
        else if (inputUD < 0)
        {
            transform.Translate(0, -0.05f, 0);
        }
    }
}
