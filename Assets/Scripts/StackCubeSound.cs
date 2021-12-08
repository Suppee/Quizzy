using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCubeSound : MonoBehaviour
{
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    private bool playSound = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (playSound == true)
        {
            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
            randomSound.Play();
            Debug.Log("Hello");
            playSound = false;
        }
    }

}
