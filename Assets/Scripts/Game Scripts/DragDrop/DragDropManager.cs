using UnityEngine;
using System.Collections;

public class DragDropManager : MonoBehaviour {

    public GameObject[] puzzle;
    public GameObject[] empty;
    public GameObject[] pieces;

    public GameObject[] barns;
    private GameObject[] puzzleBarns;

    public GameObject goodJob;

    private int full = 0;

    private int level = 0;
    // Use this for initialization
    void Start () {
        loadLevel();

    }
	
	// Update is called once per frame
	void Update () {
        int tempFull = 0;
        for(int i = 0; i < empty.Length; i++)
        {
            if (empty[i].GetComponent<emptyGrass>().occupied == true) tempFull++;
        }
        full = tempFull;
	}

    public bool lastCheck()
    {
        bool correct = false;   //final answer, is it correct
        GameObject last = empty[0]; //the previous piece
        int track = empty[0].GetComponent<emptyGrass>().track;  //is it a track, road, or undecided
        int i = 0;  //count how many times through the loop
        foreach (GameObject e in empty)
        {
           // Debug.Log("current track number: " + i);
           Debug.Log("current track : " + e.GetComponent<emptyGrass>().track + ", Recorded track: " + track);
            if (e.GetComponent<emptyGrass>().track == track && !e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().station) //is it what should be next in line and not a station
            {
                //if(e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track && track == 1)
                Debug.Log("Last: " + last.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track + i);
                Debug.Log("Current: " + e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track + i);
                if (e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track && e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track == last.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track)
                {
                    Debug.Log("current track1 : " + e.GetComponent<emptyGrass>().track);
                    correct = true;
                    last = e;
                }
                else if(!e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track && e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track == last.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().track)
                {
                    Debug.Log("current track2 : " + e.GetComponent<emptyGrass>().track);
                    correct = true;
                    last = e;
                }
                else
                {
                    Debug.Log("Wrong - track: " + i);
                    correct = false;
                    break;
                }
            }

            else if (e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().station) // is it a station
            {
                if(track == 1 && e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().leadIn) //is it the right station
                {
                    track = 2;//change the track type
                    correct = true;
                    last = e;
                }
                else if(track == 2 && !e.GetComponent<emptyGrass>().occupant.GetComponent<ClickDrag>().leadIn)//is it the right station
                {
                    track = 1;//change the track type
                    correct = true;
                    last = e;
                }
                else
                {
                    Debug.Log("Wrong - station: " + i);
                    correct = false;
                    break;
                }
            }
            else
            {
                correct = false;
                break;
            }
            i++;
        }

        return correct;
    }

    public void loadLevel()
    {
        //Debug.Log("next level");
        empty = new GameObject[puzzle[level].transform.childCount];
        for (int i = 0; i < empty.Length; i++)
        {
            empty[i] = puzzle[level].transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < empty.Length; i++)
        {
            empty[i].GetComponent<MeshRenderer>().enabled = true;
            empty[i].GetComponent<BoxCollider>().enabled = true;
            empty[i].GetComponent<emptyGrass>().number = i;
        }
        foreach (GameObject p in pieces)
        {
            p.GetComponent<ClickDrag>().empty = empty;
            p.GetComponent<ClickDrag>().Manager = this;
        }
        //barns
        puzzleBarns = new GameObject[barns[level].transform.childCount];
        for (int i = 0; i < puzzleBarns.Length; i++)
        {
            puzzleBarns[i] = barns[level].transform.GetChild(i).gameObject;
        }
        foreach (GameObject b in puzzleBarns)
        {
            b.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void nextLevel()
    {
        //Debug.Log("next level");
        for (int i = 0; i < empty.Length; i++)
        {
            empty[i].GetComponent<MeshRenderer>().enabled = false;
            empty[i].GetComponent<BoxCollider>().enabled = false;   
        }
        foreach (GameObject p in pieces)
        {
            Vector3 initPos = new Vector3(p.GetComponent<ClickDrag>().initX, p.GetComponent<ClickDrag>().initY, 48);
            p.transform.position = initPos;
        }
        foreach (GameObject b in puzzleBarns)
        {
            b.GetComponent<MeshRenderer>().enabled = false;
        }
        Instantiate(goodJob, new Vector3(0, 0, 0), Quaternion.identity);
        if (level <= 2)
        {
            level++;
            loadLevel();
        }
        else
        {
            Application.LoadLevel(0);
        }
    }
}
