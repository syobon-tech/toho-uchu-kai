using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemy_a;
    public GameObject enemy_b;
    public GameObject player;
    public int level_saved;
    public float generateEnemyInterval;
    PlayerController script;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateEnemy", 1, generateEnemyInterval);
        script = player.GetComponent<PlayerController>();
        int level_saved = script.level;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null){
            CancelInvoke();
            Destroy(GameObject.Find("enemy(Clone)"));
        }
        if (level_saved < script.level) {
            level_saved = script.level;
            CancelInvoke();
            InvokeRepeating("GenerateEnemy", 1, generateEnemyInterval / (float)Math.Sqrt(Math.Sqrt(level_saved)));
        }
    }

    void GenerateEnemy() {
        Vector3 enemyPosition = new Vector3(UnityEngine.Random.Range(-8f,0f), 2.0f, 3.0f);
        UnityEngine.Random.InitState((DateTime.Now).Millisecond);
        if (UnityEngine.Random.Range(0, 21) <= 10) {
            Instantiate(enemy_a, enemyPosition, Quaternion.identity);
        }else {
            Instantiate(enemy_b, enemyPosition, Quaternion.identity);
        }
    }
}
