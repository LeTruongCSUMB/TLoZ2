using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    // Start is called before the first frame update
    public static Text LupeeText;
    public static Text ArrowText;
    public static Text KeyText;
    public static GameObject lifeHearts;

    void Start()
    {
        LupeeText = GameObject.Find("Lupee Count Text").GetComponent<Text>();
        ArrowText = GameObject.Find("Arrow Count Text").GetComponent<Text>();
        KeyText = GameObject.Find("Key Count Text").GetComponent<Text>();
        lifeHearts = GameObject.Find("Life Camera");
        UpdatePlayerHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdatePlayerHUD()
    {
        LupeeText.text = PlayerController.lupeeCount.ToString();
        ArrowText.text = PlayerTools.arrowCount.ToString();
        KeyText.text = PlayerController.numOfKeys.ToString();
        
        switch(PlayerController.playerHealth)
        {
            case 6:
                ChildLoop(lifeHearts);
                lifeHearts.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 5:
                ChildLoop(lifeHearts);
                lifeHearts.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 4:
                ChildLoop(lifeHearts);
                lifeHearts.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                ChildLoop(lifeHearts);
                lifeHearts.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 2:
                ChildLoop(lifeHearts);
                lifeHearts.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 1:
                ChildLoop(lifeHearts);
                lifeHearts.transform.GetChild(5).gameObject.SetActive(true);
                break;
            case 0:
                ChildLoop(lifeHearts);
                lifeHearts.transform.GetChild(6).gameObject.SetActive(true);
                print("Player has died");
                break;
        }
    }

    public static void ChildLoop(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.activeInHierarchy == true)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
