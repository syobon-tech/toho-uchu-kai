using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float generateEnemyInterval;

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
        Vector3 enemyPosition = new Vector3(-7f + 5 * Random.value, 2.0f, 3.0f);
        Instantiate(enemy, enemyPosition, Quaternion.identity);
    }
}
