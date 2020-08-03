using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    public GameObject bullet;
    public GameObject point;

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
                Instantiate(point, transform.position, Quaternion.identity);
            }
        }
    }

    private int _hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Fire() {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.name == "bullet(Clone)") {
            hp--;
            Destroy (coll.gameObject);
        }
    }
}
