using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool activated, done;
    public float lerpSpeed;
    public GameObject leverHandle;
    private float t = 0.0f;

    void Start()
    {
        if (!activated)
        {
            leverHandle.transform.localRotation = Quaternion.Euler(-45.0f, 0.0f, 0.0f);
        }
        else
        {
            leverHandle.transform.localRotation = Quaternion.Euler(45.0f, 0.0f, 0.0f);
        }
    }

    void Update()
    {
        if(activated && !done)
        {
            leverHandle.transform.localRotation = Quaternion.Euler((Mathf.Lerp(-45.0f, 45.0f, t)), 0.0f, 0.0f); 
            t += lerpSpeed * Time.deltaTime;
            if (t > 1.0f)
            {
                t = 0.0f;
                leverHandle.transform.localRotation = Quaternion.Euler(45.0f, 0.0f, 0.0f);
                done = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arrow")
        {
            if (!(activated))
            {
                activated = true;
            }
        }
    }

    public bool getActivated()
    {
        return activated;
    }
}
