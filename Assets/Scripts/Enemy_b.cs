using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_b : Enemy
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        int anglecut = Random.Range(2,16);
        angle = 360 / anglecut;
        InvokeRepeating("Fire_b", 1, fireInterval);
    }
}
