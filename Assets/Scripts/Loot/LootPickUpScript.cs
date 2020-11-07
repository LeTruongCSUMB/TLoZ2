using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickUpScript : MonoBehaviour
{
    public bool isLupee;
    public bool isArrow;
    public bool isKey;

    public List<AudioClip> audioClips;

    public int quanitity;
    public float timerMax;

    private float timer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isKey)
        {
            timer += Time.deltaTime;

            if (timer > timerMax)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                timerMax = timerMax / 2;
                timer = 0.0f;
            }

            if (!transform.GetChild(0).gameObject.activeSelf && timer > timerMax / 2)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }

            if (timerMax < 0.05)
            {
                Destroy(transform.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            if (isLupee)
            {
                other.gameObject.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
                if (PlayerController.lupeeCount < PlayerController.maxLupeeCount)
                {
                    if (PlayerController.lupeeCount + quanitity <= PlayerController.maxLupeeCount)
                    {
                        PlayerController.lupeeCount += quanitity;
                    }
                    else
                    {
                        PlayerController.lupeeCount = PlayerController.maxLupeeCount;
                    }
                    Destroy(transform.gameObject);
                    PlayerHUD.UpdatePlayerHUD();
                }
            }

            if(isKey)
            {
                other.gameObject.GetComponent<AudioSource>().PlayOneShot(audioClips[1]);
                if (PlayerController.numOfKeys < PlayerController.maxKeyCount)
                {
                    if (PlayerController.numOfKeys + quanitity <= PlayerController.maxKeyCount)
                    {
                        PlayerController.numOfKeys += quanitity;
                    }
                    else
                    {
                        PlayerController.numOfKeys = PlayerController.maxKeyCount;
                    }
                    Destroy(transform.gameObject);
                    PlayerHUD.UpdatePlayerHUD();
                }
            }
        }

        if (other.gameObject.GetComponent<PlayerTools>() != null)
        {
            GameObject player = other.gameObject;
            if (isArrow)
            {
                other.gameObject.GetComponent<AudioSource>().PlayOneShot(audioClips[2]);
                if (PlayerTools.arrowCount < PlayerTools.maxArrowCount)
                {
                    if (PlayerTools.arrowCount + quanitity <= PlayerTools.maxArrowCount)
                    {
                        PlayerTools.arrowCount += quanitity;
                    }
                    else
                    {
                        PlayerTools.arrowCount = PlayerTools.maxArrowCount;
                    }
                    Destroy(transform.gameObject);
                    PlayerHUD.UpdatePlayerHUD();
                }
            }
        }
    }
}
