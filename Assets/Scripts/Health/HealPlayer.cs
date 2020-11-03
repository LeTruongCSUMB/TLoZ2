using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isBed;
    public int healthQuantity;

    private bool healing;
    private float timer = 0.0f;
    private float timerMax = 2.0f;

    void Start()
    {
        healing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (healing)
        {
            timer += Time.deltaTime;

            if (timer > timerMax)
            {
                PlayerController.playerHealth++;
                PlayerHUD.UpdatePlayerHUD();
                healing = false;
                timer = 0.0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isBed)
        {
            if (other.GetComponent<PlayerController>() != null)
            {
                if (PlayerController.playerHealth < 6)
                {
                    if((PlayerController.playerHealth += healthQuantity) <= 6)
                    {
                        PlayerController.playerHealth += healthQuantity;
                    }
                    else
                    {
                        PlayerController.playerHealth = 6;
                    }
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isBed)
        {
            if (other.GetComponent<PlayerController>() != null)
            {
                if (PlayerController.playerHealth < 6)
                {
                    healing = true;
                }
                else
                {
                    healing = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        healing = false;
    }
}
