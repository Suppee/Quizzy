using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StackSpawner : MonoBehaviour
{

    public GameObject StackCube;
    public GameObject Camera;
    public Transform StackSpawnTransform;
    public bool spawnStack = false;
    public float spawnAmount;
    private VisualElement root;
    int points = 1;


    // Start is called before the first frame update
    void Start()
    {
        GameObject UIDocument = GameObject.Find("UIDocument");
        root = UIDocument.GetComponent<UIDocument>().rootVisualElement;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnStack == true)
        {
            
            Camera.transform.position += new Vector3(0, StackCube.transform.localScale.y * Time.deltaTime, 0);
        }
        
    }

    public IEnumerator StackLoop()
    {        
        spawnStack = true;       
        for (int i = 0; i < spawnAmount; i++)
        {
            yield return new WaitForSeconds(1);            
            root.Q<Label>("Points").text = "Score: " + points++;
            Debug.Log("spawnamount: "+spawnAmount);
            Instantiate(StackCube, StackSpawnTransform.position, StackSpawnTransform.rotation);
            transform.position += new Vector3(0, StackCube.transform.localScale.y, 0);
        }       
        spawnStack = false;
        spawnAmount = 0;
    }
}
