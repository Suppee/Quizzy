using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public int disableTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Color randomColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", randomColor);
        //Debug.Log(randomColor);
        //Disables Grivity after given amount of seconds
        Invoke("disableGravity", disableTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void disableGravity()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
