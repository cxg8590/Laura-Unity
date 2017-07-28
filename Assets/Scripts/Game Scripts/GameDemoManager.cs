using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameDemoManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void newLevel(string lv)
    {
        SceneManager.LoadScene(lv);
    }
}
