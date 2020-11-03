using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


//public string dialogueBlock;

public class TeleportScript : MonoBehaviour
{
    public Flowchart flowchart;
    public Transform target;
    public Transform playerTransform;
    public Rigidbody playerBody;

    public GameObject Player;
    private bool playerTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTrigger = true;
        }
    }

    void Start()
    {
        playerTrigger = false;
    }

    void Update()
    {
        if (playerTrigger)
        {
            StartCoroutine("timeDelay");
            playerTrigger = false;
        }
    }

    private IEnumerator timeDelay()
    {
        Player.SetActive(false);
        flowchart.ExecuteBlock("Fade Out");
        yield return new WaitForSeconds(2);

        Player.SetActive(true);
        playerTransform.transform.position = target.position;
    }

}