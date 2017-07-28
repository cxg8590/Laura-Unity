using UnityEngine;
using System.Collections.Generic;

public class pressManager : MonoBehaviour {

    pressXML xml;
    pressText text;
    pressWords words;
    public GameObject stamp;
    public GameObject canvas;
    public GameObject blank;

    //List<string> answers;

    // Use this for initialization
    void Start()
    {
        xml = new pressXML(1);
        text = new pressText(xml.text, canvas, blank, xml.words);
        text.generate();
        words = new pressWords(xml.words, stamp, canvas, text.getBlanks());
        words.populate();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void populateAnswers()
    {
        
        //answers.
    }

    public void check()
    {
        GameObject[] stamps = words.getStamps();
        List<GameObject> answers = text.getBlanks();
        foreach(GameObject ans in answers)
        {
            if(ans.GetComponent<pressBlank>().checkWord() == false)
            {
                return;
            }
            /*for(int i = 0; i < stamps.Length; i++)
            {
                if(stamps[i].GetComponent<pressStamp>().getWord() == ans.GetComponent<pressBlank>().getAnswer())
                {
                    ans.GetComponent<pressBlank>().setCorrect(true);
                    Debug.Log("Correct");
                }
            }*/
        }
        Debug.Log("You Win!");
    }
}
