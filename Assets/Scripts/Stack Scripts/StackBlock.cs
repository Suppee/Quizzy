using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBlock : MonoBehaviour
{
    //Gravity Variales
    public int disableTime = 5;

    // Audio Variables
    AudioClip[] blockClickSounds;
    AudioSource audioOutputSource;    
    private bool playSound = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set blocks color to a random color
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)));

        // Loads all block clicking sounds
        blockClickSounds = Resources.LoadAll<AudioClip>("Sound effects/BlockClickSounds");

        // Set audioOutputSource to Audio Source component on block Prefab
        audioOutputSource = gameObject.GetComponent<AudioSource>();

        // Disables Grivity after given amount of seconds
        Invoke("disableGravity", disableTime);
    }

    void disableGravity()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (playSound == true)
        {
            audioOutputSource.PlayOneShot(blockClickSounds[Random.Range(0, blockClickSounds.Length)]);
            playSound = false;
        }
    }
}