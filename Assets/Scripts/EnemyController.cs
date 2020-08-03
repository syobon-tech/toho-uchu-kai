using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        InvokeRepeating("Fire", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
