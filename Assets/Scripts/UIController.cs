using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    public GameObject UIDocument;
    private string textField;
    public Question questionRef;
    public Question[] quizRef;   
    private VisualElement root;
    public StackSpawner StackSpawner;
    private TouchScreenKeyboard keyboard;
    public bool cooldown;
    public AudioSource CountDown;
    public AudioSource Buzzer;

    // Start is called before the first frame update
    public void Start()
    {
        cooldown = true;
        //Set root to UIDocumentation, neccessary to access the UI elements
        root = UIDocument.GetComponent<UIDocument>().rootVisualElement;

        //Starts a question at the beginning of the game
        StartQuestion();
        keyboard = TouchScreenKeyboard.Open("");
    }
    public void FixedUpdate()
    {
        if (TouchScreenKeyboard.visible && cooldown == true && TouchScreenKeyboard.isSupported)
        {
            //keyboard = TouchScreenKeyboard.Open("");
            cooldown = false;
        }

        if (keyboard.status == TouchScreenKeyboard.Status.Done && keyboard != null && TouchScreenKeyboard.isSupported)
        {

            OnEnter();
            Debug.Log("hej");
            //keyboard = TouchScreenKeyboard.Open("");
        }
    }

    public void OnEnter()
    {        
        // Stores the textfield string as a variable
        textField = root.Q<TextField>("AnswerUI").value;  

        // Clears textfield after enter
        root.Q<TextField>("AnswerUI").value = "";

        // loops for each possible answer from the question ref.
        for(int i = 0; i < questionRef.answers.Length; i++)
        {
            //Check if the textfield answer equals the answer at index I
            if (textField == questionRef.answers[i])
            {
                Debug.Log(questionRef.answers[i].Length);
                //Activates stackSpawner
                StackSpawner.spawnAmount += questionRef.answers[i].Length;
                textField = null;
                if (StackSpawner.spawnStack == false)
                {
                    StackSpawner.StartCoroutine(StackSpawner.StackLoop());
                }              
            }
        }        
    }

    public void StartQuestion()
    {
        // Set question field text to the new question
        root.Q<Label>("Question").text = questionRef.question;

        // Start countdown Coroutine
        StartCoroutine(CountdownTimer());
    }  

    public IEnumerator CountdownTimer()
    {
        // Set time counter to questions preset time
        int counter = questionRef.seconds;
        // Loop as long as time is not below 0
        while (counter > 0)
        {
            // Wait one second
            yield return new WaitForSeconds(1);

            // Remove one from counter
            counter--;

            //Show counter number in the Time UI element
            root.Q<Label>("Time").text = "Time: " + counter.ToString(); 

            if (counter == 5)
            {
                CountDown.Play();
            }
            if (counter == 0)
            {
                Buzzer.Play();
            }
        }
        //Chooses a random question after time is over
        questionRef = quizRef[Random.Range(0, quizRef.Length)];
        
        // Start the function StartQuestion
        StartQuestion();
    }
}