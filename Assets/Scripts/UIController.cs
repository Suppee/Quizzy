using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    public GameObject UIDocument;
    public string textField;
    public Question questionRef;

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
        Debug.Log(textField);
        root.Q<TextField>("AnswerUI").value = "";
    }
}