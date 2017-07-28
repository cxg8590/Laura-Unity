using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class pressText : MonoBehaviour {

    private string[] pressTexts;
    private GameObject[] texts;
    private GameObject canvas;
    private GameObject blank;
    string[] words;
    private float row = 0;
    private float column = 0;
    private List<GameObject> blanks;
    private List<string> answers;
    private int blankNum = 0;

    public pressText(string[] text, GameObject cv, GameObject blnk, string[] ws)
    {
        pressTexts = text;
        canvas = cv;
        blank = blnk;
        words = ws;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void generate()
    {
        blanks = new List<GameObject>();
        answers = new List<string>();
        texts = new GameObject[pressTexts.Length];
        for (int i = 0; i < pressTexts.Length; i++)
        {
            char[] chars = pressTexts[i].ToCharArray();
            if (chars[0] == '*')
            {
                blankSpaces(chars[1] - '0');
            }
            else
            {
                texts[i] = new GameObject();
                texts[i].AddComponent<Text>().text = pressTexts[i];
                texts[i].GetComponent<Text>().color = Color.black;
                texts[i].GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                texts[i].GetComponent<RectTransform>().pivot = new Vector2(0, 1);
                texts[i].GetComponent<RectTransform>().pivot = new Vector2(0, 1);
                texts[i].transform.parent = canvas.transform;
                texts[i].AddComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                texts[i].GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                //texts[i].GetComponent<RectTransform>().con
                /*if (i != 0 && pressTexts[i-1].ToCharArray()[0] != '*')
                {
                    //RectTransform rt = (RectTransform)texts[i - 1].transform;
                    row += texts[i - 1].GetComponent<Text>().preferredWidth + 5;
                    //Debug.Log("Row size: "+ texts[i].GetComponent<Text>().preferredWidth);
                    if ((-125 + row) >= 158)
                    {
                        column += texts[i].GetComponent<Text>().preferredHeight + 7;
                        row = 0;
                    }
                }*/
                texts[i].transform.localPosition = new Vector3(-160 + row, 193 - column, texts[i].transform.position.z);
                row += texts[i].GetComponent<Text>().preferredWidth + 5;
                if ((-125 + row) >= 158)
                {
                    column += texts[i].GetComponent<Text>().preferredHeight + 7;
                    row = 0;
                }
            }
        }
    }

    void blankSpaces(int ans)
    {
        GameObject blankSpace = Instantiate(blank);
        blankSpace.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        blankSpace.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        Debug.Log("ans: " + ans);
        blankSpace.GetComponent<pressBlank>().setAnswer(words[ans-1]);
        answers.Add(words[ans - 1]);
        blankSpace.transform.parent = canvas.transform;
        blankSpace.transform.localPosition = new Vector3(-160 + row, 193 - column, blankSpace.transform.position.z);
        row += 77;
        blanks.Add(blankSpace);
    }

    public List<string> getAnswers()
    {
        return answers;
    }

    public List<GameObject> getBlanks()
    {
        if (blanks == null)
        {
            Debug.Log("no blanks");
        }
        return blanks;
    }

}
