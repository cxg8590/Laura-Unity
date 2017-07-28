using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class pressLevel : MonoBehaviour {

    public string[] words;
    public GameObject blanks;
    public GameObject paper;
    private int[] answerOrder;// what number blank each answer corrosponds to
    public Sprite victorySprite;

    public string[] wordBank;

    private Vector3 startPos;
    private Vector3 mainPos;
    private Vector3 endPos;
    public float speed = 2000.0F;
    private float startTime;
    private float journeyLength;

    private bool moving = false; //is it moving

    private bool start; //is it starting or ending

    // Use this for initialization
    void Start () {
        startPos = new Vector3(0, -615, 0);
        mainPos = Vector3.zero;
        endPos = new Vector3(0,615,0);
        speed = 150.0F;
        //moving = false;
        //startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
           float distCovered = (Time.time - startTime) * speed;
            //distCovered *= speed;
            float fracJourney = distCovered / journeyLength;
            if (start)
            {
                Vector3 currentPosition = Vector3.Lerp(startPos, mainPos, fracJourney);
                GetComponent<RectTransform>().localPosition = currentPosition;
                if (transform.localPosition == mainPos)
                {
                    moving = false;
                }
            }
            else
            {
                transform.localPosition = Vector3.Lerp(mainPos, endPos, fracJourney);
                if (transform.localPosition == endPos)
                {
                    moving = false;
                }
            }
        }
	}
    public string[] getWords()
    {
        //need to add from bank and randomize
        List<string> wordList = new List<string>(words);
        answerOrder = randomize(6);//get the order the words will be in

        //add some random words from the wordbank
        int[] randomBankIndex = randomize(wordBank.Length);
        for(int i = wordList.Count; i < 6; i++)
        {
            wordList.Add(wordBank[randomBankIndex[i]]);
        }

        //put all the words in correct random order
        string[] tempWordList = wordList.ToArray();
        for (int i = 0; i < 6; i++)
        {
            wordList[i] = tempWordList[answerOrder[i]];
        }

        //turn it into a string and ship it out
        string[] finalWords = wordList.ToArray();
        return finalWords;
    }

    private int[] randomize(int length)
    {
        List<int> randNums = new List<int>();
        for(int i = 0; i < length; i++)
        {
            int numToAdd = Random.Range(0, length);
            while (randNums.Contains(numToAdd)) //if the number has aready been used...
            {
                numToAdd = Random.Range(0, length);//...reroll it until it's unique
            }
            randNums.Add(numToAdd);
        }
        return randNums.ToArray();
    }

    public int[] getAnswerOrder()
    {
        return answerOrder;
    }

    public void startMoving(bool strt)
    {
        startPos = new Vector3(0, -615, 0);
        mainPos = Vector3.zero;
        endPos = new Vector3(0, 615, 0);
        start = strt;
        startTime = Time.time;
        if (start)
        {
            journeyLength = Vector3.Distance(startPos, mainPos);
        }
        else
        {
            journeyLength = Vector3.Distance(mainPos, endPos);
        }
        moving = true;
    }

    public void victory()
    {
        paper.GetComponent<Image>().sprite = victorySprite;
        blanks.SetActive(false);
    }

}
