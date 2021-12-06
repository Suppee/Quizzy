using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSpawner : MonoBehaviour
{

    public GameObject StackCube;
    public GameObject Camera;
    public Transform StackSpawnTransform;
    public bool spawnStack = false;
    public float spawnAmount;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Instantiate(StackCube, StackSpawnTransform.position, StackSpawnTransform.rotation);
            transform.position += new Vector3(0, StackCube.transform.localScale.y, 0);
        }
        spawnStack = false;
    }
}
