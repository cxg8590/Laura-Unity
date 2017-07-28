using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class pressWords : MonoBehaviour {
    private string[] words;
    private GameObject stamp;
    private GameObject[] stamps;
    private GameObject canvas;
    List<GameObject> blanks;
    public pressWords(string[] wrds, GameObject stp, GameObject cvs, List<GameObject> bls)
    {
        words = wrds;
        stamp = stp;
        canvas = cvs;
        blanks = bls;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void populate()
    {
        stamps = new GameObject[words.Length];
        //Debug.Log("1st word in populate: " + stamps[0].GetComponentInChildren<Text>().text);
        for(int i = 0; i < words.Length; i++)
        {
            stamps[i] = Instantiate(stamp);
            stamps[i].transform.parent = canvas.transform;
            //stamps[i].transform.position = new Vector3(0, 0, 0);
            stamps[i].transform.localPosition = new Vector3(-410, 206 - (i * 62), stamps[i].transform.position.z);
            stamps[i].GetComponentInChildren<Text>().text = words[i];
            stamps[i].GetComponent<pressStamp>().setWord(words[i]);
            stamps[i].GetComponent<pressStamp>().setBlanks(blanks);
        }
    }

    public GameObject[] getStamps()
    {
        return stamps;
    }
}
