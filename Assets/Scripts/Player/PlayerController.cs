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

    void Update()
    {
        //print("Player Health is " + playerHealth);

        if (Input.anyKey)
        {
            if (!PlayerTools.swinging)
            {
                MovePlayer();
            }
        }
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
