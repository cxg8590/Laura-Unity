using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class DialogueXML : MonoBehaviour {

    string[] text;
    string resource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GetDialogue()
    {
        XmlDocument xmlDoc = new XmlDocument();
        TextAsset textAsset = (TextAsset)Resources.Load(resource, typeof(TextAsset));
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList questList = xmlDoc.GetElementsByTagName("character");
       /* foreach (XmlNode quest in questList)
        {
            question = quest.Attributes["quest"].Value;

            answer = XmlConvert.ToInt32(quest.Attributes["ans"].Value);
            XmlNodeList choices = quest.ChildNodes;
            foreach (XmlNode choice in choices)
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
        }*/
    }
}
