using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    public GameObject UIDocument;
    public Button startButton;
    public Button messageButton;
    public Label messageText;
    //public TextField textField;
    public string textField;

    // Start is called before the first frame update
    public void Start()
    {
        var root = UIDocument.GetComponent<UIDocument>().rootVisualElement;
        
        startButton = root.Q<Button>("start-button");
        messageButton = root.Q<Button>("message-button");
        messageText = root.Q<Label>("message-text");
        startButton.clicked += StartButtonPressed;
        messageButton.clicked += MessageButtonPressed;

    }

    public void Update()
    {
        var root = UIDocument.GetComponent<UIDocument>().rootVisualElement;
        textField = root.Q<TextField>("AnswerUI").value;
        Debug.Log(textField);
    }
    void StartButtonPressed()
    {
        SceneManager.LoadScene("game");
    }
    void MessageButtonPressed() {
       messageText.text = "Subscribe to Coco Code!";
       messageText.style.display = DisplayStyle.Flex;
}
}