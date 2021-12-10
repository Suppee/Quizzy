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
    //Array of colors
    private Color32[] colors = {new Color32(46, 52, 130, 255), new Color32(0, 100, 144, 255), new Color32(0, 162, 211, 255), new Color32(94, 202, 240, 255), new Color32(0, 178, 190, 255), new Color32(222, 25, 117, 255), new Color32(255, 32, 125, 255), new Color32(250, 77, 167, 255), new Color32(226, 0, 66, 255), new Color32(255, 32, 123, 255), new Color32(254, 70, 58, 255), new Color32(249, 78, 0, 255), new Color32(254, 85, 82, 255), new Color32(253, 121, 96, 255), new Color32(255, 102, 0, 255), new Color32(255, 219, 0, 255), new Color32(253, 229, 0, 255), new Color32(252, 212, 37, 255), new Color32(151, 248, 73, 255), new Color32(255, 252, 1, 255), new Color32(0, 159, 121, 255), new Color32(13, 177, 179, 255), new Color32(0, 207, 213, 255), new Color32(199, 246, 90, 255)};


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
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", colors[Random.Range(0, colors.Length)]);

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