using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        InvokeRepeating("Fire", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(hp);
    }

    void Fire() {
        Vector3 bulletPosition = transform.position;
        Instantiate(bullet, bulletPosition, Quaternion.identity);
        Debug.Log("fired");
    }
}
