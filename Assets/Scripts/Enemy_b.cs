using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_b : Enemy
{
    public float fireInterval;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        int anglecut = Random.Range(2,16);
        angle = 360 / anglecut;
        InvokeRepeating("Fire_b", 1, fireInterval);
    }
}
