using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour
{
    public bool village, firstSong, hasEntered, canStart, lower;
    public AudioSource audioSource;
    public SphereCollider deleteSphere;
    public List<AudioClip> audioClips;
    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        volume = audioSource.volume;
        print(volume);
        if (village)
        {
            hasEntered = true;
            firstSong = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(firstSong && !audioSource.isPlaying && !lower)
        {
            audioSource.PlayOneShot(audioClips[1]);
            audioSource.loop = true;
        }
        if (!firstSong && !audioSource.isPlaying && lower)
        {
            audioSource.PlayOneShot(audioClips[3]);
            audioSource.loop = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasEntered)
        {
            lower = false;
            if (audioSource.isPlaying)
            {
                LowerAudio(audioSource);
            }

            if (!firstSong)
            {
                hasEntered = true;
                audioSource.PlayOneShot(audioClips[0]);
                firstSong = true;
            }
        }
        else
        {
            if(deleteSphere.gameObject.activeSelf && village)
            {
                deleteSphere.gameObject.GetComponent<SphereCollider>().enabled = false;
            }

            if (audioSource.isPlaying)
            {
                LowerAudio(audioSource);
            }

            if (firstSong)
            {
                hasEntered = false;
                audioSource.PlayOneShot(audioClips[2]);
                firstSong = false;
                lower = true;
            }
        }
    }

    void LowerAudio(AudioSource audioSource)
    {
        audioSource.Stop();
        audioSource.loop = false;
    }
}
