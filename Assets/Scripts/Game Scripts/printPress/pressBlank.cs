using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pressBlank : MonoBehaviour {

	// Use this for initialization
    private string answer;
    private GameObject textChild;
    private bool correct;
    private GameObject placedStamp;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void toText()
    {
        textChild = new GameObject();
        gameObject.GetComponent<Image>().enabled = false;
        textChild.AddComponent<Text>().text =answer;
        textChild.transform.parent = gameObject.transform;
        textChild.AddComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        textChild.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        textChild.GetComponent<RectTransform>().pivot = new Vector2(-0.25f, 1);
        //textChild.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        textChild.transform.localPosition = Vector3.zero;
        textChild.GetComponent<Text>().color = Color.black;
        textChild.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        Debug.Log("textchild position: " + textChild.transform.position.x);
    }

    public bool checkWord()
    {
        bool cor = false;
        if (answer == null || placedStamp == null) return false;
        if (answer == placedStamp.GetComponent<pressStamp>().getWord()) cor = true;

        return cor;
    }

    public void setAnswer(string ans)
    {
        answer = ans;
    }
    public string getAnswer()
    {
        return answer;
    }

    public void setCorrect(bool cor)
    {
        correct = cor;
    }
    public bool getCorrect()
    {
        return correct;
    }
    public void setPlaced(GameObject pl)
    {
        placedStamp = pl;
    }
    public GameObject getPlaced()
    {
        return placedStamp;
    }
}
