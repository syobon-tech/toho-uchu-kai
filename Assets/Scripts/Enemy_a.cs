using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_a : Enemy
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        InvokeRepeating("Fire_a", 1, fireInterval);
    }
}
