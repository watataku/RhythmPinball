using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    private float countTimer;
    // Start is called before the first frame update
    void Start()
    {
        countTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        countTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            Destroy(gameObject);
        }
        if(other.tag == "Area")
        {
            countTimer = 0.0f;
        }
    }

    public bool JudgingFromCount()
    {
        return countTimer < 0.15f;
    }

}
