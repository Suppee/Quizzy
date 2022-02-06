using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    //Array of colors
    private Color32[] colors = { new Color32(46, 52, 130, 255), new Color32(0, 100, 144, 255), new Color32(0, 162, 211, 255), new Color32(94, 202, 240, 255), new Color32(0, 178, 190, 255), new Color32(222, 25, 117, 255), new Color32(255, 32, 125, 255), new Color32(250, 77, 167, 255), new Color32(226, 0, 66, 255), new Color32(255, 32, 123, 255), new Color32(254, 70, 58, 255), new Color32(249, 78, 0, 255), new Color32(254, 85, 82, 255), new Color32(253, 121, 96, 255), new Color32(255, 102, 0, 255), new Color32(255, 219, 0, 255), new Color32(253, 229, 0, 255), new Color32(252, 212, 37, 255), new Color32(151, 248, 73, 255), new Color32(255, 252, 1, 255), new Color32(0, 159, 121, 255), new Color32(13, 177, 179, 255), new Color32(0, 207, 213, 255), new Color32(199, 246, 90, 255) };


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
    public VisualTreeAsset quizUI;
    public VisualTreeAsset menuUI;

    [HideInInspector]
    public int points;
    [HideInInspector]
    public int bonusPoints;

    public GameObject floor;

    //[HideInInspector]
    public QuestionObject questionRef;
    public QuizObject quizRef;
    public bool quizStarted;

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
        UIDocument.visualTreeAsset = menuUI;
        rootUIElement = UIDocument.rootVisualElement;
        Color newColor = colors[Random.Range(0, colors.Length)];
        // Sets color on camera background and floor 
        floor.gameObject.GetComponent<Renderer>().material.SetColor("_Color", newColor);
        Camera.backgroundColor = newColor;
        rootUIElement.Q<Button>("DanskQuiz").clicked += DanskQuiz;
        rootUIElement.Q<Button>("EngelskQuiz").clicked += EQuiz;
        rootUIElement.Q<Button>("FysikKemiQuiz").clicked += FkQuiz;
        rootUIElement.Q<Button>("MatematikQuiz").clicked += MQuiz;
        rootUIElement.Q<Button>("ExitButton").clicked += Application.Quit;
    }

    public void DanskQuiz()
    {
        quizRef = Resources.Load<QuizObject>("Quizzes/DanskQuiz");
        UIDocument.visualTreeAsset = quizUI;
        rootUIElement = UIDocument.rootVisualElement;
        gameObject.GetComponent<QuizRound>().enabled = true;
        quizStarted = true;
    }

    public void FkQuiz()
    {
        quizRef = Resources.Load<QuizObject>("Quizzes/FysikKemiQuiz");
        UIDocument.visualTreeAsset = quizUI;
        rootUIElement = UIDocument.rootVisualElement;
        gameObject.GetComponent<QuizRound>().enabled = true;
        quizStarted = true;
    }

    public void MQuiz()
    {
        quizRef = Resources.Load<QuizObject>("Quizzes/MatematikQuiz");
        UIDocument.visualTreeAsset = quizUI;
        rootUIElement = UIDocument.rootVisualElement;
        gameObject.GetComponent<QuizRound>().enabled = true;
        quizStarted = true;
    }

    public void EQuiz()
    {
        quizRef = Resources.Load<QuizObject>("Quizzes/EngelskQuiz");
        UIDocument.visualTreeAsset = quizUI;
        rootUIElement = UIDocument.rootVisualElement;
        gameObject.GetComponent<QuizRound>().enabled = true;
        quizStarted = true;
    }

    public void finishquiz()
    {
        Start();
    }
}
