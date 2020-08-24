using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public static int score;
    public static int GetScore(){
        return score;
    }

    int bestScore;
    [SerializeField]
    public int maxHp;
    public int level;
    public float shotInterval;
    public float scoreWithTimeInterval;
    public GameObject bullet;
    public Text scoreText;
    public Text bestScoreText;
    public Text hpText;
    public Text enemyCountText;
    public Text levelText;
    float shotTimer;
    float scoreTimer;

    protected int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            if(_hp <= 0)
            {
                _hp = 0;
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    private int _hp;

    // Start is called before the first frame update
    void Start()
    {
        int difficulty = DifficultySelector.GetDifficulty();
        switch (difficulty) {
            case 0:
                hp = maxHp;
                bestScore = PlayerPrefs.GetInt("easyBestScore", 0);
                break;

            case 1:
                hp = maxHp / 2;
                bestScore = PlayerPrefs.GetInt("hardBestScore", 0);
                break;

            case 2:
                hp = 1;
                bestScore = PlayerPrefs.GetInt("owataBestScore", 0);
                break;

            default:
                hp = maxHp;
                bestScore = 0;
                break;
        }
        bestScoreText.text = bestScore.ToString();
        score = 0;
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
            if (shotTimer == 0) {
                Vector3 bulletPosition = transform.position;
                bulletPosition.y += 0.5f;
                Instantiate(bullet, bulletPosition, Quaternion.identity);
                bulletPosition.y -= 0.2f;
                bulletPosition.x -= 0.5f;
                Instantiate(bullet, bulletPosition, Quaternion.identity);
                bulletPosition.x += 1f;
                Instantiate(bullet, bulletPosition, Quaternion.identity);
            }
            shotTimer += Time.deltaTime;
            if (shotTimer >= shotInterval) {
                shotTimer = 0;
            }
        } else {
            shotTimer = 0;
        }

        // Change Level
        double level_d = score / 1000;
        int difficulty = DifficultySelector.GetDifficulty();
        switch (difficulty) {
            case 0:
                level = (int)Math.Floor(level_d) + 1;
                break;

            case 1:
                level = (int)Math.Floor(level_d) + 3;
                break;

            case 2:
                level = (int)Math.Floor(level_d) + 5;
                break;

            default:
                level = (int)Math.Floor(level_d) + 1;
                break;
        }
        levelText.text = "Level: " + ((int)Math.Floor(level_d) + 1).ToString();

        // Scoreing
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= scoreWithTimeInterval) {
            score += (int)Math.Floor(level_d) + 1;
            scoreTimer = 0;
        }
        scoreText.text = score.ToString();

        hpText.text = hp.ToString();
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountText.text = (tagObjects.Length).ToString();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "EnemyBullet")
        {
            hp--;
        }
        else if (coll.gameObject.tag == "Point")
        {
            score += 100;
        }
        Destroy (coll.gameObject);
    }
}
