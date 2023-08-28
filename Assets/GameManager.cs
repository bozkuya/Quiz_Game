using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unanswered;
    private Question currentQuestion;

    [SerializeField]
    private Text questionText;
    [SerializeField]
    private float TimeBetweenQuestions = 1f;
    [SerializeField]
    private GameObject truePanel; // Add this line for the panel
    [SerializeField]
    private GameObject falsePanel; // Add this line for the panel

    void Start()
    {
        if (unanswered == null || unanswered.Count == 0)
        {
            unanswered = questions.ToList();
        }

        GetRandomQuestion();
        truePanel.SetActive(false); // Start with the panel hidden
        falsePanel.SetActive(false);
    }

    void GetRandomQuestion()
    {
        int RandomIndex = Random.Range(0, unanswered.Count);
        currentQuestion = unanswered[RandomIndex];
        questionText.text = currentQuestion.question;
    }

    IEnumerator TransitionToNextQuestion()
    {
        unanswered.Remove(currentQuestion);
        yield return new WaitForSeconds(TimeBetweenQuestions);
        truePanel.SetActive(false); // Hide the panel before the next question
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectA()
    {
        if (currentQuestion.answer == 0)
        {
            Debug.Log("CORRECT!");
            truePanel.SetActive(true); // Show the panel
        }
        else
        {
            Debug.Log("WRONG!");
            falsePanel.SetActive(true);
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectB()
    {
        if (currentQuestion.answer == 1)
        {
            Debug.Log("CORRECT!");
            truePanel.SetActive(true); // Show the panel
        }
        else
        {
            Debug.Log("WRONG!");
            falsePanel.SetActive(true);
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}
