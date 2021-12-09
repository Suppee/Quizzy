using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    // This sets up the game manager to be accessible by other scripts
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is Null!!!");

            return _instance;
        }
    }    

    // Camera Reference
    public Camera Camera;

    // UI References
    public UIDocument UIDocument;    
    public VisualElement rootUIElement;

    [HideInInspector]
    public int points;
    [HideInInspector]
    public int bonusPoints;

    public GameObject floor;

    [HideInInspector]
    public QuestionObject questionRef;
    public QuizObject quizRef;

    // Wakey Wakey
    private void Awake()
    {
        // Set Game manager instance
        _instance = this;

        // Set root to UIDocumentation, neccessary to access the UI elements
        rootUIElement = UIDocument.rootVisualElement;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Sets color on camera background and floor 
        Color randomColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        floor.gameObject.GetComponent<Renderer>().material.SetColor("_Color", randomColor);
        Camera.backgroundColor = randomColor;        
    }
}
