using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class BestScoreSaver : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject rankingTextObject;
    public Text rankingText;
    string ranking = "Ranking\n\n";

    // Start is called before the first frame update
    void Start()
    {
        int difficulty = DifficultySelector.GetDifficulty();
        int score = PlayerController.GetScore();

        string line;
        int[] scores = new int[10];
        string output = "";

        string scorefile = "";
        switch (difficulty) {
            case 0:
                scorefile = Application.streamingAssetsPath + "/easyscore";
                break;

            case 1:
                scorefile = Application.streamingAssetsPath + "/hardscore";
                break;

            case 2:
                scorefile = Application.streamingAssetsPath + "/owatascore";
                break;
        }

        using (StreamReader reader = new StreamReader(scorefile, Encoding.GetEncoding("UTF-8"))) {
            int loop = 0;
            while ((line = reader.ReadLine()) != null) {
                scores[loop] = int.Parse(line);
                loop++;
            }
        }
        for (int i = 0; i <= 9; i++) {
            if (score > scores[i]) {
                for (int j = 8; j >= i; j--) {
                    scores[j + 1] = scores[j];
                }
                scores[i] = score;
                ranking += score.ToString() + "　← Here\n";
                for (int j = i + 1; j <= 8; j++) {
                    ranking += scores[j].ToString() + "\n";
                }
                ranking += scores[9].ToString();
                break;
            }else {
                ranking += scores[i].ToString() + "\n";
                if (i == 9) {
                    ranking += "--------\n" + score.ToString() + "　← Here";
                }
            }
        }
        for (int i = 0; i <= 8; i++) {
            output += scores[i].ToString() + "\n";
        }
        output += scores[9].ToString();
        using (FileStream fs = new FileStream(scorefile, FileMode.Open)) {
            fs.SetLength(0);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write(output);
            writer.Close();
        }
        Invoke("ShowRanking", 5f);
    }

    // Update is called once per frame
    void ShowRanking()
    {
        gameOverText.SetActive(false);
        rankingText.text = ranking;
        rankingTextObject.SetActive(true);
    }
}