using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public List<GameObject> cubes;
    public float speed;
    public float lerpSpeed;
    private float t0, t1, t2, t3;
    public bool rot0, rot1, rot2, rot3;
    // Start is called before the first frame update
    void Start()
    {
        t0 = 0.0f;
        t1 = 0.0f;
        t2 = 0.0f;
        t3 = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCubes();

        if (!rot0)
        {
            cubes[0].transform.localPosition = new Vector3(Mathf.Lerp(-9f, -0.75f, t0), Mathf.Lerp(9f, 0.75f, t0), 0.0f);
            t0 += lerpSpeed * Time.deltaTime;
            if (t0 > 1.0f)
            {
                t0 = 0.0f;
                cubes[0].transform.localPosition = new Vector3(-0.75f, 0.75f, 0.0f);
                rot0 = true;
            }
        }

        if (!rot1)
        {
            cubes[1].transform.localPosition = new Vector3(Mathf.Lerp(9f, 0.75f, t1), Mathf.Lerp(9f, 0.75f, t1), 0.0f);
            t1 += lerpSpeed * Time.deltaTime;
            if (t1 > 1.0f)
            {
                t1 = 0.0f;
                cubes[1].transform.localPosition = new Vector3(0.75f, 0.75f, 0.0f);
                rot1 = true;
            }
        }

        if (!rot2)
        {
            cubes[2].transform.localPosition = new Vector3(Mathf.Lerp(-9f, -0.75f, t2), Mathf.Lerp(-9f, -0.75f, t2), 0.0f);
            t2 += lerpSpeed * Time.deltaTime;
            if (t2 > 1.0f)
            {
                t2 = 0.0f;
                cubes[2].transform.localPosition = new Vector3(-0.75f, -0.75f, 0.0f);
                rot2 = true;
            }
        }

        if (!rot3)
        {
            cubes[3].transform.localPosition = new Vector3(Mathf.Lerp(9f, 0.75f, t3), Mathf.Lerp(-9f, -0.75f, t3), 0.0f);
            t3 += lerpSpeed * Time.deltaTime;
            if (t3 > 1.0f)
            {
                t3 = 0.0f;
                cubes[3].transform.localPosition = new Vector3(0.75f, -0.75f, 0.0f);
                rot3 = true;
            }
        }

    }

    void RotateCubes()
    {
        if (!rot0)
        {
            cubes[0].transform.Rotate(-Vector3.up, speed * Time.deltaTime);
            cubes[0].transform.Rotate(-Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            cubes[0].transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        if (!rot1)
        {
            cubes[1].transform.Rotate(Vector3.up, speed * Time.deltaTime);
            cubes[1].transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            cubes[1].transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        if (!rot2)
        {
            cubes[2].transform.Rotate(-Vector3.up, speed * Time.deltaTime);
            cubes[2].transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            cubes[2].transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        if (!rot3)
        {
            cubes[3].transform.Rotate(Vector3.up, speed * Time.deltaTime);
            cubes[3].transform.Rotate(-Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            cubes[3].transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
