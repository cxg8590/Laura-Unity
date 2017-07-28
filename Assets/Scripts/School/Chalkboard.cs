using UnityEngine;
using System.Collections;

public class Chalkboard : MonoBehaviour {

    public bool onClick = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        onClick = true;
    }
}
