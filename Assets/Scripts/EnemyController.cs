using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy
{
    public float fireInterval;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        InvokeRepeating("Fire", 1, fireInterval);
    }
}
