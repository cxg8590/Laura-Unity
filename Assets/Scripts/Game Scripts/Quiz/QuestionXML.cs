using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class QuestionXML : MonoBehaviour {

    public List<Question> questions = new List<Question>();

    string question;
    string choice1;
    string choice2;
    string choice3;
    string choice4;
    int answer;

    // Use this for initialization
    void Start () {
        GetQuestions();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*public QuestionXML() {
        GetQuestions();
    }*/


    public void GetQuestions()
    {
        XmlDocument xmlDoc = new XmlDocument();
        TextAsset textAsset = (TextAsset)Resources.Load("Questions1", typeof(TextAsset));
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList questList = xmlDoc.GetElementsByTagName("question");
        foreach(XmlNode quest in questList)
        {
            question = quest.Attributes["quest"].Value;
            
            answer = XmlConvert.ToInt32(quest.Attributes["ans"].Value);
            XmlNodeList choices = quest.ChildNodes;
            foreach(XmlNode choice in choices)
            {
                int num = XmlConvert.ToInt32(choice.Attributes["num"].Value);
                if (num == 1)
                {
                    choice1 = choice.InnerText;
                }
                if (num == 2)
                {
                    choice2 = choice.InnerText;
                }
                if (num == 3)
                {
                    choice3 = choice.InnerText;
                }
                if (num == 4)
                {
                    choice4 = choice.InnerText;
                }
            }

            questions.Add(new Question(question, choice1, choice2, choice3, choice4, answer));
        }
    }
}
