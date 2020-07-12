using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBulletJikinerai : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 target;
    float speedX;
    float speedY;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        target = GameObject.Find("player").transform.position;
        float distanceX = target.x - transform.position.x;
        float distanceY = target.y - transform.position.y;
        float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        float speed = distance / 0.1f;
        speedX = distanceX / speed;
        speedY = distanceY / speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedX, speedY, 0);

        if (transform.position.y < -4.5 || transform.position.y > 4.5 || transform.position.x < -8 || transform.position.x > 0)
        {
            Destroy(gameObject);
        }
    }
}
