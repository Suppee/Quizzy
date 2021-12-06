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
    int points = 0;
    private VisualElement root;

    // Start is called before the first frame update
    public void Start()
    {
        root = UIDocument.GetComponent<UIDocument>().rootVisualElement;
        StartQuestion();        
    }

    public void OnEnter()
    {        
        textField = root.Q<TextField>("AnswerUI").value;        
        root.Q<TextField>("AnswerUI").value = "";
        for(int i = 0; i < questionRef.answers.Length; i++)
        {
            if (textField == questionRef.answers[i])
            {
                points = points + questionRef.answers[i].Length;
                root.Q<Label>("Points").text = "Score: " + points.ToString();
            }
        }        
    }

    public void StartQuestion()
    {
        root.Q<Label>("Question").text = questionRef.question;
        StartCoroutine(Countdown());
    }  

    public IEnumerator Countdown()
    {
        int counter = questionRef.seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            root.Q<Label>("Time").text = "Time: " + counter.ToString(); 
        }
        //Chooses a random question after time is over
        questionRef = quizRef[Random.Range(0, quizRef.Length)];
        StartQuestion();
    }
}