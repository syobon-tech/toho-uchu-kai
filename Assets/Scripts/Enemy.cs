using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            if(hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private int _hp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
