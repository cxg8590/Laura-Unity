using UnityEngine;
using System.Collections;

public class SchoolCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startQuiz()
    {
        Application.LoadLevel("Scenes/Quiz");
        //SceneManager.LoadScene("Quiz");
    }
}
