using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestScript : MonoBehaviour
{
    public AudioClip openSFX;
    public bool isSwordChest;
    public bool isShieldChest;
    public bool isBowChest;
    public bool spawnItems;
    public bool isDoor;

    public bool needsKey;
    public GameObject itemSlot;
    public Transform itemSpawn;

    private GameObject player;
    private float l;

    void Update()
    {
        if (!isDoor)
        {
            if (transform.GetChild(1).gameObject.activeSelf)
            {
                if (itemSlot != null)
                {
                    itemSlot.transform.localPosition = new Vector3(0.0f, Mathf.Lerp(0.0f, 3.0f, l), 0.0f);
                    l += 0.95f * Time.deltaTime;
                    if (l > 1.0f)
                    {
                        itemSlot.transform.localPosition = new Vector3(0.0f, 3.0f, 0.0f);
                    }
                }
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (!isDoor)
        {
            // IF NEEDS KEY, CHECK IF THEY HAVE A KEY
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                if (other.gameObject.GetComponent<PlayerController>() != null)
                {
                    GameObject player = other.gameObject;

                    if (needsKey)
                    {
                        bool canOpen = PlayerHasKey(player);

                        if (canOpen)
                        {
                            OpenChest(player);
                        }
                    }
                    else
                    {
                        OpenChest(player);
                    }
                }
            }
        }
        else
        {
            // IF NEEDS KEY, CHECK IF THEY HAVE A KEY
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                if (other.gameObject.GetComponent<PlayerController>() != null)
                {
                    GameObject player = other.gameObject;

                    if (needsKey)
                    {
                        bool canOpen = PlayerHasKey(player);

                        if (canOpen)
                        {
                            Destroy(transform.gameObject);
                        }
                    }
                }
            }
        }
    }

    // CHECKS FOR KEY
    public bool PlayerHasKey(GameObject player)
    {
        bool hasKey;

        if(PlayerController.numOfKeys > 0)
        {
            PlayerController.numOfKeys--;
            PlayerHUD.UpdatePlayerHUD();
            hasKey = true;
        }
        else
        {
            hasKey = false;
        }

        return hasKey;
    }

    // OPENS CHEST
    void OpenChest(GameObject player)
    {
        if (transform.GetComponent<AudioSource>() != null && openSFX != null)
        {
            transform.GetComponent<AudioSource>().PlayOneShot(openSFX);
        }
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);

        if (isSwordChest)
        {
            player.GetComponent<PlayerTools>().hasSword = true;
        }
        else if (isShieldChest)
        {
            player.GetComponent<PlayerTools>().hasShield = true;
        }
        else if (isBowChest)
        {
            player.GetComponent<PlayerTools>().hasBow = true;
        }
        else
        {
            GameObject spawn = Instantiate(itemSlot.transform.GetChild(0).gameObject, itemSpawn, false);
            spawn.GetComponent<LootPickUpScript>().enabled = true;
            spawn.GetComponent<SphereCollider>().enabled = true;
        }

    }

}
