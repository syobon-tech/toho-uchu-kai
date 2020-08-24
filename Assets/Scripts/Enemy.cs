using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public int maxHp;
    public float fireInterval;
    public GameObject bullet;
    public GameObject point;
    protected GameObject player;
    PlayerController script;

    protected int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }

    private int _hp;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        hp = maxHp;
        player = GameObject.FindWithTag("Player");
        script = player.GetComponent<PlayerController>();
        int level = script.level;
        fireInterval *= (float)Math.Sqrt(level + 4) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Instantiate(point, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    void Fire_a() {

        Vector3 vector = (player.transform.position - transform.position).normalized;
        vector.z = 0;
        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, vector));
    }

    protected float angle;
    void Fire_b() {
        float rotation = 0;
        while (rotation <= 360) {
            Instantiate(bullet, transform.position, Quaternion.AngleAxis(rotation, Vector3.forward));
            rotation += angle;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "PlayerBullet") {
            hp--;
            Destroy(coll.gameObject);
        }
    }
}
