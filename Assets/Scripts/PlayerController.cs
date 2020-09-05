using System;
using System.IO;
using System.Text;
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
    public int maxHp = 20;
    public int level;
    public float shotInterval;
    public float scoreWithTimeInterval;
    public GameObject bullet;
    public Text scoreText;
    public Text bestScoreText;
    public Text hpText;
    public Text enemyCountText;
    public Text levelText;
    public Slider slider;
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
        string scorefile = "";
        switch (difficulty) {
            case 0:
                scorefile = Application.streamingAssetsPath + "/easyscore";
                using (StreamReader reader = new StreamReader(scorefile, Encoding.GetEncoding("UTF-8"))) {
                    bestScore = int.Parse(reader.ReadLine());
                }
                break;

            case 1:
                maxHp /= 2;
                scorefile = Application.streamingAssetsPath + "/hardscore";
                using (StreamReader reader = new StreamReader(scorefile, Encoding.GetEncoding("UTF-8"))) {
                    bestScore = int.Parse(reader.ReadLine());
                }
                break;

            case 2:
                maxHp = 1;
                scorefile = Application.streamingAssetsPath + "/owatascore";
                using (StreamReader reader = new StreamReader(scorefile, Encoding.GetEncoding("UTF-8"))) {
                    bestScore = int.Parse(reader.ReadLine());
                }
                break;

            default:
                hp = maxHp;
                bestScore = 0;
                break;
        }
        hp = maxHp;
        bestScoreText.text = bestScore.ToString();
        score = 0;
    }

    // Update is called once per frame
    void Update () {
        float inputLR = Input.GetAxisRaw("Horizontal");
        float inputUD = Input.GetAxisRaw("Vertical");

        // Moving
        if (inputLR > 0 && transform.position.x < 0.75)
        {
            transform.Translate(0.1f, 0, 0);
        }
        else if (inputLR < 0 && transform.position.x > -7.75)
        {
            transform.Translate(-0.1f, 0, 0);
        }

        if (inputUD > 0 && transform.position.y < 4.75)
        {
            transform.Translate(0, 0.1f, 0);
        }
        else if (inputUD < 0 && transform.position.y > -4.75)
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
        levelText.text = ((int)Math.Floor(level_d) + 1).ToString();

        // Scoreing
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= scoreWithTimeInterval) {
            score += (int)Math.Floor(level_d) + 1;
            scoreTimer = 0;
        }
        scoreText.text = score.ToString();

        hpText.text = hp.ToString();
        slider.value = (float)hp / (float)maxHp;
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
