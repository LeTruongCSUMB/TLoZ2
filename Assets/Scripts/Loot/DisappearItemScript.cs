using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearItemScript : MonoBehaviour
{
    public float timerMax = 6.0f;
    private float timer;

    // Update is called once per frame
    void FixedUpdate()
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
