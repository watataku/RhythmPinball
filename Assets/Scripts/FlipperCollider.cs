using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperCollider : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))
            {
                bool sound = other.gameObject.GetComponent<BallManager>().getIsDouble();
                audioSource.PlayOneShot((sound) ? sound2 : sound1);
            }
        }
    }
}
