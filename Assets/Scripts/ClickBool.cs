using UnityEngine;
using System.Collections;

public class ClickBool : MonoBehaviour {

    public bool click = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnMouseDown()
    {
        click = true;
        Debug.Log("Clicked");
    }

    void OnMouseUp()
    {
        click = false;
    }
}
