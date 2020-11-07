using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public int maxPlayerHealth = 6;
    public static int playerHealth = 6;
    public float playerSpeed;
    public static float speedFactor;

    public static int numOfKeys;
    public static int maxKeyCount = 99;
    public static int lupeeCount;
    public static int maxLupeeCount = 999;

    public bool moveable = true;    //Flag to control if input can move the player
    public GameObject currentDisplay = null;

    void Update()
    {
        //print("Player Health is " + playerHealth);

        if (Input.anyKey && moveable)
        {
            if (!PlayerTools.swinging)
            {
                MovePlayer();
            }
        }
    }

    public void SetMoveableTrue()
    {
        moveable = true;
    }

    public void SetMoveableFalse()
    {
        moveable = false;
    }

    public void SetDisplay(GameObject o)
    {
        currentDisplay = o;
    }

    public string getDisplayName()
    {
        return currentDisplay.GetComponent<ItemDisplayInteractScript>().getItemName();
    }

    public int getDisplayValue()
    {
        return currentDisplay.GetComponent<ItemDisplayInteractScript>().getValue();
    }

    public void purchaseDisplayItem()
    {
        currentDisplay.GetComponent<ItemDisplayInteractScript>().purchaseItem();
    }


    // MOVES THE PLAYER
    void MovePlayer()
    {
        if(PlayerTools.shielding)
        {
            speedFactor = 2.0f;
        }
        else
        {
            speedFactor = 1.0f;
        }

        if (Input.GetKey("w"))
        {
            player.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            player.transform.Translate(Vector3.forward * Time.deltaTime * (playerSpeed/speedFactor));
        }

        if (Input.GetKey("s"))
        {
            player.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            player.transform.Translate(Vector3.forward * Time.deltaTime * (playerSpeed / speedFactor));
        }

        if (Input.GetKey("a"))
        {
            player.transform.localRotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
            player.transform.Translate(Vector3.forward * Time.deltaTime * (playerSpeed / speedFactor));
        }

        if (Input.GetKey("d"))
        {
            player.transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            player.transform.Translate(Vector3.forward * Time.deltaTime * (playerSpeed / speedFactor));
        }
    }
}
