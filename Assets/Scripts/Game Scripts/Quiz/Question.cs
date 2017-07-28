  using UnityEngine;
using System.Collections;

public class Question : MonoBehaviour {

    public string question;
    public string[] choices = new string[4];
    public int answer;

    public Question(string qs, string ch1, string ch2, string ch3, string ch4, int ans)
    {
        question = qs;
        choices[0] = ch1;
        choices[1] = ch2;
        choices[2] = ch3;
        choices[3] = ch4;
        answer = ans;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
