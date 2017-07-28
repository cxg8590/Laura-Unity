using UnityEngine;
using System.Collections;

public class emptyGrass : MonoBehaviour {

    public GameObject[] correctRoad;
    public GameObject[] correctTrack;
    public int track;//0 - undecided, 1 - track, 2 - road
    public bool station = false;
    public int number;
    public bool correct;
    public bool occupied = false;
    public GameObject occupant;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
