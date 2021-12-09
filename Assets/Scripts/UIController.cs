using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    private string inputField;
    public StackSpawner StackSpawner;
    private TouchScreenKeyboard keyboard;
    public bool cooldown = true;

    // Start is called before the first frame update
    public void Start()
    {
        // Set touchscreen keyboard reference
        keyboard = TouchScreenKeyboard.Open("");
    }
    public void FixedUpdate()
    {
        if (TouchScreenKeyboard.visible && cooldown == true && TouchScreenKeyboard.isSupported)
        {
            keyboard = TouchScreenKeyboard.Open("");
            cooldown = false;
        }

        if (keyboard.status == TouchScreenKeyboard.Status.Done && keyboard != null && TouchScreenKeyboard.isSupported)
        {
            OnEnter();
            keyboard = TouchScreenKeyboard.Open("");
        }
    }

    public void OnEnter()
    {
        // Stores the inputField string as a variable
        inputField = GameManager.Instance.rootUIElement.Q<TextField>("AnswerUI").value;

        // Clears inputField after enter
        GameManager.Instance.rootUIElement.Q<TextField>("AnswerUI").value = "";

        //loops for each possible answer from the question ref.
        for (int i = 0; i < GameManager.Instance.questionRef.answers.Length; i++)            
        {
            //Check if the inputField answer equals the answer at index I, if true score points
            if (inputField.ToLower() == GameManager.Instance.questionRef.answers[i].ToLower())
            {
                //Activates stackSpawner
                StackSpawner.spawnAmount += GameManager.Instance.questionRef.answers[i].Length;
                inputField = null;
                if (StackSpawner.spawnStack == false)
                    StackSpawner.StartCoroutine(StackSpawner.StackLoop());

                // Give a bonus point if spelled correctly and with upper case
                //if (inputField == GameManager.Instance.questionRef.answers[i])
                    //GameManager.Instance.rootUIElement.Q<Label>("BonusPoint").
            }
        }
    }
}