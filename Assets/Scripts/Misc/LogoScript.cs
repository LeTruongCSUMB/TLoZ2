using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoScript : MonoBehaviour
{
    public RawImage logo;
    public bool hasAppeared, stop;
    private float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                print(t);
                if (t > 1.0f)
                {
                    Color c = logo.color;
                    c.a = logo.color.a - 0.0025f;
                    logo.color = c;
                    if (c.a <= 0.0f)
                    {
                        print("Stopping");
                        stop = true;
                    }
                }
            }
        }
    }
}
