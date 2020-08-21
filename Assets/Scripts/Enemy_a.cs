using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_a : Enemy
{
    public float fireInterval;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        InvokeRepeating("Fire_a", 1, fireInterval);
    }
}
