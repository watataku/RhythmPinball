using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BallShooter : MonoBehaviour
{

    private float countTimer;
    private int ballCount;
    private int score;
    private int highScore;

    [SerializeField]
    private int ballCountMax;
    [SerializeField]
    private float interval;

    [SerializeField]
    private Text scoreBoard;
    [SerializeField]
    private Text highScoreBoard;
    [SerializeField]
    private Text restBallCount;

    // private string filePath = Application.dataPath + @"\Scripts\Text\data.txt";

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        ballCount = ballCountMax;
        highScore = 0;
        highScoreBoard.text = scoreBoard.text;
        /*
        if (!File.Exists(filePath))
        {
            using (File.Create(filePath))
            {

            }
            highScore = 0;
            highScoreBoard.text = scoreBoard.text;
        }
        else
        {
            string[] inputLines = File.ReadAllLines(filePath);
            highScoreBoard.text = inputLines[0];
            highScore = int.Parse(inputLines[0]);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        if (countTimer >= interval && ballCount < ballCountMax)
        {
            GameObject ball = Resources.Load<GameObject>("Ball");
            Vector3 spawnPoint = GetComponentInParent<Transform>().transform.position;
            spawnPoint.x += 0.5f;

            if(ball != null)
            {
                GameObject bullet = Instantiate(ball, spawnPoint, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, Random.Range(-20.0f, 20.0f),Random.Range(-20.0f, 20.0f));
            }

            ballCount++;
            restBallCount.text = (ballCountMax - ballCount).ToString();
            countTimer = 0;
        }

        countTimer += Time.deltaTime;
    }

    public void Reset()
    {
        score = 0;
        countTimer = 0.0f;
        ballCount = 0;
        scoreBoard.text = score.ToString();
        restBallCount.text = ballCountMax.ToString();
    }

    public void AddPoint(int point)
    {
        score += point;
        scoreBoard.text = score.ToString();
        if(score > highScore)
        {
            highScore = score;
            highScoreBoard.text = score.ToString();
        }
    }
}
