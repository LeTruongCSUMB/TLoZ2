using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogueScript : MonoBehaviour
{
    public Flowchart flowchart;
    public string dialogue;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            if (other.GetComponent<PlayerController>() != null)
            {
                flowchart.ExecuteBlock(dialogue);
            }
        }
    }
}
