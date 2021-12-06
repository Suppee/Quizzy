using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "NewQuiz", menuName = "Quiz")]
public class Quiz : ScriptableObject
{
    public Question[] questions;
}
