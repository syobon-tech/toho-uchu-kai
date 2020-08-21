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
        if(hp <= 0)
        {
            Instantiate(point, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    void Fire_a() {
        GameObject player = GameObject.FindWithTag("Player");
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
