using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSounds : MonoBehaviour
{
    public AudioSource backgroundAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (backgroundAudio == null)
        {
            Debug.LogError("Background Audio Source is not assigned!");
        } else
        {
            backgroundAudio.Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
