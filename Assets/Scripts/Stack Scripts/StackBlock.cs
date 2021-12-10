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
    private Vector3 scaleChange;


    private void Awake()
    {
        scaleChange = new Vector3(0.1f, 0f, 0.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        //sets scale to 0.1
        transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);

        // Set blocks color to a random color
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)));

        // Loads all block clicking sounds
        blockClickSounds = Resources.LoadAll<AudioClip>("Sound effects/BlockClickSounds");

        // Set audioOutputSource to Audio Source component on block Prefab
        audioOutputSource = gameObject.GetComponent<AudioSource>();

        // Disables Grivity after given amount of seconds
        Invoke("disableGravity", disableTime);

        //Starts Scale() coroutine
        StartCoroutine(Scaler());

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

    public IEnumerator Scaler()
    {
        //scales the blocks to the right size
        for (int i = 0; i <= 38; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale += scaleChange;
        }
        //forces the blocks to be the right size
        transform.localScale = new Vector3(4f, 0.5f, 4f);
    }
}