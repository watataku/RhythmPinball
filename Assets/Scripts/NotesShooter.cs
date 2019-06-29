using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesShooter : MonoBehaviour
{
    private float countTimer;
    [SerializeField]
    private float interval;

    // Update is called once per frame
    void Update()
    {
        if (countTimer >= interval)
        {
            GameObject Notes = Resources.Load<GameObject>("Notes");
            Vector3 spawnPoint = GetComponentInParent<Transform>().transform.position;

            if (Notes != null)
            {
                GameObject notes = Instantiate(Notes, spawnPoint, Quaternion.identity);

                notes.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, -5.0f, 0.0f);
            }
            countTimer = 0;
        }

        countTimer += Time.deltaTime;
    }
}
