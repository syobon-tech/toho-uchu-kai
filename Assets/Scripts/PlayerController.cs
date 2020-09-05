// using
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
    // 変数宣言
    public static int score; // スコア格納
    public static int GetScore(){ // 他スクリプトにスコアを渡すやつ
        return score;
    }

    // Unityインスペクタで値を指定するやつ
    public float shotInterval;          // 弾の発射間隔
    public float scoreWithTimeInterval; // 何秒経過でスコアが上昇するか

    // ゲーム内で使用するやつ
    public int maxHp = 20;  // 初期体力の基準値
    int bestScore;          // ベストスコア格納
    public int level;       // レベル格納
    float shotTimer;        // 前回弾を発射してからの秒数
    float scoreTimer;       // 前回時間経過でスコア上昇してからの秒数

    // ゲームオブジェクト等
    public GameObject bullet;   // 自機球
    public Text scoreText;      // スコア表示
    public Text bestScoreText;  // ベストスコア表示
    public Slider slider;       // HP表示 (バー)
    public Text hpText;         // HP表示 (数字)
    public Text enemyCountText; // 敵の数表示
    public Text levelText;      // レベル表示

    // 体力のプロパティ
    protected int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;

            // 死亡処理
            if(_hp <= 0)
            {
                _hp = 0;
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    // 体力格納の本体
    private int _hp;

    // 起動処理
    void Start()
    {
        int difficulty = DifficultySelector.GetDifficulty(); // 難易度取得
        string scorefile = ""; // スコア格納ファイルを指定するための変数宣言

        // 難易度による初期化処理
        switch (difficulty) {
            case 0: // EASY
                scorefile = Application.streamingAssetsPath + "/easyscore";
                using (StreamReader reader = new StreamReader(scorefile, Encoding.GetEncoding("UTF-8"))) {
                    bestScore = int.Parse(reader.ReadLine());
                }
                break;

            case 1: // HARD
                maxHp /= 2;
                scorefile = Application.streamingAssetsPath + "/hardscore";
                using (StreamReader reader = new StreamReader(scorefile, Encoding.GetEncoding("UTF-8"))) {
                    bestScore = int.Parse(reader.ReadLine());
                }
                break;

            case 2: // IMPOSSIBLE
                maxHp = 1;
                scorefile = Application.streamingAssetsPath + "/owatascore";
                using (StreamReader reader = new StreamReader(scorefile, Encoding.GetEncoding("UTF-8"))) {
                    bestScore = int.Parse(reader.ReadLine());
                }
                break;

            default: // なにかの都合で難易度指定できなかったとき用
                hp = maxHp;
                bestScore = 0;
                break;
        }
        hp = maxHp; // 体力初期化
        score = 0;  // スコア初期化
        bestScoreText.text = bestScore.ToString(); // ベストスコア表示
    }

    // 毎フレームごとの処理
    void Update () {
        // 入力を取得
        float inputLR = Input.GetAxisRaw("Horizontal");
        float inputUD = Input.GetAxisRaw("Vertical");

        // 移動
        if (inputLR > 0 && transform.position.x < 0.75)
        {
            transform.Translate(0.1f, 0, 0); // 右
        }
        else if (inputLR < 0 && transform.position.x > -7.75)
        {
            transform.Translate(-0.1f, 0, 0); // 左
        }

        if (inputUD > 0 && transform.position.y < 4.75)
        {
            transform.Translate(0, 0.1f, 0); // 下
        }
        else if (inputUD < 0 && transform.position.y > -4.75)
        {
            transform.Translate(0, -0.1f, 0); // 上
        }

        // 弾発射
        if (Input.GetAxisRaw("Fire1") == 1) {
            // 発射
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

            // 発射からの時間加算
            shotTimer += Time.deltaTime;
            if (shotTimer >= shotInterval) {
                shotTimer = 0; // 指定した時間が経過したら発射できるようにする
            }
        } else {
            shotTimer = 0; // 発射ボタンを離したら即発射可能に
        }

        // レベル変更
        double level_d = score / 1000; // スコアを1000で割ったものがレベルの参考値

        // 内部的なレベルは難易度によって変動
        int difficulty = DifficultySelector.GetDifficulty();
        switch (difficulty) {
            case 0: // EASY
                level = (int)Math.Floor(level_d) + 1; // 参考値に1を足して切り捨て
                break;

            case 1: // HARD
                level = (int)Math.Floor(level_d) + 3; // 参考値に3を足して切り捨て
                break;

            case 2: // IMPOSSIBLE
                level = (int)Math.Floor(level_d) + 5; // 参考値に5を足して切り捨て
                break;

            default: // 難易度選択ができなかった場合EASYと同じに
                level = (int)Math.Floor(level_d) + 1;
                break;
        }
        levelText.text = ((int)Math.Floor(level_d) + 1).ToString(); // 表示するレベルは難易度に関係なく基準値に1を足して切り捨てたもの

        // 時間経過でのスコア増加
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= scoreWithTimeInterval) {
            score += (int)Math.Floor(level_d) + 1;
            scoreTimer = 0;
        }

        // 各種表示類
        scoreText.text = score.ToString();  // スコア表示
        hpText.text = hp.ToString();        // HP表示 (数字)
        slider.value = (float)hp / (float)maxHp;    // HP表示 (バー)
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag("Enemy");   // 敵の数のカウント
        enemyCountText.text = (tagObjects.Length).ToString();                   // 敵の数を表示
    }

    // 当たり判定
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "EnemyBullet") // 敵の弾との接触
        {
            hp--;
        }
        else if (coll.gameObject.tag == "Point") // 得点との接触
        {
            score += 100;
        }
        Destroy (coll.gameObject); // 接触相手を削除
    }
}
