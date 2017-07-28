using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameDemoButton : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void click()
    {
        SceneManager.LoadScene(level);
    }
}
