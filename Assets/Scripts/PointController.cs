using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public float speed;
    public float magnetPower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed, 0);

        GameObject player = GameObject.FindWithTag("Player");
        if (Math.Abs(transform.position.x - player.transform.position.x) <= magnetPower && Math.Abs(transform.position.y - player.transform.position.y) <= magnetPower && transform.position.y > player.transform.position.y && player != null)
        {
            if (Math.Abs(transform.position.x - player.transform.position.x) > speed)
            {
                if (transform.position.x < player.transform.position.x)
                {
                    transform.Translate(speed, 0, 0);
                }
                else if (transform.position.x > player.transform.position.x)
                {
                    transform.Translate(-speed, 0, 0);
                }
            }
        }
        if (transform.position.y < -4.5)
        {
            Destroy(gameObject);
        }
    }
}
