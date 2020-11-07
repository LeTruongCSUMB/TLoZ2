using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxEntityHealth;
    public AudioClip deathSFX;
    public int currentEntityHealth;
    public bool dropsItem;
    public Transform dropTransform;
    public List<GameObject> dropObjects = new List<GameObject>();
    public bool respawns;
    public float timerMax;
    private float timer;
    public bool respawnTime;
    private bool hasDropped, hasPlayed;

    void Start()
    {
        currentEntityHealth = maxEntityHealth;
        respawnTime = false;
        CheckChance();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEntityHealth <= 0)
        {
            OnDeath(dropsItem, respawns);
        }

        if(respawnTime)
        {
            timer += Time.deltaTime;

            if (timer > timerMax)
            {
                currentEntityHealth = maxEntityHealth;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetComponent<BoxCollider>().enabled = true;
                respawnTime = false;
                NPCSight.hasDied = true;
                CheckChance();
                timer = 0.0f;
                hasPlayed = false;
            }
        }


    }

    void OnDeath(bool dropsItems, bool respawns)
    {
        if (transform.GetComponent<AudioSource>() != null && deathSFX != null)
        {
            if (!transform.GetComponent<AudioSource>().isPlaying && !hasPlayed)
            {
                transform.GetComponent<AudioSource>().PlayOneShot(deathSFX);
                hasPlayed = true;
            }
        }
        if (dropsItems)
        {
            GameObject drop = RandomizeItemDrop();
            Instantiate(drop, dropTransform);
            print("dropping " + drop.name);
            dropsItem = false;
        }
        if(respawns)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetComponent<BoxCollider>().enabled = false;
            if(transform.GetComponent<NPCPatrol>() != null)
            {
                transform.GetComponent<NPCPatrol>().attacking = false;
            }
            respawnTime = true;
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }

    public GameObject RandomizeItemDrop()
    {
        int selectedDrop = Random.Range(0, dropObjects.Count + 1);
        print("I've selected " + selectedDrop);
        return dropObjects[selectedDrop];
    }

    public void CheckChance()
    {
        int check = Random.Range(0, 5);
        if (check == 3)
        {
            dropsItem = true;
        }
        else
        {
            dropsItem = false;
        }
    }
}
