using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAndBackgroundColor : MonoBehaviour
{
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Color randomColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", randomColor);
        Camera.backgroundColor = randomColor;
    }
}
