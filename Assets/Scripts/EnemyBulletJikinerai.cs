using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletJikinerai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("player").transform.position.x < transform.position.x)
        {
            transform.Translate(-0.05f, -0.05f, 0);
        }else if (GameObject.Find("player").transform.position.x > transform.position.x)
        {
            transform.Translate(0.05f, -0.05f, 0);
        }

        if (transform.position.y < -4.5) {
            Destroy(gameObject);
        }
    }
}
