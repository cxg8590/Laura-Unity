using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelescopeClick : MonoBehaviour {
    public Image unfound;
    public Sprite found;
    public bool correct = false;
    void OnMouseDown()
    {
        unfound.sprite = found;
        correct = true;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
