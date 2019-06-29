using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private bool isDouble;

    [SerializeField]
    private int point;
    [SerializeField]
    private NotesManager notesManager;
    [SerializeField]
    private Material doubleMaterial;

    [SerializeField]
    BallShooter ballShooter;
    

    // Start is called before the first frame update
    void Start()
    {
        isDouble = false;
        notesManager.GetComponent<NotesManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            Destroy(gameObject);
        }
        if(other.tag == "Double")
        {
            if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))
            {
                if (notesManager.JudgingFromCount())
                {
                    gameObject.GetComponent<Renderer>().material = doubleMaterial;
                    isDouble = true;
                }
            }
        }
    }

    public bool getIsDouble()
    {
        return isDouble;
    }
}
