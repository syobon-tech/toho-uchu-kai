using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBulletJikinerai : MonoBehaviour
{
    public float speed;
    Vector3 target;
    float speedX;
    float speedY;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        target = player.transform.position;
        float distanceX = target.x - transform.position.x;
        float distanceY = target.y - transform.position.y;
        float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        float velocity = distance / speed;
        speedX = distanceX / velocity;
        speedY = distanceY / velocity;
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
