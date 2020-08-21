using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemy_a;
    public GameObject enemy_b;
    public GameObject player;
    public float generateEnemyInterval;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateEnemy", 1, generateEnemyInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null){
            CancelInvoke();
            Destroy(GameObject.Find("enemy(Clone)"));
        }
    }

    void GenerateEnemy() {
        Vector3 enemyPosition = new Vector3(-8f + 8 * Random.value, 2.0f, 3.0f);
        Random.InitState(Random.Range(0,100));
        if (Random.Range(0, 21) <= 10) {
            Instantiate(enemy_a, enemyPosition, Quaternion.identity);
        }else {
            Instantiate(enemy_b, enemyPosition, Quaternion.identity);
        }
    }
}
