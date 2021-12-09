using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuizRound : MonoBehaviour
{
    public AudioSource CountDown;
    public AudioSource Buzzer;

    private void Start()
    {
        Invoke("StartQuestion",0);
    }

    public void StartQuestion()
    {
        // Chooses a random question after time is over
        GameManager.Instance.questionRef = GameManager.Instance.quizRef.questions[Random.Range(0, GameManager.Instance.quizRef.questions.Length)];

        // Set question field text to the new question
        GameManager.Instance.rootUIElement.Q<Label>("Question").text = GameManager.Instance.questionRef.question;

        // Start countdown Coroutine
        StartCoroutine(CountdownTimer());
    }

    public IEnumerator CountdownTimer()
    {
        // Set time counter to questions preset time
        int counter = GameManager.Instance.questionRef.seconds;
        // Loop as long as time is not below 0
        while (counter > 0)
        {
            // Wait one second
            yield return new WaitForSeconds(1);

            // Remove one from counter
            counter--;

            // Show counter number in the Time UI element
            GameManager.Instance.rootUIElement.Q<Label>("Time").text = "Time: " + counter.ToString();

            if (counter == 5)
            {
                Buzzer.PlayOneShot(Resources.Load<AudioClip>("Sound effects/Count Down"));
            }
            if (counter == 0)
            {
                Buzzer.PlayOneShot(Resources.Load<AudioClip>("Sound effects/Buzzer"));
            }
        }

        yield return new WaitForSeconds(3);

        // Start the function StartQuestion
        StartQuestion();
    }
}
