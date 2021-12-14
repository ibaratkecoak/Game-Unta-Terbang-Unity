using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton;

    public AudioClip[] SoundFx;



    AudioSource audioSource;



    private void Awake()
    {


        if (singleton == null)
        {
            singleton = this;

        }

        else
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

    }

    public void PlaySoundFX(int clipIndex)
    {
        audioSource.PlayOneShot(SoundFx[clipIndex]);

    }



}
