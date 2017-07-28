using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pressBlank2 : MonoBehaviour {

    // Use this for initialization
    public int answer;
    public int stampNum;
    private bool correct = false;
    public bool occupied;
    public Sprite right;
    public Sprite wrong;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void toText()
    {
        
    }

    public bool checkWord()
    {
        correct = false;
        
        if (answer == stampNum) correct = true;

        return correct;
    }

    public void setOccupied(bool occ)
    {
        occupied = occ;
    }
    public bool getOccupied()
    {
        return occupied;
    }

    public void setAnswer(int ans)
    {
        answer = ans;
    }
    public int getAnswer()
    {
        return answer;
    }
    public void setStampnum(int sn)
    {
        stampNum = sn;
    }
    public int getStampnum()
    {
        return stampNum;
    }

    public void setWrong()
    {
        GetComponent<Image>().color = new Vector4(255,255,255,255);
        GetComponent<Image>().sprite = wrong;
        stampNum = 0;
        occupied = false;
    }
    public void setRight()
    {
        GetComponent<Image>().color = new Vector4(255, 255, 255, 255);
        GetComponent<Image>().sprite = right;
        occupied = true;
    }
}
