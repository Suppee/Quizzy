using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StackSpawner : MonoBehaviour
{
    // Variables
    GameObject stackBlock;
    public bool spawnStack = false;
    public float spawnAmount;

    private void Start()
    {
        stackBlock = Resources.Load<GameObject>("Prefabs/StackCube");
    }

    // Update is called once per frame
    void Update()
    {
        // Move camera if spawning stacks
        if (spawnStack == true)
        {
            GameManager.Instance.Camera.transform.position += new Vector3(0, stackBlock.transform.localScale.y * Time.deltaTime, 0);
        }        
    }

    // Spawn block co-routine
    public IEnumerator StackLoop()
    {        
        spawnStack = true;    
        //runs for as many times as the amount of points earned
        for (int i = 0; i < spawnAmount; i++)
        {
            //waits for 1 second
            yield return new WaitForSeconds(1); 
            //creates a new block
            Instantiate(stackBlock, transform.position, transform.rotation);
            transform.position += new Vector3(0, stackBlock.transform.localScale.y, 0);

            //Adds points to the player and UI
            GameManager.Instance.points++;
            GameManager.Instance.rootUIElement.Q<Label>("Points").text = "Score: " + GameManager.Instance.points;
        }    
        // Resets variables when finished
        spawnStack = false;
        spawnAmount = 0;
    }
}
