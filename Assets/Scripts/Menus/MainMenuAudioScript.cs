using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioScript : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public GameObject quadForce;
    private bool first;
    // Start is called before the first frame update
    void Start()
    {
        first = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (quadForce.activeSelf && !transform.GetComponent<AudioSource>().isPlaying && !first)
        {
            transform.GetComponent<AudioSource>().PlayOneShot(audioClips[0]);
            first = true;
        }
    }
}
