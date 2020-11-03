using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    GameObject rightEye;
    GameObject leftEye;
    float timer;
    public float timerMax;
    bool blinked;

    // Start is called before the first frame update
    void Start()
    {
        rightEye = transform.GetChild(0).gameObject;
        leftEye = transform.GetChild(1).gameObject;
        timer = 0.0f;
        blinked = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timerMax && !blinked)
        {
            rightEye.transform.localScale = new Vector3(1.0f, 0.0f, 1.0f);
            leftEye.transform.localScale = new Vector3(1.0f, 0.0f, 1.0f);
            blinked = true;
            timer = 0.0f;
        }
        else if((timer > (timerMax-(timerMax-1))) && blinked)
        {
            rightEye.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            leftEye.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            blinked = false;
            timer = 0.0f;
        }
    }
}
