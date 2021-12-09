using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "NewQuiz", menuName = "Quiz")]
public class QuizObject : ScriptableObject
{
    public QuestionObject[] questions;
}
