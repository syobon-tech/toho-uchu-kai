using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed,0);

        if (transform.position.y < -4.5 || transform.position.y > 4.5 || transform.position.x < -8 || transform.position.x > 0)
        {
            Destroy(gameObject);
        }
    }
}
