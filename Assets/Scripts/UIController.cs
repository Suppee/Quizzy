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
    int points = 0;

    // Start is called before the first frame update
    public void Start()
    {
        var root = UIDocument.GetComponent<UIDocument>().rootVisualElement;
        root.Q<Label>("Question").text = questionRef.question;
    }

    public void OnEnter()
    {
        var root = UIDocument.GetComponent<UIDocument>().rootVisualElement;
        textField = root.Q<TextField>("AnswerUI").value;        
        root.Q<TextField>("AnswerUI").value = "";
        for(int i = 0; i < questionRef.answers.Length; i++)
        {
            if (textField == questionRef.answers[i])
            {
                points = points + questionRef.answers[i].Length;
                root.Q<Label>("Points").text = points.ToString();
            }
                

        }
        
    }
}