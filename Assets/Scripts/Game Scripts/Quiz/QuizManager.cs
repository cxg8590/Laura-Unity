using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour {

    List<Question> questions = new List<Question>();
    QuestionXML xml;

    //ui
    public Text questBox;     //place where question goes
    public Button[] choices;    //choices

    public GameObject Progress;

    public GameObject good;
    public GameObject wrong;

    int answer; //what question number is correct;

    int numQuests; //number of questions
    int curQuestion; // number of current question
    int correct; //did they answer correctly (0 = no answer; 1 = correct; 2 = incorrect)

	// Use this for initialization
	void Start () {
        xml = new QuestionXML();
        xml.GetQuestions();
        questions = xml.questions;
        numQuests = questions.Count;
        correct = 0;
        int nextQ = Random.Range(0, numQuests);
        loadQuestion(nextQ);
	}
	
	// Update is called once per frame
	void Update () {
	    if(correct == 1)
        {
            Progress.GetComponent<progressBar>().addAmount(1f/5f);
            Instantiate(good, new Vector3(0, 0, 0), Quaternion.identity);
            if (Progress.GetComponent<Image>().fillAmount == 1.0f)
            {
                //victory
                questBox.text = "You Win!";
            }
            else
            {
                curQuestion++;
                /* int nextQ = Random.Range(0, numQuests);
                 loadQuestion(nextQ);*/
                StartCoroutine(nextQuestion());
            }
        }
        if(correct == 2)
        {
            Instantiate(wrong, new Vector3(0, 0, 0), Quaternion.identity);
            Progress.GetComponent<progressBar>().addAmount(-1f / 5f);
            questBox.text = "Wrong";
            /*int nextQ = Random.Range(0, numQuests);
            loadQuestion(nextQ);*/
            StartCoroutine(nextQuestion());
        }
	}
    IEnumerator nextQuestion()
    {
        yield return new WaitForSeconds(0.25f);
        int nextQ = Random.Range(0, numQuests);
        loadQuestion(nextQ);
    }

    void loadQuestion(int qNum)
    {
        correct = 0;
        questBox.text = questions[qNum].question;
        for(int i = 0; i < 4; i++)
        {
            choices[i].GetComponentInChildren<Text>().text = questions[qNum].choices[i];
        }
        answer = questions[qNum].answer;
    }

    public void button(int bNum)
    {
        if(bNum == answer)
        {
            correct = 1;
        }
        else
        {
            correct = 2;
        }
    }
}
