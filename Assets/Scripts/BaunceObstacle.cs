using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaunceObstacle : MonoBehaviour
{
    
    [SerializeField]
    private int point;
    [SerializeField]
    BallShooter ballShooter;

    // Start is called before the first frame update
    void Start()
    {
        ballShooter.GetComponent<BallShooter>();
    }
    

    void OnTriggerEnter(Collider other)
    {
        // ボールとの判定を取ります
        if (other.tag == "Ball")
        {
            bool isScore = other.gameObject.GetComponent<BallManager>().getIsDouble();
            // スコアの加算
            ballShooter.AddPoint((isScore)?point*2:point);

            // ボール生成時に速度を持たせる
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, Random.Range(15.0f, 25.0f), Random.Range(-10.0f, 10.0f));
        }
    }
}
