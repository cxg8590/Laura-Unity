using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class pressManager2 : MonoBehaviour {
    public GameObject[] levels;
    public GameObject stampGroup;
    public GameObject canvas;
    private List<GameObject> stamps;
    private List<GameObject> blanks;

    private GameObject level; //current level
    private List<GameObject> finishedLevels;

    private int levelNum = 3; //how many levels before you finish
    private int currentLevel = 0; //what level you are on now

    //List<string> answers;

    // Use this for initialization
    void Start()
    {
        int levelNum = Random.Range(0, levels.Length);
        Debug.Log("level num: " + levelNum);
        level = levels[levelNum];
        finishedLevels = new List<GameObject>();
        startLevel();
    }


    // Update is called once per frame
    void Update () {
	
	}

    void getStamps()
    {
        foreach (Transform child in stampGroup.transform)
        {
            stamps.Add(child.gameObject);
        }
    }

    private void setText()
    {
        string[] words = level.GetComponent<pressLevel>().getWords();
        int[] order = level.GetComponent<pressLevel>().getAnswerOrder();
        int i = 0;
        foreach(GameObject stamp in stamps)
        {
            GameObject stampText = new GameObject();
            stampText.AddComponent<Text>().text = words[i];
            stampText.GetComponent<Text>().color = Color.black;
            stampText.GetComponent<Text>().font =  (Font)Resources.Load("Fonts/NimbusRomNo9L-Reg");//Resources.GetBuiltinResource(typeof(Font), "Media/Fonts/Chalkduster.ttf") as Font;
            stampText.GetComponent<Text>().fontSize = 31;
            stampText.AddComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            stampText.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            stampText.transform.SetParent(stamp.transform);
            stampText.transform.position = stamp.transform.position;
            stamp.GetComponent<pressStamp2>().stampNum = order[i] + 1;
            i++;  
        }
    }

    private void setBlanks()
    {
        level.SetActive(true);
        GameObject bls = level.transform.Find("blanks").gameObject;
        Debug.Log("blanks childcount: " + bls.transform.childCount);
        int blankCount = 0;
        foreach (Transform child in bls.transform)
        {
            Debug.Log(child.gameObject.GetComponent<pressBlank2>().name);
            blanks.Add(child.gameObject);
            Debug.Log(child.GetComponent<pressBlank2>().name);
            blanks[blankCount].GetComponent<pressBlank2>().setAnswer(blankCount + 1);
            blankCount++;
        }
        for (int i = 0; i < stamps.Count; i++)
        {
            stamps[i].GetComponent<pressStamp2>().setBlanks(blanks);
        }
    }

    void startLevel()
    {
        level.SetActive(true);
        level.GetComponent<pressLevel>().startMoving(true); //true means move to start false means move to end
        blanks = new List<GameObject>();
        stamps = new List<GameObject>();
        getStamps();
        setText();
        setBlanks();
    }

    void populateAnswers()
    {

        //answers..GetComponent<pressBlank2>().setAnchor();
    }

    public void check()
    {
        bool correct = true;
        Debug.Log("checking");
        for (int i = 0; i < blanks.Count; i++)
        {
            blanks[i].GetComponent<pressBlank2>().checkWord();
        }
        for (int i = 0; i < blanks.Count; i++)
        {
            if (!blanks[i].GetComponent<pressBlank2>().checkWord())correct = false;
          
            Debug.Log("stamp " + i + " has passed");
        }
        if (correct)
        {
            winLevel();
        }
        else
        {
            restartLevel();
        }
    }
    public void winLevel()
    {
        foreach (GameObject stamp in stamps)
        {
            stamp.GetComponent<pressStamp2>().snapBack();
        }
        level.GetComponent<pressLevel>().victory();
        level.GetComponent<pressLevel>().startMoving(false);
        finishedLevels.Add(level);
        currentLevel++;
        if(currentLevel == levelNum)
        {
            //finish
        }
        else
        {
            nextLevel();
        }
    }
    public void restartLevel()
    {
        foreach(GameObject stamp in stamps)
        {
            stamp.GetComponent<pressStamp2>().snapBack();
        }
        foreach (GameObject blank in blanks)
        {
            if (blank.GetComponent<pressBlank2>().checkWord())
            {
                blank.GetComponent<pressBlank2>().setRight();
            }
            else
            {
                blank.GetComponent<pressBlank2>().setWrong();
            }
        }
    }

    public void nextLevel()
    {
        int levelNum = Random.Range(0, levels.Length);
        level = levels[levelNum];
        while (finishedLevels.Contains(level)) //if the level has aready been beaten...
        {
            levelNum = Random.Range(0, levels.Length);
            level = levels[levelNum];//...reroll it until it's unique
        }
        foreach (GameObject stamp in stamps)
        {
            Destroy(stamp.transform.GetChild(0).gameObject);
        }
        startLevel();
    }
}
