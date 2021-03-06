using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "NewQuestion", menuName = "Question")]
public class QuestionObject : ScriptableObject
{
    [TextArea(10, 100)]
    public string question;
    public string[] answers;
    public int seconds;
}
