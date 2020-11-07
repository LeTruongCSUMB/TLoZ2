using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoScript : MonoBehaviour
{
    public RawImage logo;
    public GameObject quadForce, title, mainMenu, sword;
    public bool hasAppeared, stop;
    private float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        quadForce.SetActive(false);
        title.SetActive(false);
        mainMenu.SetActive(false);
        sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(mainMenu.activeSelf)
        {
            transform.gameObject.SetActive(false);
        }

        if (!stop)
        {
            if (!hasAppeared)
            {
                Color c = logo.color;
                c.a = logo.color.a + 0.0025f;
                logo.color = c;

                if (c.a >= 1.0f)
                {
                    hasAppeared = true;
                }
            }
            else
            {
                t += 0.95f * Time.deltaTime;
                if (t > 1.0f)
                {
                    Color c = logo.color;
                    c.a = logo.color.a - 0.0025f;
                    logo.color = c;
                    if (c.a <= 0.0f)
                    {
                        t = 0.0f;
                        stop = true;
                        
                    }
                }
            }
        }
        else if (stop)
        {
            quadForce.SetActive(true);
            if (quadForce.GetComponent<IntroScript>().rot0 && quadForce.GetComponent<IntroScript>().rot1 
                && quadForce.GetComponent<IntroScript>().rot2 && quadForce.GetComponent<IntroScript>().rot3)
            {
                title.SetActive(true);
                sword.SetActive(true);
                t += 0.95f * Time.deltaTime;
                title.transform.localPosition = new Vector3(0.0f, Mathf.Lerp(-255f, 20.0f, t), 0.0f);
                if (t > 1.0f)
                {
                    title.transform.localPosition = new Vector3(0.0f, 20.0f, 0.0f);
                    mainMenu.SetActive(true);
                }
            }
        }
    }
}
