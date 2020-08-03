using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;

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
        hp = 10;
    }

    // Update is called once per frame
    void Update () {
        float inputLR = Input.GetAxisRaw("Horizontal");
        float inputUD = Input.GetAxisRaw("Vertical");

        // Moving
        if (inputLR > 0 && transform.position.x < 0)
        {
            transform.Translate(0.1f, 0, 0);
        }
        else if (inputLR < 0 && transform.position.x > -8)
        {
            transform.Translate(-0.1f, 0, 0);
        }

        if (inputUD > 0 && transform.position.y < 4.5)
        {
            transform.Translate(0, 0.1f, 0);
        }
        else if (inputUD < 0 && transform.position.y > -4.5)
        {
            transform.Translate(0, -0.1f, 0);
        }

        // Fire
        if (Input.GetAxisRaw("Fire1") == 1) {
            Vector3 bulletPosition = transform.position;
            bulletPosition.y += 0.5f;
            Instantiate(bullet, bulletPosition, Quaternion.identity);
            bulletPosition.y -= 0.5f;
            bulletPosition.x -= 0.5f;
            Instantiate(bullet, bulletPosition, Quaternion.identity);
            bulletPosition.x += 1f;
            Instantiate(bullet, bulletPosition, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        hp--;
        Destroy (coll.gameObject);
    }
}
