using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class pressXML : MonoBehaviour {
    private int level;
    public string[] text;
    public string[] words;

    public pressXML(int lv)
    {
        level = lv;
        getTexts(level);
    }

    // Use this for initialization
    void Start () {
        //getTexts(level);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void getTexts(int lv)
    {
        XmlDocument xmlDoc = new XmlDocument();
        TextAsset textAsset = (TextAsset)Resources.Load("PressXML", typeof(TextAsset));
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList temp = xmlDoc.GetElementsByTagName("level");
        XmlNode tempLevel;
        XmlNodeList pressLevel;
        foreach (XmlNode lev in temp)
        {
            Debug.Log("XML level: "+XmlConvert.ToInt32(lev.Attributes["lv"].Value));
            if (lv == XmlConvert.ToInt32(lev.Attributes["lv"].Value))
            {
                tempLevel = lev;
                pressLevel = tempLevel.ChildNodes;
                text = pressLevel.Item(0).InnerText.Split(' ');
                
                words = pressLevel.Item(1).InnerText.Split(',');
            }
        }
        Debug.Log("1st word: " + words[0]);
    }
}
