using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;

public class sceneMan : MonoBehaviour {

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
        //LoadScene(scene);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
